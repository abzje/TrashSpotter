using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TotemAnimal", menuName = "Trashspotter/Totem/TotemAnimal", order = 4)]
public class TotemAnimal : ScriptableObject
{
    [SerializeField] EFamily _Family;
    [SerializeField] string _Name;
    [SerializeField] Image _Image;
    [SerializeField] string _KeyWord1;
    [SerializeField] string _KeyWord2;
    [SerializeField] string _KeyWord3;
    [SerializeField] string _Info;

}