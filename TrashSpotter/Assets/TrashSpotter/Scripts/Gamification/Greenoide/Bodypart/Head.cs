using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GreenoideHead", menuName = "Trashspotter/Greenoide/GreenoideHead", order = 2)]
public class Head : ScriptableObject
{
    [SerializeField] public int headAssetId = 0;
    Sprite headSprite;

    [SerializeField] public Sprite mask = null;

    // Other body parts position are decided from the head
    [SerializeField] public Vector2 tattooPos = new Vector2();
    [SerializeField] public Vector2 eyesPos = new Vector2();
    [SerializeField] public Vector2 mouthPos = new Vector2();
    [SerializeField] public Vector2 hairPos = new Vector2();
    [SerializeField] public Vector2 topHeadPos = new Vector2();
    [SerializeField] public Vector2 earsPos = new Vector2();
    [SerializeField] public Vector2 earsBackPos = new Vector2();
    [SerializeField] public Vector2 clothesPos = new Vector2();
    [SerializeField] public Vector2 ornamentPos = new Vector2();

}
