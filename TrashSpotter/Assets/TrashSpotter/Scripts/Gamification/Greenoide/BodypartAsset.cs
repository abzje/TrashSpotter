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
    public Sprite sprite = null;
    public int id = 0;
    public EBodypartType type = EBodypartType.EYES;
    public EFamily family = EFamily.COMMON;
    public int level = 1;
    public int price = 10;
    public bool isfavorited = false;
    public bool isBought = false;
}
