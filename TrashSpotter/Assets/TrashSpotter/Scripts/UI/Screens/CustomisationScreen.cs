using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class CustomisationScreen : Screen
    {
		[Header("General settings")]
		[SerializeField] private Button prefixNameButton = null;
		[SerializeField] private InputField sufixNameInputField = null;
		[SerializeField] private Toggle switchCustoToggle = null;
		[SerializeField] private ScrollsnapHandler scrollsnap = null;

		[Header("Greenoid settings")]
		[SerializeField] private GameObject greenoidCusto = null;
		[SerializeField] private ToggleGroup filterToggleGroup = null;

		[Header("Totem settings")]
		[SerializeField] private GameObject totemCusto = null;
		[SerializeField] private Button animalTotemButton = null;

		private bool inputFieldCouldBeSelected;

		private void Start()
		{

			inputFieldCouldBeSelected = true;
			prefixNameButton.onClick.AddListener(OnClickPrefixName);
			sufixNameInputField.onValueChanged.AddListener((value) => OnClickSufixName(value));
			sufixNameInputField.onEndEdit.AddListener(OnEndEditSufixName);
			switchCustoToggle.onValueChanged.AddListener((value) => OnSwitchCustoToggle(value));
			animalTotemButton.onClick.AddListener(OnClickAnimalTotem);

			Debug.Log("Here add the right number of section in scrollsnap");
			scrollsnap.InitScrollSnap(6);
		}

        private void OnClickPrefixName()
        {
			UIManager.Instance.OpenScreen(UIManager.Instance.prefixNamePopUp);
		}

		private void OnClickSufixName(string value)
		{
			Debug.Log("Save name " + value + " here.");
		}

		private void OnEndEditSufixName(string value)
		{
			inputFieldCouldBeSelected = true;
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
			if (EventSystem.current.currentSelectedGameObject == sufixNameInputField.gameObject)
			{
				if (sufixNameInputField.isFocused && inputFieldCouldBeSelected)
                {
					Debug.Log("Do animations for editing input here");
					inputFieldCouldBeSelected = false;
                }
			}
		}

        protected override void OnDestroy()
		{
			base.OnDestroy();

			prefixNameButton.onClick.RemoveListener(OnClickPrefixName);
			sufixNameInputField.onValueChanged.RemoveListener((value) => OnClickSufixName(value));
			sufixNameInputField.onEndEdit.RemoveListener(OnEndEditSufixName);
			switchCustoToggle.onValueChanged.RemoveListener((value) => OnSwitchCustoToggle(value));
			animalTotemButton.onClick.RemoveListener(OnClickAnimalTotem);

		}
	}
}
