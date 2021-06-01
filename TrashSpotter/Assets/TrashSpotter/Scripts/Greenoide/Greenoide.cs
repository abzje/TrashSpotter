using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greenoide : MonoBehaviour
{

    

    [Header ("Body part gameobjects")]
    [SerializeField] public Bodypart _Head = null;
    [SerializeField] public Bodypart _Tattoo = null;
    [SerializeField] public Bodypart _Eyes = null;
    [SerializeField] public Bodypart _Mouth = null;
    [SerializeField] public Bodypart _Hair = null;
    [SerializeField] public Bodypart _TopHead = null;
    [SerializeField] public Bodypart _Ears = null;
    [SerializeField] Bodypart _EarsBack = null;
    [SerializeField] public Bodypart _Clothes = null;
    [SerializeField] public Bodypart _Ornament = null;
    [SerializeField] public SpriteMask _HeadMask = null;

    public void SetBodypartPosition(Head head)
    {
        
        // Sets the head asset and the position for the other parts
        if (_Head != null && head != null)
        {
            _Head.transform.localPosition = new Vector3(0, 0, -0.5f);

            // Sets the body parts position according to the given head
            if (_Tattoo != null)
                _Tattoo.transform.localPosition = new Vector3(head._TattooPos.x, head._TattooPos.y, -1f);

            if (_Eyes != null)
                _Eyes.transform.localPosition = new Vector3(head._EyesPos.x, head._EyesPos.y, -1f);

            if (_Mouth != null)
                _Mouth.transform.localPosition = new Vector3(head._MouthPos.x, head._MouthPos.y, -1f);

            if (_Hair != null)
                _Hair.transform.localPosition = new Vector3(head._HairPos.x, head._HairPos.y, -1f);

            if (_TopHead != null)
                _TopHead.transform.localPosition = new Vector3(head._TopHeadPos.x, head._TopHeadPos.y, -1.5f);
            
            if (_Ears != null)
                _Ears.transform.localPosition = new Vector3(head._EarsPos.x, head._EarsPos.y, -2f);;

            if (_EarsBack != null)
                _EarsBack.transform.localPosition = new Vector3(head._EarsBackPos.x, head._EarsBackPos.y, 0f);

            if (_Clothes != null)
                _Clothes.transform.localPosition = new Vector3(head._ClothesPos.x, head._ClothesPos.y, -1f);

            if (_Ornament != null)
                _Ornament.transform.localPosition = new Vector3(head._OrnamentPos.x, head._OrnamentPos.y, -1.5f);
        }
    }

    public void ChangeHead(Sprite sprite, Sprite mask)
    {
        if (_Head == null)
            return;

        _Head.SetSprite(sprite);
        _HeadMask.sprite = mask;
    }
    public void ChangeTattoo(Sprite sprite)
    {
        if (_Tattoo == null)
            return;
            
        _Tattoo.SetSprite(sprite);
    }
    public void ChangeEyes(Sprite sprite)
    {
        if (_Eyes == null)
            return;
            
        _Eyes.SetSprite(sprite);
    }
    public void ChangeMouth(Sprite sprite)
    {
        if (_Mouth == null)
            return;
            
        _Mouth.SetSprite(sprite);
    }
    public void ChangeHair(Sprite sprite)
    {
        if (_Hair == null)
            return;
            
        _Hair.SetSprite(sprite);
    }
    public void ChangeTopHead(Sprite sprite)
    {
        if (_TopHead == null)
            return;
            
        _TopHead.SetSprite(sprite);
    }
    public void ChangeEars(Sprite sprite, Sprite earsBackSprite)
    {
        if (_Ears == null || _EarsBack == null)
            return;
            
        _Ears.SetSprite(sprite);
        _EarsBack.SetSprite(earsBackSprite);
    }
    public void ChangeClothes(Sprite sprite)
    {
        if (_Clothes == null)
            return;
            
        _Clothes.SetSprite(sprite);
    }
    public void ChangeOrnament(Sprite sprite)
    {
        if (_Ornament == null)
            return;
            
        _Ornament.SetSprite(sprite);
    }
}
