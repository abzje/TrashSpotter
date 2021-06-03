using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBodypartType
{
    HEAD,
    TATTOO,
    EYES,
    MOUTH,
    HAIR,
    TOP_HEAD,
    EARS,
    CLOTHES,
    ORNAMENT
}

public enum EBodypartFamily
{
    COMMON,
    GUARDIANS,
    NAVIGATORS,
    SENTRIES
}

[CreateAssetMenu(fileName = "BodypartAsset", menuName = "Trashspotter/Greenoide/BodypartAsset", order = 1)]
public class BodypartAsset : ScriptableObject
{
    public Sprite _Sprite = null;
    public int _Id = 0;
    public EBodypartType _Type = EBodypartType.EYES;

    public EBodypartFamily _Family = EBodypartFamily.COMMON;
}
