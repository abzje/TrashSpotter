using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greenoide : MonoBehaviour
{
    [Header ("Body part gameobjects")]
    [SerializeField] public Bodypart head = null;
    [SerializeField] public Bodypart tattoo = null;
    [SerializeField] public Bodypart eyes = null;
    [SerializeField] public Bodypart mouth = null;
    [SerializeField] public Bodypart hair = null;
    [SerializeField] public Bodypart topHead = null;
    [SerializeField] public Bodypart ears = null;
    [SerializeField] public Bodypart earsBack = null;
    [SerializeField] public Bodypart clothes = null;
    [SerializeField] public Bodypart ornament = null;
    [SerializeField] public SpriteMask headMask = null;
    public void SetBodypartPosition(Head headData)
    {
        
        // Sets the head asset and the position for the other parts
        if (headData != null && head != null)
        {
            head.transform.localPosition = new Vector3(0, 0, -0.5f);

            // Sets the body parts position according to the given head
            if (tattoo != null)
                tattoo.transform.localPosition = new Vector3(headData.tattooPos.x, headData.tattooPos.y, -1f);

            if (eyes != null)
                eyes.transform.localPosition = new Vector3(headData.eyesPos.x, headData.eyesPos.y, -1f);

            if (mouth != null)
                mouth.transform.localPosition = new Vector3(headData.mouthPos.x, headData.mouthPos.y, -1f);

            if (hair != null)
                hair.transform.localPosition = new Vector3(headData.hairPos.x, headData.hairPos.y, -1f);

            if (topHead != null)
                topHead.transform.localPosition = new Vector3(headData.topHeadPos.x, headData.topHeadPos.y, -1.5f);
            
            if (ears != null)
                ears.transform.localPosition = new Vector3(headData.earsPos.x, headData.earsPos.y, -2f);;

            if (earsBack != null)
                earsBack.transform.localPosition = new Vector3(headData.earsBackPos.x, headData.earsBackPos.y, 0f);

            if (clothes != null)
                clothes.transform.localPosition = new Vector3(headData.clothesPos.x, headData.clothesPos.y, -1f);

            if (ornament != null)
                ornament.transform.localPosition = new Vector3(headData.ornamentPos.x, headData.ornamentPos.y, -1.5f);
        }
    }

    public void ChangeHead(Sprite sprite, Sprite mask)
    {
        if (head == null)
            return;

        head.SetSprite(sprite);
        headMask.sprite = mask;
    }
    public void ChangeTattoo(Sprite sprite)
    {
        if (tattoo == null)
            return;
            
        tattoo.SetSprite(sprite);
    }
    public void ChangeEyes(Sprite sprite)
    {
        if (eyes == null)
            return;
            
        eyes.SetSprite(sprite);
    }
    public void ChangeMouth(Sprite sprite)
    {
        if (mouth == null)
            return;
            
        mouth.SetSprite(sprite);
    }
    public void ChangeHair(Sprite sprite)
    {
        if (hair == null)
            return;
            
        hair.SetSprite(sprite);
    }
    public void ChangeTopHead(Sprite sprite)
    {
        if (topHead == null)
            return;
            
        topHead.SetSprite(sprite);
    }
    public void ChangeEars(Sprite sprite, Sprite earsBackSprite)
    {
        if (ears == null || earsBack == null)
            return;
            
        ears.SetSprite(sprite);
        earsBack.SetSprite(earsBackSprite);
    }
    public void ChangeClothes(Sprite sprite)
    {
        if (clothes == null)
            return;
            
        clothes.SetSprite(sprite);
    }
    public void ChangeOrnament(Sprite sprite)
    {
        if (ornament == null)
            return;
            
        ornament.SetSprite(sprite);
    }
}
