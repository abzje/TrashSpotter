using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class CustomisationScreen : Screen
    {
		[Header("General settings")]
		[SerializeField] private Toggle switchCustoToggle = null;
		[SerializeField] private ScrollsnapHandler scrollsnap = null;

		[Header("Name settings")]
		[SerializeField] public Button anteNameButton = null;
		[SerializeField] private InputField editNameInputField = null;
		[SerializeField] public GameObject fadedBackground = null;

		[Header("Greenoid settings")]
		[SerializeField] private GameObject greenoidCusto = null;
		[SerializeField] private ToggleGroup filterToggleGroup = null;
		[SerializeField] private Greenoide greenoide = null;

		[Header("Totem settings")]
		[SerializeField] private GameObject totemCusto = null;
		[SerializeField] private Button animalTotemButton = null;
		[SerializeField] private Image totemImage = null;

		private GameObject[] scrollsnapElements;

		private bool inputFieldCouldBeSelected;

		private void Start()
		{
			inputFieldCouldBeSelected = true;
			anteNameButton.onClick.AddListener(OnClickAnteName);
			editNameInputField.onEndEdit.AddListener(OnEndEditName);
			switchCustoToggle.onValueChanged.AddListener((value) => OnSwitchCustoToggle(value));
			animalTotemButton.onClick.AddListener(OnClickAnimalTotem);

			//Set scrollsnap & content

			scrollsnapElements = scrollsnap.InitScrollSnap(10/*nombre au pif en attedant*/);
			/*scrollsnapElements = scrollsnap.InitScrollSnap(UIManager.Instance.bodyPartList._BodypartList.Count);

			BodypartAsset lBodyPartAsset;

            for (int i = 0; i < scrollsnapElements.Length; i++)
            {
				int lClosureIndex = i;
				lBodyPartAsset = UIManager.Instance.bodyPartList._BodypartList[lClosureIndex];

				scrollsnapElements[lClosureIndex].transform.GetChild(0).GetComponent<Image>().sprite = lBodyPartAsset._Sprite;

				scrollsnapElements[lClosureIndex].GetComponent<Toggle>().onValueChanged.AddListener((value) => OnClickBodyPartButton(lBodyPartAsset));
			}*/
		}

		private void OnClickBodyPartButton(BodypartAsset bodypart)
        {
			/*
			switch (bodypart._Type)
            {
                case EBodypartType.EYES:
					greenoide._Eyes = bodypart;

					break;
                case EBodypartType.MOUTH:
					mouthSelected = bodypart;

					break;
                case EBodypartType.TATTOO:
					tattooSelected = bodypart;

					break;
                case EBodypartType.HAIR:
					hairSelected = bodypart;

					break;
                case EBodypartType.TOP_HEAD:
					Debug.LogError("not already implemented");

                    break;
                case EBodypartType.EARS:
					earsSelected = bodypart;

					break;
                case EBodypartType.CLOTH:
					clothSelected = bodypart;

					break;
                case EBodypartType.ORNAMENT:
					ornamentSelected = bodypart;

					break;
                case EBodypartType.EAR_BACK:
					earBackSelected = bodypart;

					break;
                case EBodypartType.HEAD:
					headSelected = bodypart;

					break;
                default:
                    break;
            }*/
        }

        private void OnClickAnteName()
        {
			UIManager.Instance.OpenScreen(UIManager.Instance.anteNamePopUp);
			fadedBackground.SetActive(true);
		}

		private void OnEndEditName(string value)
		{
			inputFieldCouldBeSelected = true;
			//if (UIManager.Instance.editableNameNamePopUp.isOpen) UIManager.Instance.ClosePopUp(UIManager.Instance.editableNameNamePopUp);
			Debug.Log("Do animations of leaving input editing here");
		}

		private void OnSwitchCustoToggle(bool value)
		{
			greenoidCusto.SetActive(value);
			totemCusto.SetActive(!value);
		}

		private void OnClickAnimalTotem()
        {
			UIManager.Instance.OpenScreen(UIManager.Instance.animalTotemPopUp);
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

		}
	}
}
