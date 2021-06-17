using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Com.TrashSpotter
{
    public class AnimalTotemPopUp : PopUp
    {
        [Header("Animal Details Settings")]
        [SerializeField] private Toggle favoriteButton = null;
        [SerializeField] private Image animalImage = null;
        [SerializeField] private Text animalNameText = null;
        [SerializeField] private Text animalKeyword1Text = null;
        [SerializeField] private Text animalKeyword2Text = null;
        [SerializeField] private Text animalKeyword3Text = null;
        [SerializeField] private Text animalDescriptionText = null;

        [Header("General Settings")]
        [SerializeField] private Button backgroundButton = null;

        [Header("Scrollsnap")]
        [SerializeField] private ScrollsnapHandler scrollsnap = null;

        [Header("Content")]
        [SerializeField] private GreenoideManager greenoide = null;
        [SerializeField] private List<TotemAnimal> availableTotems = null;

        private GameObject[] scrollsnapElements = null;
        private EFamily currentFamilyFilter = EFamily.COMMON;
        private List<TotemAnimal> totemsBySelection = null;

        private string favoriteAnimalName;
        private TotemAnimal currentTotemAnimalSelected;

        public override void Open()
        {
            base.Open();
            SetTotemInfos(greenoide._Totem);
        }

        private void Start()
        {
            backgroundButton.onClick.AddListener(OnClickQuit);
            favoriteButton.onValueChanged.AddListener(OnClickFavorite);

            //Set scrollsnap & content
            InitScrollView();
        }

        #region Initialization
        /// <summary>
        /// Inits scroll snap, fills totem button by family
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

            totemsBySelection = new List<TotemAnimal>();
            
            foreach(TotemAnimal totem in availableTotems)
            {
                if (currentFamilyFilter == EFamily.COMMON || totem._Family == currentFamilyFilter)
                    totemsBySelection.Add(totem);
            }

            scrollsnapElements = scrollsnap.InitScrollSnap(totemsBySelection.Count);

            for (int i = 0; i < scrollsnapElements.Length; i++)
			{
				int lClosureIndex = i;
				InitTotemButton(totemsBySelection[lClosureIndex], scrollsnapElements[lClosureIndex]);
			}
        }

        /// <summary>
		/// Initializes totem button data -> data, listener
		/// </summary>
		/// <param name="currentTotem">The TotemAnimal set as an image in it</param>
		/// <param name="currentScrollSnapElement">The totem button that will be initialize</param>
        private void InitTotemButton(TotemAnimal currentTotem, GameObject currentScrollSnapElement)
        {
            // Set button data
            currentScrollSnapElement.transform.GetChild(0).gameObject.SetActive(true);
            
            //Set text data
            Text lAnimalName = currentScrollSnapElement.transform.GetChild(2).GetComponent<Text>();
            lAnimalName.gameObject.SetActive(true);
            lAnimalName.text = currentTotem._Name;

            //Set favorite
            currentScrollSnapElement.transform.GetChild(1).gameObject.SetActive(favoriteAnimalName == currentTotem._Name);

            currentScrollSnapElement.transform.GetChild(0).GetComponent<Image>().sprite = currentTotem._Image;

            // Add onclick listener
			Toggle itemButton = currentScrollSnapElement.GetComponent<Toggle>();
            itemButton.interactable = true;
			itemButton.onValueChanged.AddListener((value) => OnClickTotemButton(value, itemButton, currentTotem));
        }
        #endregion

        #region Event Listeners
        
        private void OnClickTotemButton(bool value, Toggle toggle, TotemAnimal totem)
        {
            // Change seen totem
            SetTotemInfos(totem);
        }

        private void OnClickFavorite(bool value)
        {
            favoriteButton.transform.GetChild(0).gameObject.SetActive(value);
            favoriteAnimalName = animalNameText.text;

            // Set favorite Totem
            greenoide.ChangeTotem(currentTotemAnimalSelected);

            foreach (GameObject animalButton in scrollsnapElements)
            {
                animalButton.transform.GetChild(1).gameObject.SetActive(animalButton.transform.GetChild(2).GetComponent<Text>().text == favoriteAnimalName);
            }
        }

        private void OnClickQuit()
        {
            UIManager.Instance.ClosePopUp(this);
        }

        #endregion

        public void SetTotemInfos(TotemAnimal totem)
        {
            currentTotemAnimalSelected = totem;
            favoriteButton.isOn = totem._Name == favoriteAnimalName;

            animalImage.sprite = totem._Image;
            animalNameText.text = totem._Name;
            animalKeyword1Text.text = totem._KeyWord1;
            animalKeyword2Text.text = totem._KeyWord2;
            animalKeyword3Text.text = totem._KeyWord3;
            animalDescriptionText.text = totem._Info;
        }

        protected override void OnDestroy()
        {
            backgroundButton.onClick.RemoveListener(OnClickQuit);
            favoriteButton.onValueChanged.RemoveListener(OnClickFavorite);
        }
    }
}
