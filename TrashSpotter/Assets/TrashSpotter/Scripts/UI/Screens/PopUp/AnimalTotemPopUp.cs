using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.TrashSpotter
{
    public class AnimalTotemPopUp : Screen
    {
        [Header("Animal Details Settings")]
        [SerializeField] private Image favoriteImage = null;
        [SerializeField] private Image animalImage = null;
        [SerializeField] private Text animalNameText = null;
        [SerializeField] private Text animalDescriptionText = null;
	}
}
