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
		
		[Header("Greenoid settings")]
		[SerializeField] private GameObject greenoidCusto = null;
		[SerializeField] private ToggleGroup filterToggleGroup = null;

		[Header("Totem settings")]
		[SerializeField] private GameObject totemCusto = null;
		[SerializeField] private Button animalTotemButton = null;

		[Header("Scrollsnap settings")]
		[SerializeField] private ToggleGroup paginationToggleGroup = null;
		[SerializeField] private Scrollbar scrollBar = null;
		[SerializeField] private GameObject content = null;
		[SerializeField] private int sectionNumber = 1;
		
		private Toggle[] toggles = null;

		private float scroll_pos = 0;
		private float[] pos;
		private int togNumber;

		private float distance;

		private bool inputFieldCouldBeSelected;

		private void Start()
		{

			inputFieldCouldBeSelected = true;
			prefixNameButton.onClick.AddListener(OnClickPrefixName);
			sufixNameInputField.onValueChanged.AddListener((value) => OnClickSufixName(value));
			sufixNameInputField.onEndEdit.AddListener(OnEndEditSufixName);
			switchCustoToggle.onValueChanged.AddListener((value) => OnSwitchCustoToggle(value));

			InitScrollSnap();
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

			UpdateScrollSnap();
		}

		#region Scrollsnap
		private void InitScrollSnap()
        {
			toggles = paginationToggleGroup.GetComponentsInChildren<Toggle>();
			pos = new float[sectionNumber];

			//Init first toggle as default selected toggle
			WhichTogClicked(toggles[0]);
			toggles[0].Select();

			distance = 1 / (pos.Length - 1f);

			for (int i = 0; i < pos.Length; i++)
			{
				pos[i] = distance * i;
			}
		}

		private void UpdateScrollSnap()
        {
			if (Input.GetMouseButton(0))
			{
				scroll_pos = scrollBar.value;
			}
			else
			{
				for (int i = 0; i < pos.Length; i++)
				{
					if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
					{
						scrollBar.value = Mathf.Lerp(scrollBar.value, pos[i], 0.1f);
					}
				}
			}

			for (int i = 0; i < pos.Length; i++)
			{
				if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
				{
					content.transform.GetChild(i).localScale = Vector2.Lerp(content.transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
					paginationToggleGroup.transform.GetChild(i).localScale = Vector2.Lerp(paginationToggleGroup.transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);

					for (int j = 0; j < pos.Length; j++)
					{
						if (j != i)
						{
							paginationToggleGroup.transform.GetChild(j).localScale = Vector2.Lerp(paginationToggleGroup.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
							content.transform.GetChild(j).localScale = Vector2.Lerp(content.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
						}
					}
				}
			}
		}

		public void WhichTogClicked(Toggle tog)
		{
			tog.transform.name = "clicked";
			for (int i = 0; i < toggles.Length; i++)
			{
				if (toggles[i] != tog) toggles[i].name = ".";
				else
                {
					togNumber = i;
					scroll_pos = (pos[togNumber]);
				}
			}
		}

#endregion

        protected override void OnDestroy()
		{
			base.OnDestroy();

			prefixNameButton.onClick.RemoveListener(OnClickPrefixName);
			sufixNameInputField.onValueChanged.RemoveListener((value) => OnClickSufixName(value));
			sufixNameInputField.onEndEdit.RemoveListener(OnEndEditSufixName);
			switchCustoToggle.onValueChanged.RemoveListener((value) => OnSwitchCustoToggle(value));

		}
	}
}
