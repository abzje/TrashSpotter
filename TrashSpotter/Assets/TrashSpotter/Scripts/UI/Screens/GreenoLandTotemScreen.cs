using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.TrashSpotter
{
    public class GreenoLandTotemScreen : Screen
    {
		private static GreenoLandTotemScreen instance;
		public static GreenoLandTotemScreen Instance => instance;

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
