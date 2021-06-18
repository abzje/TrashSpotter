using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteMask))]
public class Tattoo : Bodypart
{
    SpriteMask mask;

    protected override void Awake() 
    {
        base.Awake();
        mask = GetComponent<SpriteMask>();
    }

    public void SetMask(Sprite newMask)
    {
        mask.sprite = newMask;
    }
}
