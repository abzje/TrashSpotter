using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class ScrollsnapHandler : MonoBehaviour
    {
		[SerializeField] private Transform paginationToggleGroup = null;
		[SerializeField] private Scrollbar scrollBar = null;
		[SerializeField] private GameObject content = null;
		[SerializeField] private Toggle pageTogglePrefab = null;
		[SerializeField] private GameObject sectionPrefab = null;
		[SerializeField] private GameObject elementInSectionPrefab = null;
		[SerializeField] private float numberElementPerSection = 0;

		private Toggle[] paginationToggles;
		private float[] pos;
		private float scroll_pos = 0;
		private float distance;
		private int sectioNumber;

		/// <summary>
		/// Instantiate all toggle and content
		/// Initialize position of sections
		/// Set the first toggle as default toggle activated
		/// </summary>
		/// <param name="number">The number of element inside section you can snap on</param>
		public void InitScrollSnap(int number)
		{
			sectioNumber = (int)Mathf.Ceil(number / numberElementPerSection);

			//Init number of toggle and section
			paginationToggles = new Toggle[sectioNumber];
			pos = new float[sectioNumber];
			distance = 1 / ((float)sectioNumber - 1);

			GameObject lCurrentSection;

			//Section and toggle creation
            for (int i = 0; i < sectioNumber; i++)
            {
				int lClosureIndex = i;

				paginationToggles[lClosureIndex] = Instantiate(pageTogglePrefab, paginationToggleGroup);
				paginationToggles[lClosureIndex].onValueChanged.AddListener((value) => WhichTogClicked(paginationToggles[lClosureIndex]));

				lCurrentSection = Instantiate(sectionPrefab, content.transform);

				pos[lClosureIndex] = distance * lClosureIndex;

				//Element in section creation
                for (int j = 0; j < numberElementPerSection; j++)
                {
					Instantiate(elementInSectionPrefab, lCurrentSection.transform);
				}
			}

			//Init first toggle as default selected toggle
			WhichTogClicked(paginationToggles[0]);
			paginationToggles[0].Select();
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
					paginationToggleGroup.GetChild(i).localScale = Vector2.Lerp(paginationToggleGroup.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);

					for (int j = 0; j < pos.Length; j++)
					{
						if (j != i)
						{
							paginationToggleGroup.GetChild(j).localScale = Vector2.Lerp(paginationToggleGroup.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
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
