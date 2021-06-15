using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Com.TrashSpotter
{
    public class AnimalTotemPopUp : PopUp
    {
        [Header("Animal Details Settings")]
        [SerializeField] private Image favoriteImage = null;
        [SerializeField] private Image animalImage = null;
        [SerializeField] private Text animalNameText = null;
        [SerializeField] private Text animalKeyword1Text = null;
        [SerializeField] private Text animalKeyword2Text = null;
        [SerializeField] private Text animalKeyword3Text = null;
        [SerializeField] private Text animalDescriptionText = null;

        [Header("General Settings")]
        [SerializeField] private Button backgroundButton = null;
        
        [Header("Content")]
        [SerializeField] private GreenoideManager greenoide = null;

        public override void Open()
        {
            base.Open();
            SetTotemInfos(greenoide._Totem);
        }

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

        public void SetTotemInfos(TotemAnimal totem)
        {
            //animalImage = totem._Image;
            animalNameText.text = totem._Name;
            animalKeyword1Text.text = totem._KeyWord1;
            animalKeyword2Text.text = totem._KeyWord2;
            animalKeyword3Text.text = totem._KeyWord3;
            animalDescriptionText.text = totem._Info;
        }
    }
}
