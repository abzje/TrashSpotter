using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class ScrollsnapWithToggle : ScrollsnapHandler
    {
		[SerializeField] private Transform paginationToggleGroup = null;
		[SerializeField] private Scrollbar scrollBar = null;
		[SerializeField] private GameObject content = null;
		[SerializeField] private Toggle pageTogglePrefab = null;
		[SerializeField] private GameObject sectionPrefab = null;
		[SerializeField] private GameObject elementInSectionPrefab = null;
		[SerializeField] private int numberElementPerSection = 0;

		private Toggle[] paginationToggles;
		private GameObject[] elements;
		private float[] pos;
		private float scroll_pos = 0;
		private float distance;
		private int sectioNumber;

		private int maxNumOfElementInSection = 12;
		private bool hasBeenInitialized = false;

        private void Start()
        {
			hasBeenInitialized = false;
		}

        private void emptyContent()
        {
			for (int i = 0; i < content.transform.childCount; i++)
            {
				Destroy(content.transform.GetChild(i).gameObject);
			}

			if (paginationToggleGroup == null) return;

			for (int i = 0; i < paginationToggleGroup.childCount; i++)
			{
				Destroy(paginationToggleGroup.GetChild(i).gameObject);
			}
		}

		/// <summary>
		/// Instantiate all toggle and content
		/// Initialize position of sections
		/// Set the first toggle as default toggle activated
		/// </summary>
		/// <param name="number">The number of element inside section you can snap on</param>
		public GameObject[] InitScrollSnap(int number, bool hasToggle = true)
		{
			emptyContent();

			int sectionNumber = (int)Mathf.Ceil(number / (float)numberElementPerSection);
			sectioNumber = Mathf.Clamp(sectionNumber, 1, sectionNumber);

			if (hasToggle)
            {
				maxNumOfElementInSection = 1;
			}
			else
            {
				maxNumOfElementInSection = 12;
            }

			//Init number of toggle and section
			paginationToggles = new Toggle[sectioNumber];
			elements = new GameObject[number];
			pos = new float[sectioNumber];
			distance = 1 / ((float)sectioNumber - 1);

			GameObject lCurrentSection;
			GameObject lElement;

			//Section and toggle creation
            for (int i = 0; i < sectioNumber; i++)
            {
				int lIClosureIndex = i;

				if (hasToggle)
                {
					paginationToggles[lIClosureIndex] = Instantiate(pageTogglePrefab, paginationToggleGroup);
					paginationToggles[lIClosureIndex].onValueChanged.AddListener((value) => WhichTogClicked(paginationToggles[lIClosureIndex]));
				}

				lCurrentSection = Instantiate(sectionPrefab, content.transform);

				pos[lIClosureIndex] = distance * lIClosureIndex;

				//Element in section creation
				for (int j = 0; j < maxNumOfElementInSection; j++)
                {
					lElement = Instantiate(elementInSectionPrefab, lCurrentSection.transform);

					if (j < numberElementPerSection)
                    {
						if (j + (lIClosureIndex * numberElementPerSection) < number)
						{
							elements[j + (lIClosureIndex * numberElementPerSection)] = lElement;
						}
					}
				}
			}

			if (number == 0) return new GameObject[0];

			if (hasToggle)
            {
				//Init first toggle as default selected toggle
				WhichTogClicked(paginationToggles[0]);
				paginationToggles[0].Select();
			}

			hasBeenInitialized = true;

			return elements;
		}

		/// <summary>
		/// Set the scroll position as the position assigne of the toggle clicked
		/// It is called inside each toggle component inside the editor and in the initialize scrollsnap method
		/// </summary>
		/// <param name="tog">The toggle that has been clicked</param>
		public void WhichTogClicked(Toggle tog)
		{

			for (int i = 0; i < sectioNumber; i++)
			{
				if (paginationToggleGroup.GetChild(i).GetComponent<Toggle>().GetInstanceID() == tog.GetInstanceID())
				{
					scroll_pos = (pos[i]);
				}
			}
		}

		private void Update()
        {
			if (!hasBeenInitialized) return;

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
					if (paginationToggleGroup != null) paginationToggleGroup.GetChild(i).localScale = Vector2.Lerp(paginationToggleGroup.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);

					for (int j = 0; j < pos.Length; j++)
					{
						if (j != i)
						{
							if (paginationToggleGroup != null) paginationToggleGroup.GetChild(j).localScale = Vector2.Lerp(paginationToggleGroup.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
							content.transform.GetChild(j).localScale = Vector2.Lerp(content.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
						}
					}
				}
			}
		}

        private void OnDisable()
        {
            foreach (Toggle toggle in paginationToggles)
            {
				toggle.onValueChanged.RemoveListener((value) => WhichTogClicked(toggle));
			}
        }
    }
}
