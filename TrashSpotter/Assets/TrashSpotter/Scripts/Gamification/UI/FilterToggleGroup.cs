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

        public static Action <EFamily> OnFilterClicked;

        private void Start()
        {
            guardianFilter.onValueChanged.AddListener((value) => OnClickFiler(EFamily.GUARDIANS));
            sentriesFilter.onValueChanged.AddListener((value) => OnClickFiler(EFamily.SENTRIES));
            navigatorFilter.onValueChanged.AddListener((value) => OnClickFiler(EFamily.NAVIGATORS));
            allFilter.onValueChanged.AddListener((value) => OnClickFiler(EFamily.COMMON));
        }

        private void OnClickFiler(EFamily filter)
        {
            OnFilterClicked?.Invoke(filter);
        }

        private void OnDestroy()
        {
            guardianFilter.onValueChanged.RemoveListener((value) => OnClickFiler(EFamily.GUARDIANS));
            sentriesFilter.onValueChanged.RemoveListener((value) => OnClickFiler(EFamily.SENTRIES));
            navigatorFilter.onValueChanged.RemoveListener((value) => OnClickFiler(EFamily.NAVIGATORS));
            allFilter.onValueChanged.RemoveListener((value) => OnClickFiler(EFamily.COMMON));
        }
    }
}
