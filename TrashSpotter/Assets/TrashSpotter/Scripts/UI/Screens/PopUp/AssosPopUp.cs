using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class AssosPopUp : PopUp
    {
        [Header ("General Settings")]
        [SerializeField] private Transform assosButtonContainer = null;
        [SerializeField] private GameObject assoButtonPrefab = null;

        [Header ("Category Image")]
        [SerializeField] private Image assoCategoryImage = null;
        [SerializeField] private Sprite humanCategoryImage = null;
        [SerializeField] private Sprite agricultureCategoryImage = null;
        [SerializeField] private Sprite ecologyCategoryImage = null;
        [SerializeField] private Sprite industryCategoryImage = null;
        [SerializeField] private Sprite energyCategoryImage = null;

        public enum enAssoCategory { Human, Agriculture, Ecology, Industry, Energy };
        [HideInInspector] public enAssoCategory currentAssoCategorySelected;

        public void SetPopUp(enAssoCategory assoCategory)
        {

            switch (assoCategory)
            {
                case enAssoCategory.Human:
                    assoCategoryImage.sprite = humanCategoryImage;
                    break;
                case enAssoCategory.Agriculture:
                    assoCategoryImage.sprite = agricultureCategoryImage;
                    break;
                case enAssoCategory.Ecology:
                    assoCategoryImage.sprite = ecologyCategoryImage;
                    break;
                case enAssoCategory.Industry:
                    assoCategoryImage.sprite = industryCategoryImage;
                    break;
                case enAssoCategory.Energy:
                    assoCategoryImage.sprite = energyCategoryImage;
                    break;
                default:
                    Debug.LogWarning("Wrong category");
                    break;
            }
        }

        private void Start()
        {
            //nombre à remplacer par le nombre d'asso dans cette catégorie

            GameObject assoButton;

            for (int i = 0; i < 10; i++)
            {
                assoButton = Instantiate(assoButtonPrefab, assosButtonContainer);
                //Set sprite here
                //assoButton.GetComponent<Image>().sprite = 

                assoButton.GetComponent<Button>().onClick.AddListener(delegate { OnCLickAssoButton(assoButton.transform); });
            }
        }

        private void OnCLickAssoButton(Transform assoButton)
        {
            UIManager.Instance.CloseScreen(this);
            UIManager.Instance.OpenAssoDetailsPopUp(UIManager.Instance.assoDetailsPopUp);
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
