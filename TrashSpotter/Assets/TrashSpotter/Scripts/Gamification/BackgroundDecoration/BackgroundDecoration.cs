using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EDecorationType
{
    TIKI,
    TOTEM,
    MASK,
    TRIBUTs
}

[CreateAssetMenu(fileName = "BackgroundDecoration", menuName = "Trashspotter/BackgroundDecoration/BackgroundDecoration", order = 4)]
public class BackgroundDecoration : ScriptableObject
{
    public EDecorationType type = EDecorationType.TIKI;
    public Sprite sprite = null;
    public int price = 10;
}
