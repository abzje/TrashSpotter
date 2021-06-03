using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteMask))]
public class Tattoo : Bodypart
{
    SpriteMask _Mask;

    protected override void Awake() 
    {
        base.Awake();
        _Mask = GetComponent<SpriteMask>();
    }

    public void SetMask(Sprite mask)
    {
        _Mask.sprite = mask;
    }
}
