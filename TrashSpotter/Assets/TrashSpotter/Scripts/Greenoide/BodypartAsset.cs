using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBodypartType
{
    HEAD,
    EYES,
    MOUTH,
    TATTOO,
    TOP_HEAD_ORNAMENT,
    CLOTHES,
    FACE_ORNAMENT,
    BODY_ORNAMENT
}

[CreateAssetMenu(fileName = "BodypartAsset", menuName = "Greenoide/BodypartAsset", order = 1)]
public class BodypartAsset : ScriptableObject
{
    public Sprite _Sprite;
    public int _Id;
    public EBodypartType _Type;
}
