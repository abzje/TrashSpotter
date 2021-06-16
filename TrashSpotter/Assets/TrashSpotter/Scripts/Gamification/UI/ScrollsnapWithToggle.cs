using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class ScrollsnapWithToggle : ScrollsnapHandler
    {
		[Header("Toggle Settings")]
		[SerializeField] private Transform paginationToggleGroup = null;
		[SerializeField] private Toggle pageTogglePrefab = null;

		private Toggle[] paginationToggles;

        protected override void Start()
        {
			base.Start();
			maxNumOfElementInSection = 12;
		}

        override protected void EmptyContent()
        {
			base.EmptyContent();

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
		public override GameObject[] InitScrollSnap(int number)
		{
			base.InitScrollSnap(number);

			//Init first toggle as default selected toggle
			WhichTogClicked(paginationToggles[0]);
			paginationToggles[0].Select();

			return elements;
		}

        protected override void CreateSections(int number)
        {
			paginationToggles = new Toggle[sectioNumber];

			GameObject lCurrentSection;
			GameObject lElement;

			//Section and toggle creation
			for (int i = 0; i < sectioNumber; i++)
			{
				int lIClosureIndex = i;

				paginationToggles[lIClosureIndex] = Instantiate(pageTogglePrefab, paginationToggleGroup);
				paginationToggles[lIClosureIndex].onValueChanged.AddListener((value) => WhichTogClicked(paginationToggles[lIClosureIndex]));

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

        protected override void DoScaleEffect()
        {
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
