using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class AssosPopUp : PopUp
    {
        [Header ("General Settings")]
        [SerializeField] private Transform assosButtonContainer = null;
        [SerializeField] private GameObject assoButtonPrefab = null;
        [SerializeField] private Button backgroundButton = null;

        [Header ("Category Image")]
        [SerializeField] private Image assoCategoryImage = null;
        [SerializeField] private Sprite humanCategoryImage = null;
        [SerializeField] private Sprite agricultureCategoryImage = null;
        [SerializeField] private Sprite ecologyCategoryImage = null;
        [SerializeField] private Sprite industryCategoryImage = null;
        [SerializeField] private Sprite energyCategoryImage = null;

        [Header("Associations List")]
        [SerializeField] List<Association> associations = null;

        [HideInInspector] public EAssociationCategory currentAssoCategorySelected;


        private void Start()
        {
            backgroundButton.onClick.AddListener(OnClickQuit);
        }

        private void OnClickQuit()
        {
            UIManager.Instance.ClosePopUp(this);
        }

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

        private void EmptyScrollview()
        {
            for (int i = 0; i < assosButtonContainer.childCount; i++)
            {
                assosButtonContainer.GetChild(i).GetComponent<Button>().onClick.RemoveAllListeners();
                Destroy(assosButtonContainer.GetChild(i).gameObject);
            }
        }

        private void SetPopUpContent()
        {
            GameObject assoButton;

            foreach (Association asso in associations)
            {
                if (asso._Category != currentAssoCategorySelected)
                    continue;

                assoButton = Instantiate(assoButtonPrefab, assosButtonContainer);

                assoButton.GetComponent<Image>().sprite = asso._Logo;
                assoButton.GetComponent<Button>().onClick.AddListener(delegate { OnCLickAssoButton(asso); });
            }
        }

        private void OnCLickAssoButton(Association assoc)
        {
            UIManager.Instance.CloseScreen(this);
            UIManager.Instance.OpenAssoDetailsPopUp(UIManager.Instance.assoDetailsPopUp, assoc);
        }

        public override void Close()
        {
            base.Close();
            EmptyScrollview();
        }

        override protected void OnDestroy()
        {
            base.OnDestroy();

            for (int i = 0; i < assosButtonContainer.childCount; i++)
            {
                int closureIndex = i;
                assosButtonContainer.GetChild(closureIndex).GetComponent<Button>().onClick.RemoveAllListeners();
            }

            backgroundButton.onClick.RemoveListener(OnClickQuit);
        }

    }
}
