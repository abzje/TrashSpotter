using System;
using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class FilterToggleGroup : MonoBehaviour
    {
        [SerializeField] private Toggle guardianFilter = null;
        [SerializeField] private Toggle sentriesFilter = null;
        [SerializeField] private Toggle navigatorFilter = null;
        [SerializeField] private Toggle allFilter = null;

        public static Action <EBodypartFamily> OnFilterClicked;

        private void Start()
        {
            guardianFilter.onValueChanged.AddListener((value) => OnClickFiler(EBodypartFamily.GUARDIANS));
            sentriesFilter.onValueChanged.AddListener((value) => OnClickFiler(EBodypartFamily.SENTRIES));
            navigatorFilter.onValueChanged.AddListener((value) => OnClickFiler(EBodypartFamily.NAVIGATORS));
            allFilter.onValueChanged.AddListener((value) => OnClickFiler(EBodypartFamily.COMMON));
        }

        private void OnClickFiler(EBodypartFamily filter)
        {
            OnFilterClicked?.Invoke(filter);
        }

        private void OnDestroy()
        {
            guardianFilter.onValueChanged.RemoveListener((value) => OnClickFiler(EBodypartFamily.GUARDIANS));
            sentriesFilter.onValueChanged.RemoveListener((value) => OnClickFiler(EBodypartFamily.SENTRIES));
            navigatorFilter.onValueChanged.RemoveListener((value) => OnClickFiler(EBodypartFamily.NAVIGATORS));
            allFilter.onValueChanged.RemoveListener((value) => OnClickFiler(EBodypartFamily.COMMON));
        }
    }
}
