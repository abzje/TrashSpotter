using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class AnimalTotemPopUp : PopUp
    {
        [Header("Animal Details Settings")]
        [SerializeField] private Image favoriteImage = null;
        [SerializeField] private Image animalImage = null;
        [SerializeField] private Text animalNameText = null;
        [SerializeField] private Text animalDescriptionText = null;

        [Header("General Settings")]
        [SerializeField] private Button backgroundButton = null;

        private void Start()
        {
            backgroundButton.onClick.AddListener(OnClickQuit);
        }

        private void OnClickQuit()
        {
            UIManager.Instance.ClosePopUp(this);
        }

        protected override void OnDestroy()
        {
            backgroundButton.onClick.RemoveListener(OnClickQuit);
        }
    }
}
