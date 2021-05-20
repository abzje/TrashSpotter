using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GreenoideHead", menuName = "Greenoide/GreenoideHead", order = 1)]
public class Head : ScriptableObject
{
    [SerializeField] public int _HeadAssetId = 0;
    Sprite _HeadSprite;

    [SerializeField] public Sprite _Mask = null;

    // Other body parts position are decided from the head
    [SerializeField] public Vector2 _TattooPos = new Vector2();
    [SerializeField] public Vector2 _EyesPos = new Vector2();
    [SerializeField] public Vector2 _MouthPos = new Vector2();
    [SerializeField] public Vector2 _HairPos = new Vector2();
    [SerializeField] public Vector2 _TopHeadPos = new Vector2();
    [SerializeField] public Vector2 _EarsPos = new Vector2();
    [SerializeField] public Vector2 _EarsBackPos = new Vector2();
    [SerializeField] public Vector2 _ClothesPos = new Vector2();
    [SerializeField] public Vector2 _OrnamentPos = new Vector2();

}
