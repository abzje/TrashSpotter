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

[CreateAssetMenu(fileName = "BodypartAsset", menuName = "Trashspotter/Greenoide/BodypartAsset", order = 1)]
public class BodypartAsset : ScriptableObject
{
    public Sprite _Sprite = null;
    public int _Id = 0;
    public EBodypartType _Type = EBodypartType.EYES;
    public EFamily _Family = EFamily.GUARDIANS;
    public int _Price = 10;
    public int _Level = 1;
    public bool _IsBought = false;
    public bool _Isfavorited = false;
}
