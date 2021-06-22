using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class AssosPopUp : PopUp
    {
        [Header ("General Settings")]
        [SerializeField] private Transform assosButtonContainer = null;
        [SerializeField] private Button backgroundButton = null;
        [SerializeField] private ScrollsnapHandler scrollsnap = null;

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
            InitScrollView();
        }

        private GameObject[] scrollsnapElements;
        private List<Association> assoByCurrentCategory;

        /// <summary>
        /// Init scroll snap, draw asso list by category
        /// </summary>
        private void InitScrollView()
        {
            //reset listener
            if (scrollsnapElements != null)
            {
                for (int i = 0; i < scrollsnapElements.Length; i++)
                {
                    int lClosureIndex = i;
                    scrollsnapElements[lClosureIndex].GetComponent<Button>().onClick.RemoveAllListeners();
                }
            }

            int assoNumber = 0;
            assoByCurrentCategory = new List<Association>();

            foreach (Association asso in associations)
            {
                if (asso.category != currentAssoCategorySelected)
                    continue;

                assoByCurrentCategory.Add(asso);
                assoNumber++;
            }

            scrollsnapElements = scrollsnap.InitScrollSnap(assoNumber);

            for (int i = 0; i < scrollsnapElements.Length; i++)
            {
                int lClosureIndex = i;

                scrollsnapElements[lClosureIndex].GetComponent<Image>().sprite = assoByCurrentCategory[i].logo;
                scrollsnapElements[lClosureIndex].GetComponent<Button>().onClick.AddListener(delegate { OnCLickAssoButton(assoByCurrentCategory[i]); });
            }
        }

        private void EmptyScrollview()
        {
            for (int i = 0; i < assosButtonContainer.childCount; i++)
            {
                assosButtonContainer.GetChild(i).GetComponent<Button>().onClick.RemoveAllListeners();
                Destroy(assosButtonContainer.GetChild(i).gameObject);
            }
        }

        /*

        private void SetPopUpContent()
        {
            GameObject assoButton;

            foreach (Association asso in associations)
            {
                if (asso.category != currentAssoCategorySelected)
                    continue;

                assoButton = Instantiate(assoButtonPrefab, assosButtonContainer);

                assoButton.GetComponent<Image>().sprite = asso.logo;
                assoButton.GetComponent<Button>().onClick.AddListener(delegate { OnCLickAssoButton(asso); });
            }
        }*/

        private void OnCLickAssoButton(Association asso)
        {
            UIManager.Instance.CloseScreen(this);
            UIManager.Instance.OpenAssoDetailsPopUp(UIManager.Instance.assoDetailsPopUp, asso);
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
                assosButtonContainer.GetChild(closureIndex).GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
            }

            backgroundButton.onClick.RemoveListener(OnClickQuit);
        }

    }
}
