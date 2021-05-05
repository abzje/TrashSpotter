using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class ScrollsnapHandler : MonoBehaviour
    {
		[SerializeField] private ToggleGroup paginationToggleGroup = null;
		[SerializeField] private Scrollbar scrollBar = null;
		[SerializeField] private GameObject content = null;
		[SerializeField] private Toggle pageTogglePrefab = null;
		[SerializeField] private GameObject contentChildPrefab = null;

		private Toggle[] toggles;
		private float[] pos;

		private int togNumber;
		private float scroll_pos = 0;
		private float distance;

		private bool canScroll = false;


        /// <summary>
        /// Instantiate all toggle and content
        /// Initialize position of sections
        /// Set the first toggle as default toggle activated
        /// </summary>
        public void InitScrollSnap(int number)
		{
			//Init number of toggle and section
			toggles = new Toggle[number];
			pos = new float[number];
			distance = 1 / (pos.Length - 1f);

			Toggle tog;

			for (int i = 0; i < number; i++)
			{

				tog = Instantiate(pageTogglePrefab, paginationToggleGroup.transform);
				toggles[i] = tog;

				//Instantiate(contentChildPrefab, content.transform);

				//toggles[i].onValueChanged.AddListener((value) => WhichTogClicked(tog));

				pos[i] = distance * i;
			}
			
			toggles[0].onValueChanged.AddListener((value) => WhichTogClicked(toggles[0]));
			toggles[1].onValueChanged.AddListener((value) => WhichTogClicked(toggles[1]));
			toggles[2].onValueChanged.AddListener((value) => WhichTogClicked(toggles[2]));

			//Init first toggle as default selected toggle
			WhichTogClicked(toggles[0]);
			toggles[0].Select();

			scrollBar.gameObject.SetActive(true);
			canScroll = true;
		}

		/// <summary>
		/// Set the scroll position as the position assigne of the toggle clicked
		/// It is called inside each toggle component inside the editor and in the initialize scrollsnap method
		/// </summary>
		/// <param name="tog">The toggle that has been clicked</param>
		public void WhichTogClicked(Toggle tog)
		{
			for (int i = 0; i < toggles.Length; i++)
			{
				if (toggles[i] == tog)
				{
					togNumber = i;
					scroll_pos = (pos[togNumber]);
				}
			}
		}

		private void Update()
        {

			if (!canScroll) return;

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

			
			Debug.Log(content.transform.childCount + "    " +paginationToggleGroup.transform.childCount);

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
	}
}
