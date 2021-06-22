using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EAltarType
{
    TIKI,
    TOTEM,
    MASK,
}

[CreateAssetMenu(fileName = "Altar", menuName = "Trashspotter/Altar/Altar", order = 4)]
public class Altar : ScriptableObject
{
    public EAltarType type = EAltarType.TIKI;
    public Sprite sprite = null;
    public int price = 10;
    public int level = 1;
}
