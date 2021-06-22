using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TotemAnimal", menuName = "Trashspotter/Totem/TotemAnimal", order = 4)]
public class TotemAnimal : ScriptableObject
{
    [SerializeField] public EFamily family;
    [SerializeField] public string _Name;
    [SerializeField] public Sprite _Image;
    [SerializeField] public string _KeyWord1;
    [SerializeField] public string _KeyWord2;
    [SerializeField] public string _KeyWord3;
    [SerializeField] [TextArea] public string _Info;

}