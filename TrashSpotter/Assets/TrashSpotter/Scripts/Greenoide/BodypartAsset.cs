using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBodypartType
{
    EYES,
    MOUTH,
    TATTOO,
    HAIR,
    TOP_HEAD,
    EARS,
    CLOTH,
    ORNAMENT,
    EAR_BACK,
    HEAD
}

[CreateAssetMenu(fileName = "BodypartAsset", menuName = "Greenoide/BodypartAsset", order = 1)]
public class BodypartAsset : ScriptableObject
{
    public Sprite _Sprite = null;
    public int _Id = 0;
    public EBodypartType _Type = EBodypartType.EYES;
}
