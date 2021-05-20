using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class AssosPopUp : PopUp
    {
        [Header ("General Settings")]
        [SerializeField] Transform assosButtonContainer = null;
        [SerializeField] GameObject assoButtonPrefab = null;

        [Header ("Category Image")]
        [SerializeField] Image assoCategoryImage = null;
        [SerializeField] Sprite humanCategoryImage = null;
        [SerializeField] Sprite agricultureCategoryImage = null;
        [SerializeField] Sprite ecologyCategoryImage = null;
        [SerializeField] Sprite industryCategoryImage = null;
        [SerializeField] Sprite energyCategoryImage = null;
        [HideInInspector] public EAssociationCategory currentAssoCategorySelected;

        [Header ("Associations List")]
        [SerializeField] List<Association> associations;


        public void SetPopUp(EAssociationCategory assoCategory)
        {
            switch (assoCategory)
            {
                case EAssociationCategory.HUMAN:
                    assoCategoryImage.sprite = humanCategoryImage;
                    break;
                case EAssociationCategory.AGRICULTURE:
                    assoCategoryImage.sprite = agricultureCategoryImage;
                    break;
                case EAssociationCategory.ECOLOGIE:
                    assoCategoryImage.sprite = ecologyCategoryImage;
                    break;
                case EAssociationCategory.INDUSTRY:
                    assoCategoryImage.sprite = industryCategoryImage;
                    break;
                case EAssociationCategory.ENERGY:
                    assoCategoryImage.sprite = energyCategoryImage;
                    break;
                default:
                    Debug.LogWarning("Wrong category");
                    break;
            }

            currentAssoCategorySelected = assoCategory;
            SetPopUpContent();
        }

        private void SetPopUpContent()
        {
            
            GameObject assoButton;

            foreach(Association asso in associations)
            {
                if (asso._Category != currentAssoCategorySelected)
                    continue;

                assoButton = Instantiate(assoButtonPrefab, assosButtonContainer);

                assoButton.GetComponent<Button>().onClick.AddListener(delegate { OnCLickAssoButton(asso); });
            }
        }

        private void OnCLickAssoButton(Association assoc)
        {
            UIManager.Instance.CloseScreen(this);
            UIManager.Instance.OpenAssoDetailsPopUp(UIManager.Instance.assoDetailsPopUp, assoc);
        }

        private void OnDisable()
        {
            for (int i = 0; i < assosButtonContainer.childCount; i++)
            {
                assosButtonContainer.GetChild(i).GetComponent<Button>().onClick.RemoveAllListeners();
            }
        }

        override protected void OnDestroy()
        {
            base.OnDestroy();

            for (int i = 0; i < assosButtonContainer.childCount; i++)
            {
                int closureIndex = i;
                assosButtonContainer.GetChild(closureIndex).GetComponent<Button>().onClick.RemoveAllListeners();
            }
        }

    }
}
