using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GreenoideHead", menuName = "Greenoide/GreenoideHead", order = 3)]
public class Head : ScriptableObject
{
    [SerializeField] public int _HeadAssetId;
    Sprite _HeadSprite;

    // Other body parts position are decided from the head
    [SerializeField] public Vector2 _EyesPos;
    [SerializeField] public Vector2 _MouthPos;
    [SerializeField] public Vector2 _TattooPos;
    [SerializeField] public Vector2 _TopHeadOrnamentPos;
    [SerializeField] public Vector2 _ClothesPos;
    [SerializeField] public Vector2 _FaceOrnamentPos;
    [SerializeField] public Vector2 _BodyOrnamentPos;

}
