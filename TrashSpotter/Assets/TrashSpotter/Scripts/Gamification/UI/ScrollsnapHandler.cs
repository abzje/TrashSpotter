using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class ScrollsnapHandler : MonoBehaviour
    {
		[SerializeField] protected Scrollbar scrollBar = null;
		[SerializeField] protected GameObject content = null;
		[SerializeField] protected GameObject sectionPrefab = null;
		[SerializeField] protected GameObject elementInSectionPrefab = null;
		[SerializeField] protected int numberElementPerSection = 0;

		protected GameObject[] elements;
		protected float[] pos;
		protected float scroll_pos = 0;
		protected float distance;
		protected int sectioNumber;

		
		private bool hasBeenInitialized;

        protected virtual void Start()
        {
			hasBeenInitialized = false;
		}

        protected virtual void EmptyContent()
        {
			for (int i = 0; i < content.transform.childCount; i++)
            {
				Destroy(content.transform.GetChild(i).gameObject);
			}
		}

		/// <summary>
		/// Instantiate all toggle and content
		/// Initialize position of sections
		/// Set the first toggle as default toggle activated
		/// </summary>
		/// <param name="number">The number of element inside section you can snap on</param>
		public virtual GameObject[] InitScrollSnap(int number)
		{
			EmptyContent();

			int sectionNumber = (int)Mathf.Ceil(number / (float)numberElementPerSection);
			sectioNumber = Mathf.Clamp(sectionNumber, 1, sectionNumber);

			//Init number sections
			elements = new GameObject[number];
			pos = new float[sectioNumber];
			distance = 1 / ((float)sectioNumber - 1);

			CreateSections(number);

			if (number == 0) return new GameObject[0];

			hasBeenInitialized = true;
			return elements;
		}

		protected virtual void CreateSections(int number)
        {
			GameObject lCurrentSection;
			GameObject lElement;

			for (int i = 0; i < sectioNumber; i++)
			{
				int lIClosureIndex = i;

				lCurrentSection = Instantiate(sectionPrefab, content.transform);

				pos[lIClosureIndex] = distance * lIClosureIndex;

				//Element in section creation
				for (int j = 0; j < numberElementPerSection; j++)
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

		protected virtual void Update()
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

			DoScaleEffect();
		}

		protected virtual void DoScaleEffect()
        {
			for (int i = 0; i < pos.Length; i++)
			{
				if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
				{
					content.transform.GetChild(i).localScale = Vector2.Lerp(content.transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);

					for (int j = 0; j < pos.Length; j++)
					{
						if (j != i)
						{
							content.transform.GetChild(j).localScale = Vector2.Lerp(content.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
						}
					}
				}
			}
		}
    }
}
