using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class AssosPopUp : PopUpFillableDynamicaly
    {
        [Header ("General Settings")]
        [SerializeField] private Transform assosButtonContainer = null;

        [Header ("Category Image")]
        [SerializeField] private Image assoCategoryImage = null;
        [SerializeField] private Sprite humanCategoryImage = null;
        [SerializeField] private Sprite agricultureCategoryImage = null;
        [SerializeField] private Sprite ecologyCategoryImage = null;
        [SerializeField] private Sprite industryCategoryImage = null;
        [SerializeField] private Sprite energyCategoryImage = null;

        public override void SetPopUp(enAssoCategory assoCategory)
        {
            base.SetPopUp(assoCategory);

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
            for (int i = 0; i < assosButtonContainer.childCount; i++)
            {
                int lClosureIndex = i;
                assosButtonContainer.GetChild(lClosureIndex).GetComponent<Button>().onClick.AddListener(delegate { 
                    OnCLickAssoButton(assosButtonContainer.GetChild(lClosureIndex)); 
                });
            }
        }

        private void OnCLickAssoButton(Transform assoButton)
        {
            UIManager.Instance.CloseScreen(this);
            UIManager.Instance.OpenScreen(UIManager.Instance.assoDetailsPopUp);
        }

        private void OnDisable()
        {
            for (int i = 0; i < assosButtonContainer.childCount; i++)
            {
                assosButtonContainer.GetChild(i).GetComponent<Button>().onClick.RemoveAllListeners();
            }
        }
    }
}
