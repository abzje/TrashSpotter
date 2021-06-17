using System;
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

		[Header("Totem settings")]
		[SerializeField] private GameObject totemCusto = null;
		[SerializeField] private Button animalTotemButton = null;
		[SerializeField] private Image totemImage = null;

		private GameObject[] scrollsnapElements;
		private List<BodypartAsset> bodypartsBySelectedType;

		private bool inputFieldCouldBeSelected;
		private EFamily currentFilter = EFamily.COMMON;
		private EBodypartType currentType = EBodypartType.HEAD;

		private Text switchShopButtonText;

        private void Start()
		{
			switchShopButtonText = switchCustoToggle.GetComponentInChildren<Text>();

			inputFieldCouldBeSelected = true;
			anteNameButton.onClick.AddListener(OnClickAnteName);
			editNameInputField.onEndEdit.AddListener(OnEndEditName);
			switchCustoToggle.onValueChanged.AddListener((value) => OnSwitchCustoToggle(value));
			animalTotemButton.onClick.AddListener(OnClickAnimalTotem);

			headButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.HEAD));
			eyeButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.EYES));
			mouthButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.MOUTH));
			tattoButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.TATTOO));
			hairButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.HAIR));
			topHeadButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.TOP_HEAD));
			clothButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.CLOTHES));
			earButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.EARS));
			ornamentButton.onValueChanged.AddListener((value) => UpdateType(EBodypartType.ORNAMENT));

			//Set scrollsnap & content
			InitScrollView();

			headButton.transform.GetChild(0).GetComponent<Image>().sprite = greenoidManager.GetHeadSprite();
			tattoButton.transform.GetChild(0).GetComponent<Image>().sprite = greenoidManager.GetTattooSprite() ;
			eyeButton.transform.GetChild(0).GetComponent<Image>().sprite = greenoidManager.GetEyesSprite();
			mouthButton.transform.GetChild(0).GetComponent<Image>().sprite = greenoidManager.GetMouthSprite();
			hairButton.transform.GetChild(0).GetComponent<Image>().sprite = greenoidManager.GetHairSprite();
			topHeadButton.transform.GetChild(0).GetComponent<Image>().sprite = greenoidManager.GetTopHeadSprite();
			earButton.transform.GetChild(0).GetComponent<Image>().sprite = greenoidManager.GetEarsSprite();
			clothButton.transform.GetChild(0).GetComponent<Image>().sprite = greenoidManager.GetClothesSprite();
			ornamentButton.transform.GetChild(0).GetComponent<Image>().sprite = greenoidManager.GetOrnamentSprite();
		}

        public override void Open()
		{
			animator.SetTrigger("OpenCustomisation");
			FilterToggleGroup.OnFilterClicked += UpdateFilter;

			//Set the correct animal totem
			animalTotemButton.GetComponentsInChildren<Image>()[1].sprite = greenoidManager._Totem._Image;
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
        private void InitScrollView()
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

			for (int i = 0; i < greenoidManager._BodypartAvailable.GetCount(); i++)
            {
				lBodypartAssetByTypeAndFilter = greenoidManager._BodypartAvailable.GetBodypartAsset(i);

				//filter by type
				if (lBodypartAssetByTypeAndFilter._Type == currentType)
                {
					//filter by family
					if (lBodypartAssetByTypeAndFilter._Family == currentFilter)
						bodypartsBySelectedType.Add(lBodypartAssetByTypeAndFilter);
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
			//***if bought and available -> Set item image, display it and change background
			currentScrollSnapElement.transform.GetChild(0).gameObject.SetActive(true);
			currentScrollSnapElement.transform.GetChild(0).GetComponent<Image>().sprite = currentBodypart._Sprite;
			currentScrollSnapElement.GetComponent<Image>().sprite = imageShopItemAvailable;

			//***if favortite -> Display tiny star image
			SetFavoriteBodypart(currentBodypart, currentScrollSnapElement);

			//***if not already bought -> Set price, display banner
			string lId = currentBodypart._Id.ToString();
			Transform lMoneyBanner = currentScrollSnapElement.transform.GetChild(2);

			if (lId.Substring(lId.Length - 1) == "0")
            {
				lMoneyBanner.gameObject.SetActive(false);
			}
			else
            {
				lMoneyBanner.gameObject.SetActive(true);
				lMoneyBanner.GetComponentInChildren<Text>().text = "" + currentBodypart._Price;
			}

			// Set graphic effects
			currentScrollSnapElement.GetComponent<Shadow>().effectDistance *= -1;

			// Add onclick listener
			Toggle itemButton = currentScrollSnapElement.GetComponent<Toggle>();

			itemButton.interactable = true;
			itemButton.onValueChanged.AddListener((value) => OnClickBodyPartButton(value, itemButton, currentBodypart));
		}

		private void SetFavoriteBodypart(BodypartAsset currentBodypart, GameObject currentScrollSnapElement)
        {

			foreach (int bodypartID in greenoidManager.GetCurrentBodyPartsIds())
			{

				if (currentBodypart._Id == bodypartID)
					currentScrollSnapElement.transform.GetChild(1).gameObject.SetActive(true);
			}
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
			InitScrollView();
		}

		/// <summary>
		/// Change the bodypart list in the scroll viw by clicking on a bodypart type selected toggle
		/// </summary>
		/// <param name="bodypart">The bodypart you want to apply</param>
		private void UpdateType(EBodypartType bodypartType)
        {
			currentType = bodypartType;
			InitScrollView();
		}
        #endregion

        #region Event Listeners
        /// <summary>
        /// Change the bodypart of the greenoid by cliking on it
        /// Update the body part selected toggle image
        /// </summary>
        /// <param name="bodypart">The bodypart you want to apply</param>
        private void OnClickBodyPartButton(bool value, Toggle toggle, BodypartAsset bodypart)
        {
			//Reset others elements
			for (int i = 0; i < scrollsnapElements.Length; i++)
            {
				scrollsnapElements[i].GetComponent<Shadow>().enabled = true;
				scrollsnapElements[i].transform.GetChild(1).gameObject.SetActive(false);
			}

			//Disable shadow for the selected one
			toggle.GetComponent<Shadow>().enabled = false;

			switch (bodypart._Type)
            {
                case EBodypartType.HEAD:
					greenoidManager.ChangeHead(bodypart._Sprite, bodypart._Id);
					headButton.transform.GetChild(0).GetComponent<Image>().sprite = bodypart._Sprite;
					break;

                case EBodypartType.TATTOO:
					greenoidManager.ChangeTattoo(bodypart._Sprite, bodypart._Id);
					tattoButton.transform.GetChild(0).GetComponent<Image>().sprite = bodypart._Sprite;
					break;

				case EBodypartType.EYES:
					greenoidManager.ChangeEyes(bodypart._Sprite, bodypart._Id);
					eyeButton.transform.GetChild(0).GetComponent<Image>().sprite = bodypart._Sprite;
					break;

                case EBodypartType.MOUTH:
					greenoidManager.ChangeMouth(bodypart._Sprite, bodypart._Id);
					mouthButton.transform.GetChild(0).GetComponent<Image>().sprite = bodypart._Sprite;
					break;

                case EBodypartType.HAIR:
					greenoidManager.ChangeHair(bodypart._Sprite, bodypart._Id);
					hairButton.transform.GetChild(0).GetComponent<Image>().sprite = bodypart._Sprite;
					break;

                case EBodypartType.TOP_HEAD:
					greenoidManager.ChangeTopHead(bodypart._Sprite, bodypart._Id);
					topHeadButton.transform.GetChild(0).GetComponent<Image>().sprite = bodypart._Sprite;
					break;

                case EBodypartType.EARS:
					Ears earsAsset = (Ears)bodypart;
					greenoidManager.ChangeEars(earsAsset._Sprite, earsAsset._EarsBackSprite, bodypart._Id);
					earButton.transform.GetChild(0).GetComponent<Image>().sprite = bodypart._Sprite;
					break;

                case EBodypartType.CLOTHES:
					greenoidManager.ChangeClothes(bodypart._Sprite, bodypart._Id);
					clothButton.transform.GetChild(0).GetComponent<Image>().sprite = bodypart._Sprite;
					break;

                case EBodypartType.ORNAMENT:
					greenoidManager.ChangeOrnament(bodypart._Sprite, bodypart._Id);
					ornamentButton.transform.GetChild(0).GetComponent<Image>().sprite = bodypart._Sprite;
					break;
                
				default:
                    break;
            }

			SetFavoriteBodypart(bodypart, toggle.gameObject);
			BuyItem(bodypart._Price, toggle.transform.GetChild(2).gameObject);
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

			Debug.LogWarning("[TO REPLACE LATTER] Draw scrollsnap here with totem content in it.");
			scrollsnap.gameObject.SetActive(value);
		}

		/// <summary>
		/// Open animalTotemPopUp
		/// </summary>
		private void OnClickAnimalTotem()
        {
			UIManager.Instance.OpenScreen(UIManager.Instance.animalTotemPopUp);
        }
        #endregion

		private void BuyItem(int price, GameObject priceBanner)
        {
			Gamification.Instance.Money -= price;
			priceBanner.SetActive(false);
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

			anteNameButton.onClick.RemoveListener(OnClickAnteName);
			editNameInputField.onEndEdit.RemoveListener(OnEndEditName);
			switchCustoToggle.onValueChanged.RemoveListener((value) => OnSwitchCustoToggle(value));
			animalTotemButton.onClick.RemoveListener(OnClickAnimalTotem);

			headButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.HEAD));
			eyeButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.EYES));
			mouthButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.MOUTH));
			tattoButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.TATTOO));
			hairButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.HAIR));
			topHeadButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.TOP_HEAD));
			clothButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.CLOTHES));
			earButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.EARS));
			ornamentButton.onValueChanged.RemoveListener((value) => UpdateType(EBodypartType.ORNAMENT));

		}
	}
}
