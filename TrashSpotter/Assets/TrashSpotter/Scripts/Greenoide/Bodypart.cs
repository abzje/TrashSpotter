using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bodypart : MonoBehaviour
{
    public BodypartAsset _Asset;
    public SpriteRenderer _Renderer;

    void Start()
    {
        _Renderer = GetComponent<SpriteRenderer>();
        if (_Asset == null)
            return;
        _Renderer.sprite = _Asset._Sprite;
    }
}
