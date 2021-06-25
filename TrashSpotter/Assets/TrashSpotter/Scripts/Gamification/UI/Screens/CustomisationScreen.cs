using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class CustomisationScreen : Screen
    {
		[Header("General settings")]
		[SerializeField] private Toggle switchCustoToggle = null;
		[SerializeField] private Image switchCustoToggleTotemImage = null;
		[SerializeField] private Image switchCustoToggleGreenoidImage = null;
		[SerializeField] private ScrollsnapHandler scrollsnap = null;
		[SerializeField] private FilterToggleGroup filterToggleGroup = null;
		[SerializeField] private Text money = null;
		[SerializeField] private Sprite imageShopItemAvailable = null;
		[SerializeField] private Button buyButton = null;

		[Header("Name settings")]
		[SerializeField] public Button anteNameButton = null;
		[SerializeField] private InputField editNameInputField = null;
		[SerializeField] public GameObject fadedBackground = null;

		[Header("Greenoid settings")]
		[SerializeField] private GreenoideManager greenoidManager = null;
		[SerializeField] private GameObject greenoidCusto = null;
		[SerializeField] private Toggle headButton = null;
		[SerializeField] private Toggle eyeButton = null;
		[SerializeField] private Toggle mouthButton = null;
		[SerializeField] private Toggle tattoButton = null;
		[SerializeField] private Toggle hairButton = null;
		[SerializeField] private Toggle topHeadButton = null;
		[SerializeField] private Toggle clothButton = null;
		[SerializeField] private Toggle earButton = null;
		[SerializeField] private Toggle ornamentButton = null;
		[SerializeField] private Toggle favoriteButton = null;

		[Header("Totem settings")]
		[SerializeField] private GameObject totemCusto = null;
		[SerializeField] private Button animalTotemButton = null;
		[SerializeField] private Image totemImage = null;

		[Header("Autel settings")]
		[SerializeField] private List<Altar> altars = null;
		[SerializeField] private Toggle maskButton = null;
		[SerializeField] private Toggle tikisButton = null;
		[SerializeField] private Toggle totemButton = null;
		private EAltarType currentAltarType = EAltarType.MASK;

		private GameObject[] scrollsnapElements;
		private List<BodypartAsset> bodypartsBySelectedType;

		private bool inputFieldCouldBeSelected;
		private EFamily currentFilter = EFamily.GUARDIANS;
		private EBodypartType currentType = EBodypartType.HEAD;

		private Text switchShopButtonText;

		private List<Toggle> bodypartTypeButtons = new List<Toggle>();

		private BodypartAsset itemToBuySelected;
		private GameObject itemToBuyPriceBanner;

		private void Start()
		{
			filterToggleGroup.gameObject.SetActive(false);

			bodypartTypeButtons.Add(headButton);
			bodypartTypeButtons.Add(eyeButton);
			bodypartTypeButtons.Add(mouthButton);
			bodypartTypeButtons.Add(tattoButton);
			bodypartTypeButtons.Add(hairButton);
			bodypartTypeButtons.Add(topHeadButton);
			bodypartTypeButtons.Add(clothButton);
			bodypartTypeButtons.Add(earButton);
			bodypartTypeButtons.Add(ornamentButton);

			switchShopButtonText = switchCustoToggle.GetComponentInChildren<Text>();

			inputFieldCouldBeSelected = true;
			anteNameButton.onClick.AddListener(OnClickAnteName);
			editNameInputField.onEndEdit.AddListener(OnEndEditName);
			switchCustoToggle.onValueChanged.AddListener((value) => OnSwitchCustoToggle(value));
			animalTotemButton.onClick.AddListener(OnClickAnimalTotem);

			//bodypart top buttons
			headButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.HEAD, headButton));
			eyeButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.EYES, eyeButton));
			mouthButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.MOUTH, mouthButton));
			tattoButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.TATTOO, tattoButton));
			hairButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.HAIR, hairButton));
			topHeadButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.TOP_HEAD, topHeadButton));
			clothButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.CLOTHES, clothButton));
            earButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.EARS, earButton));
			ornamentButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.ORNAMENT, ornamentButton));

			//favorite toggles
			headButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.AddListener((value) => OnClickFavoriteBodypart(value, headButton));
			eyeButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.AddListener((value) => OnClickFavoriteBodypart(value, eyeButton));
			mouthButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.AddListener((value) => OnClickFavoriteBodypart(value, mouthButton));
			tattoButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.AddListener((value) => OnClickFavoriteBodypart(value, tattoButton));
			hairButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.AddListener((value) => OnClickFavoriteBodypart(value, hairButton));
			topHeadButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.AddListener((value) => OnClickFavoriteBodypart(value, topHeadButton));
			clothButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.AddListener((value) => OnClickFavoriteBodypart(value, clothButton));
			earButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.AddListener((value) => OnClickFavoriteBodypart(value, earButton));
			ornamentButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.AddListener((value) => OnClickFavoriteBodypart(value, ornamentButton));

			buyButton.onClick.AddListener(BuyItem);

			tikisButton.onValueChanged.AddListener((value) => UpdateType(EAltarType.TIKI));
			totemButton.onValueChanged.AddListener((value) => UpdateType(EAltarType.TOTEM));
			maskButton.onValueChanged.AddListener((value) => UpdateType(EAltarType.MASK));

			//Set scrollsnap & content
			InitCustoScrollView();

			headButton.transform.GetChild(1).GetComponent<Image>().sprite = greenoidManager.GetHeadSprite();
			tattoButton.transform.GetChild(1).GetComponent<Image>().sprite = greenoidManager.GetTattooSprite();
			eyeButton.transform.GetChild(1).GetComponent<Image>().sprite = greenoidManager.GetEyesSprite();
			mouthButton.transform.GetChild(1).GetComponent<Image>().sprite = greenoidManager.GetMouthSprite();
			hairButton.transform.GetChild(1).GetComponent<Image>().sprite = greenoidManager.GetHairSprite();
			topHeadButton.transform.GetChild(1).GetComponent<Image>().sprite = greenoidManager.GetTopHeadSprite();
			earButton.transform.GetChild(1).GetComponent<Image>().sprite = greenoidManager.GetEarsSprite();
			clothButton.transform.GetChild(1).GetComponent<Image>().sprite = greenoidManager.GetClothesSprite();
			ornamentButton.transform.GetChild(1).GetComponent<Image>().sprite = greenoidManager.GetOrnamentSprite();

		}

        public override void Open()
		{
			animator.SetTrigger("OpenCustomisation");
			FilterToggleGroup.OnFilterClicked += UpdateFilter;

			if (greenoidCusto.activeSelf)
				InitCustoScrollView();
			else
				InitAltarScrollView();

			//Set the correct animal totem
			animalTotemButton.GetComponentsInChildren<Image>()[1].sprite = greenoidManager.totem._Image;
		}

		public override void Close()
		{
			animator.SetTrigger("OpenGreenoLandFromCusto");
			FilterToggleGroup.OnFilterClicked -= UpdateFilter;
		}

        #region Initialization
        /// <summary>
        /// Inits scroll snap, fills bodypart button by type and filter
        /// </summary>
        private void InitCustoScrollView()
        {
			//reset listener
			if (scrollsnapElements != null)
            {
				for (int i = 0; i < scrollsnapElements.Length; i++)
				{
					int lClosureIndex = i;
					scrollsnapElements[lClosureIndex].GetComponent<Toggle>().onValueChanged.RemoveAllListeners();
				}
			}

			bodypartsBySelectedType = new List<BodypartAsset>();

			BodypartAsset lBodypartAssetByTypeAndFilter;

			for (int i = 0; i < greenoidManager.bodypartAvailable.GetCount(); i++)
            {
				lBodypartAssetByTypeAndFilter = greenoidManager.bodypartAvailable.GetBodypartAsset(i);
				
				//filter by level
				if (lBodypartAssetByTypeAndFilter.level <= Gamification.Instance.Level)
				{
					//filter by type
					if (lBodypartAssetByTypeAndFilter.type == currentType)
					{
						//filter by family
						if (lBodypartAssetByTypeAndFilter.family == currentFilter || currentFilter == EFamily.COMMON)
							bodypartsBySelectedType.Add(lBodypartAssetByTypeAndFilter);
					}
				}
			}

			scrollsnapElements = scrollsnap.InitScrollSnap(bodypartsBySelectedType.Count);

			for (int i = 0; i < scrollsnapElements.Length; i++)
			{
				int lClosureIndex = i;
				InitShopItemButton(bodypartsBySelectedType[lClosureIndex], scrollsnapElements[lClosureIndex]);
			}
		}

		/// <summary>
		/// Initialize shop item button data -> state, graphic effects, listener
		/// </summary>
		/// <param name="currentBodypart">The bodypart set as an image in it</param>
		/// <param name="currentScrollSnapElement">The shop item button that will be initialize</param>
		private void InitShopItemButton(BodypartAsset currentBodypart, GameObject currentScrollSnapElement)
        {

			//***Set button data***
			//***if available -> Set item image, display it and change background
			currentScrollSnapElement.transform.GetChild(0).gameObject.SetActive(true);
			currentScrollSnapElement.transform.GetChild(0).GetComponent<Image>().sprite = currentBodypart.sprite;
			currentScrollSnapElement.GetComponent<Image>().sprite = imageShopItemAvailable;

			//***if favortite -> Display tiny star image
			foreach (int bodypartID in greenoidManager.GetCurrentBodyPartsIds())
			{

				if (currentBodypart.id == bodypartID)
					currentScrollSnapElement.transform.GetChild(1).gameObject.SetActive(true);
			}

			//***if not already bought -> Set price, display banner
			Transform lMoneyBanner = currentScrollSnapElement.transform.GetChild(2);
			lMoneyBanner.gameObject.SetActive(!currentBodypart.isBought);
			lMoneyBanner.GetComponentInChildren<Text>().text = "" + currentBodypart.price;

			// Set graphic effects
			currentScrollSnapElement.GetComponent<Shadow>().effectDistance *= -1;

			// Add onclick listener
			Toggle itemButton = currentScrollSnapElement.GetComponent<Toggle>();

			itemButton.interactable = true;
			itemButton.onValueChanged.AddListener((value) => OnClickBodyPartButton(value, itemButton, currentBodypart));
		}

		/// <summary>
        /// Inits scroll snap, filters altars button by type
        /// </summary>
        private void InitAltarScrollView()
        {
			//reset listener
			if (scrollsnapElements != null)
            {
				for (int i = 0; i < scrollsnapElements.Length; i++)
				{
					int lClosureIndex = i;
					scrollsnapElements[lClosureIndex].GetComponent<Toggle>().onValueChanged.RemoveAllListeners();
				}
			}

			List<Altar> selectedAltars = new List<Altar>();

			Altar lAltarByType;

			for (int i = 0; i < altars.Count; i++)
            {
				lAltarByType = altars[i];
				
				//filter by type
				if (lAltarByType.type == currentAltarType)
				{
					//filter by level
					if (lAltarByType.level <= Gamification.Instance.Level)
						selectedAltars.Add(lAltarByType);
				}
			}

			scrollsnapElements = scrollsnap.InitScrollSnap(selectedAltars.Count);

			for (int i = 0; i < scrollsnapElements.Length; i++)
			{
				int lClosureIndex = i;
				InitShopAltarButton(selectedAltars[lClosureIndex], scrollsnapElements[lClosureIndex]);
			}
		}

		/// <summary>
		/// Initialize shop item button data -> state, graphic effects, listener
		/// </summary>
		/// <param name="currentAltar">The altar set as an image in it</param>
		/// <param name="currentScrollSnapElement">The shop item button that will be initialize</param>
		private void InitShopAltarButton(Altar currentAltar, GameObject currentScrollSnapElement)
        {

			//***Set button data***
			//***if bought and available -> Set item image, display it and change background
			currentScrollSnapElement.transform.GetChild(0).gameObject.SetActive(true);
			currentScrollSnapElement.transform.GetChild(0).GetComponent<Image>().sprite = currentAltar.sprite;
			currentScrollSnapElement.GetComponent<Image>().sprite = imageShopItemAvailable;

/*
			//***if not already bought -> Set price, display banner
			string lId = currentBodypart.id.ToString();
			Transform lMoneyBanner = currentScrollSnapElement.transform.GetChild(2);

			if (lId.Substring(lId.Length - 1) == "0")
            {
				lMoneyBanner.gameObject.SetActive(false);
			}
			else
            {
				lMoneyBanner.gameObject.SetActive(true);
				lMoneyBanner.GetComponentInChildren<Text>().text = "" + currentBodypart.price;
			}
*/
			// Set graphic effects
			currentScrollSnapElement.GetComponent<Shadow>().effectDistance *= -1;

			// Add onclick listener
			Toggle itemButton = currentScrollSnapElement.GetComponent<Toggle>();

			itemButton.interactable = true;
			itemButton.onValueChanged.AddListener((value) => OnClickAltarButton(value, itemButton, currentAltar));
		}

		#endregion

		#region Update Scrollview
		/// <summary>
		/// Change the bodypart list in the scroll viw by clicking on the family filter
		/// </summary>
		/// <param name="bodypart">The bodypart you want to apply</param>
		private void UpdateFilter(EFamily bodypartFamiliy)
		{
			currentFilter = bodypartFamiliy;
			InitCustoScrollView();
		}

		/// <summary>
		/// Change the alar list in the scroll view by clicking on an altar type toggle
		/// </summary>
		/// <param name="bodypart">The bodypart you want to apply</param>
		private void UpdateType(EAltarType altarType)
        {
			currentAltarType = altarType;
			InitAltarScrollView();
		}

		/// <summary>
		/// Change the bodypart list in the scroll viw by clicking on a bodypart type selected toggle
		/// </summary>
		/// <param name="bodypart">The bodypart you want to apply</param>
		private void UpdateType(EBodypartType bodypartType, Toggle selectedToggle)
        {
			currentType = bodypartType;
			InitCustoScrollView();

            foreach (Toggle toggle in bodypartTypeButtons)
            {
				toggle.transform.GetChild(0).gameObject.SetActive(toggle.isOn);
			}

			bool isFilterActive = selectedToggle == headButton || selectedToggle == eyeButton || selectedToggle == mouthButton;

			filterToggleGroup.gameObject.SetActive(!isFilterActive);
		}
		#endregion

		#region Event Listeners

		/// <summary>
		/// Change the bodypart saved between screens (favorite one)
		/// </summary>
		/// <param name="value">The new valut of the toggle</param>
		/// <param name="bodypartButton">The parent button that contain this favorite toggle</param>
		private void OnClickFavoriteBodypart(bool value, Toggle bodypartButton)
        {
			bodypartButton.transform.GetChild(2).GetChild(0).gameObject.SetActive(value);

			bool lIsFavorite;

            foreach (GameObject scrollsnapElement in scrollsnapElements)
            {
				lIsFavorite = scrollsnapElement.transform.GetChild(0).GetComponent<Image>().sprite == bodypartButton.transform.GetChild(0).GetComponent<Image>().sprite;
				scrollsnapElement.transform.GetChild(1).gameObject.SetActive(lIsFavorite);
			}
		}

        /// <summary>
        /// Change the bodypart of the greenoid by cliking on it
        /// Update the body part selected toggle image
        /// </summary>
        /// <param name="bodypart">The bodypart you want to apply</param>
        private void OnClickBodyPartButton(bool value, Toggle toggle, BodypartAsset bodypart)
        {
			//Reset shadow
			for (int i = 0; i < scrollsnapElements.Length; i++)
            {
				scrollsnapElements[i].GetComponent<Shadow>().enabled = true;
			}

			//Disable shadow for the selected one
			toggle.GetComponent<Shadow>().enabled = false;

			buyButton.gameObject.SetActive(!bodypart.isBought);

			if (!bodypart.isBought)
			{
				itemToBuySelected = bodypart;
				itemToBuyPriceBanner = toggle.transform.GetChild(2).gameObject;
				return;
			}

			switch (bodypart.type)
            {
                case EBodypartType.HEAD:
					greenoidManager.ChangeHead(bodypart.sprite, bodypart.id);
					headButton.transform.GetChild(1).GetComponent<Image>().sprite = bodypart.sprite;
					break;

                case EBodypartType.TATTOO:
					greenoidManager.ChangeTattoo(bodypart.sprite, bodypart.id);
					tattoButton.transform.GetChild(1).GetComponent<Image>().sprite = bodypart.sprite;
					break;

				case EBodypartType.EYES:
					greenoidManager.ChangeEyes(bodypart.sprite, bodypart.id);
					eyeButton.transform.GetChild(1).GetComponent<Image>().sprite = bodypart.sprite;
					break;

                case EBodypartType.MOUTH:
					greenoidManager.ChangeMouth(bodypart.sprite, bodypart.id);
					mouthButton.transform.GetChild(1).GetComponent<Image>().sprite = bodypart.sprite;
					break;

                case EBodypartType.HAIR:
					greenoidManager.ChangeHair(bodypart.sprite, bodypart.id);
					hairButton.transform.GetChild(1).GetComponent<Image>().sprite = bodypart.sprite;
					break;

                case EBodypartType.TOP_HEAD:
					greenoidManager.ChangeTopHead(bodypart.sprite, bodypart.id);
					topHeadButton.transform.GetChild(1).GetComponent<Image>().sprite = bodypart.sprite;
					break;

                case EBodypartType.EARS:
					Ears earsAsset = (Ears)bodypart;
					greenoidManager.ChangeEars(earsAsset.sprite, earsAsset.earsBackSprite, bodypart.id);
					earButton.transform.GetChild(1).GetComponent<Image>().sprite = bodypart.sprite;
					break;

                case EBodypartType.CLOTHES:
					greenoidManager.ChangeClothes(bodypart.sprite, bodypart.id);
					clothButton.transform.GetChild(1).GetComponent<Image>().sprite = bodypart.sprite;
					break;

                case EBodypartType.ORNAMENT:
					greenoidManager.ChangeOrnament(bodypart.sprite, bodypart.id);
					ornamentButton.transform.GetChild(1).GetComponent<Image>().sprite = bodypart.sprite;
					break;
                
				default:
                    break;
            }
		}

		private void OnClickAltarButton(bool value, Toggle toggle, Altar altar)
        {
			//Reset others elements
			for (int i = 0; i < scrollsnapElements.Length; i++)
            {
				scrollsnapElements[i].GetComponent<Shadow>().enabled = true;
				scrollsnapElements[i].transform.GetChild(1).gameObject.SetActive(false);
			}

			//Disable shadow for the selected one
			toggle.GetComponent<Shadow>().enabled = false;

			switch(altar.type)
			{
				case EAltarType.TIKI : break;
				case EAltarType.MASK : break;
				case EAltarType.TOTEM : break;
				default : break;
			}
		}

		/// <summary>
		/// Open AnteNamePopUp that allow user to change his ante name
		/// </summary>
		private void OnClickAnteName()
        {
			UIManager.Instance.OpenScreen(UIManager.Instance.anteNamePopUp);
			fadedBackground.SetActive(true);
		}

		/// <summary>
		/// Close the editableNameNamePopUp
		/// </summary>
		/// <param name="value">The text typed by the user</param>
		private void OnEndEditName(string value)
		{
			inputFieldCouldBeSelected = true;

			//if (UIManager.Instance.editableNameNamePopUp.isOpen) UIManager.Instance.ClosePopUp(UIManager.Instance.editableNameNamePopUp);
			Debug.Log("Do animations of leaving input editing here");
		}

		/// <summary>
		/// Switch shop greenoide or alatar
		/// </summary>
		/// <param name="value">Boolean equal to "is switching to greenoide ?"</param>
		private void OnSwitchCustoToggle(bool value)
		{
			greenoidCusto.SetActive(value);
			totemCusto.SetActive(!value);

			filterToggleGroup.gameObject.SetActive(value);

			switchCustoToggleGreenoidImage.gameObject.SetActive(!value);
			switchCustoToggleTotemImage.gameObject.SetActive(value);

			switchShopButtonText.text = value ? "Autels" : "Greenoïde";

			if(value)
				InitCustoScrollView();
			else
				InitAltarScrollView();
			//scrollsnap.gameObject.SetActive(value);
		}

		/// <summary>
		/// Open animalTotemPopUp
		/// </summary>
		private void OnClickAnimalTotem()
        {
			UIManager.Instance.OpenScreen(UIManager.Instance.animalTotemPopUp);
        }
        #endregion

		private void BuyItem()
        {
			Gamification.Instance.Money -= itemToBuySelected.price;
			itemToBuySelected.isBought = true;
			itemToBuyPriceBanner.SetActive(false);
			money.text = "" + Gamification.Instance.Money;
		}

        private void Update()
		{
			if (EventSystem.current.currentSelectedGameObject == editNameInputField.gameObject)
			{
				if (editNameInputField.isFocused && inputFieldCouldBeSelected)
                {
					UIManager.Instance.OpenScreen(UIManager.Instance.editableNameNamePopUp);
					inputFieldCouldBeSelected = false;
                }
			}
		}

        protected override void OnDestroy()
		{
			base.OnDestroy();

			buyButton.onClick.RemoveListener(BuyItem);

			anteNameButton.onClick.RemoveListener(OnClickAnteName);
			editNameInputField.onEndEdit.RemoveListener(OnEndEditName);
			switchCustoToggle.onValueChanged.RemoveListener((value) => OnSwitchCustoToggle(value));
			animalTotemButton.onClick.RemoveListener(OnClickAnimalTotem);

			headButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.HEAD, headButton));
			eyeButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.EYES, eyeButton));
			mouthButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.MOUTH, mouthButton));
			tattoButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.TATTOO, tattoButton));
			hairButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.HAIR, hairButton));
			topHeadButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.TOP_HEAD, topHeadButton));
			clothButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.CLOTHES, clothButton));
			earButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.EARS, earButton));
			ornamentButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.ORNAMENT, ornamentButton));

			//favorite toggles
			headButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.RemoveListener((value) => OnClickFavoriteBodypart(value, headButton));
			eyeButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.RemoveListener((value) => OnClickFavoriteBodypart(value, eyeButton));
			mouthButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.RemoveListener((value) => OnClickFavoriteBodypart(value, mouthButton));
			tattoButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.RemoveListener((value) => OnClickFavoriteBodypart(value, tattoButton));
			hairButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.RemoveListener((value) => OnClickFavoriteBodypart(value, hairButton));
			topHeadButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.RemoveListener((value) => OnClickFavoriteBodypart(value, topHeadButton));
			clothButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.RemoveListener((value) => OnClickFavoriteBodypart(value, clothButton));
			earButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.RemoveListener((value) => OnClickFavoriteBodypart(value, earButton));
			ornamentButton.transform.GetChild(2).GetComponent<Toggle>().onValueChanged.RemoveListener((value) => OnClickFavoriteBodypart(value, ornamentButton));

			tikisButton.onValueChanged.RemoveAllListeners();
			totemButton.onValueChanged.RemoveAllListeners();
			maskButton.onValueChanged.RemoveAllListeners();
		}
	}
}
