using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.TrashSpotter
{
    public class GreenoLandCustomisationScreen : Screen
    {
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

		protected override void OnDestroy()
		{
			base.OnDestroy();

			if (this == instance) instance = null;

		}
	}
}
