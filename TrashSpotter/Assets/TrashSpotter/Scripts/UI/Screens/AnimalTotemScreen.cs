using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.TrashSpotter
{
    public class AnimalTotemScreen : Screen
    {
		private static AnimalTotemScreen instance;
		public static AnimalTotemScreen Instance => instance;

		private void Awake()
		{
			if (instance)
			{
				Destroy(gameObject);
				return;
			}

			instance = this;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			if (this == instance) instance = null;

		}
	}
}
