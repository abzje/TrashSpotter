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

        public static Action <EFamily> OnFilterClicked;

        private void Start()
        {
            guardianFilter.onValueChanged.AddListener((value) => OnClickFiler(EFamily.GUARDIANS, guardianFilter));
            sentriesFilter.onValueChanged.AddListener((value) => OnClickFiler(EFamily.SENTRIES, sentriesFilter));
            navigatorFilter.onValueChanged.AddListener((value) => OnClickFiler(EFamily.NAVIGATORS, navigatorFilter));
        }

        private void OnClickFiler(EFamily filter, Toggle toggle)
        {
            OnFilterClicked?.Invoke(filter);
            toggle.transform.GetChild(0).gameObject.SetActive(toggle.isOn);
        }

        private void OnDestroy()
        {
            guardianFilter.onValueChanged.RemoveListener((value) => OnClickFiler(EFamily.GUARDIANS, guardianFilter));
            sentriesFilter.onValueChanged.RemoveListener((value) => OnClickFiler(EFamily.SENTRIES, sentriesFilter));
            navigatorFilter.onValueChanged.RemoveListener((value) => OnClickFiler(EFamily.NAVIGATORS, navigatorFilter));
        }
    }
}
