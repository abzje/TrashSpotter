using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class GreenoLandCustomisationScreen : Screen
    {
		[SerializeField] private ToggleGroup toggleGroup = null;
		[SerializeField] private Scrollbar scrollBar = null;
		[SerializeField] private GameObject content = null;

		[SerializeField] private int sectionNumber = 1;
		
		private Toggle[] toggles = null;

		private float scroll_pos = 0;
		private float[] pos;
		private int togNumber;

		private float distance;

		private static GreenoLandCustomisationScreen instance;
		public static GreenoLandCustomisationScreen Instance => instance;

		private void Awake()
		{
			if (instance)
			{
				Destroy(gameObject);
				return;
			}

			instance = this;
		}

        private void Start()
        {
			InitScrollSnap();
		}

		private void InitScrollSnap()
        {
			toggles = toggleGroup.GetComponentsInChildren<Toggle>();
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
					toggleGroup.transform.GetChild(i).localScale = Vector2.Lerp(toggleGroup.transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);

					for (int j = 0; j < pos.Length; j++)
					{
						if (j != i)
						{
							toggleGroup.transform.GetChild(j).localScale = Vector2.Lerp(toggleGroup.transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
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

		protected override void OnDestroy()
		{
			base.OnDestroy();

			if (this == instance) instance = null;

		}
	}
}
