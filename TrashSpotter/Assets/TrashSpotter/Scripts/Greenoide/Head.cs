using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GreenoideHead", menuName = "Greenoide/GreenoideHead", order = 3)]
public class Head : ScriptableObject
{
    [SerializeField] public int _HeadAssetId = 0;
    Sprite _HeadSprite;

    [SerializeField] public Sprite _Mask = null;

    // Other body parts position are decided from the head
    [SerializeField] public Vector3 _EyesPos = new Vector3();
    [SerializeField] public Vector3 _MouthPos = new Vector3();
    [SerializeField] public Vector3 _TattooPos = new Vector3();
    [SerializeField] public Vector3 _HairPos = new Vector3();
    [SerializeField] public Vector3 _TopHeadPos = new Vector3();
    [SerializeField] public Vector3 _EarPos = new Vector3();
    [SerializeField] public Vector3 _ClothPos = new Vector3();
    [SerializeField] public Vector3 _OrnamentPos = new Vector3();
    [SerializeField] public Vector3 _EarBackPos = new Vector3();

}
