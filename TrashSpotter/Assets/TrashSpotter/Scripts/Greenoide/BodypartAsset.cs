using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBodypartType
{
    HEAD,
    EYES,
    MOUTH,
    TATTOO,
    HAIR,
    TOP_HEAD,
    CLOTHES,
    FACE_ORNAMENT,
    BODY_ORNAMENT
}

[CreateAssetMenu(fileName = "BodypartAsset", menuName = "Greenoide/BodypartAsset", order = 1)]
public class BodypartAsset : ScriptableObject
{
    public Sprite _Sprite = null;
    public int _Id = 0;
    public EBodypartType _Type = EBodypartType.EYES;
}
