﻿using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class ScrollsnapHandler : MonoBehaviour
    {
		[SerializeField] private Transform paginationToggleGroup = null;
		[SerializeField] private Scrollbar scrollBar = null;
		[SerializeField] private GameObject content = null;
		[SerializeField] private Toggle pageTogglePrefab = null;
		[SerializeField] private GameObject contentChildPrefab = null;

		private Toggle[] toggles;
		private float[] pos;
		private float scroll_pos = 0;
		private float distance;

		/// <summary>
		/// Instantiate all toggle and content
		/// Initialize position of sections
		/// Set the first toggle as default toggle activated
		/// </summary>
		/// <param name="number">The number of section you can snap on</param>
		public void InitScrollSnap(int number)
		{
			//Init number of toggle and section
			toggles = new Toggle[number];
			pos = new float[number];
			distance = 1 / ((float)number - 1);

			for (int i = 0; i < number; i++)
			{
				//this index is use to prevent the closure bug
				int closureIndex = i;

				toggles[closureIndex] = Instantiate(pageTogglePrefab, paginationToggleGroup);
				toggles[closureIndex].onValueChanged.AddListener((value) => WhichTogClicked(toggles[closureIndex]));

				Instantiate(contentChildPrefab, content.transform);

				pos[closureIndex] = distance * closureIndex;
			}

			//Init first toggle as default selected toggle
			WhichTogClicked(toggles[0]);
			toggles[0].Select();
		}

		/// <summary>
		/// Set the scroll position as the position assigne of the toggle clicked
		/// It is called inside each toggle component inside the editor and in the initialize scrollsnap method
		/// </summary>
		/// <param name="tog">The toggle that has been clicked</param>
		public void WhichTogClicked(Toggle tog)
		{
			for (int i = 0; i < 3; i++)
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
	}
}
