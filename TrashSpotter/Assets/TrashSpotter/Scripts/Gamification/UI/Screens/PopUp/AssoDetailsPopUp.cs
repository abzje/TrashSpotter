using System;
using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class AssoDetailsPopUp : PopUp
    {
        [SerializeField] private Button backgroundButton = null;
        [SerializeField] private Image assoImage = null;
        [SerializeField] private Text assoNameText = null;
        [SerializeField] private Text presentationText = null;
        [SerializeField] private Text actionsText = null;


        public void SetPopUp(Association assoc)
        {
            assoImage.sprite = assoc.logo;
            assoNameText.text = assoc.assoName;
            presentationText.text = assoc.presentation;
            actionsText.text = assoc.actions;
        }

        private void Start()
        {
            backgroundButton.onClick.AddListener(OnClickQuit);
        }

        private void OnClickQuit()
        {
            UIManager.Instance.ClosePopUp(this);
        }

        override protected void OnDestroy()
        {
            backgroundButton.onClick.RemoveListener(OnClickQuit);
        }
    }
}
