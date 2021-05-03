using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greenoide : MonoBehaviour
{
    [SerializeField] BodypartList _BodypartAvailable = null;

    [SerializeField] Head _HeadAsset = null;
    [SerializeField] int _EyesAssetId = 0;
    [SerializeField] int _MouthAssetId = 0;
    [SerializeField] int _TattooAssetId = 0;
    [SerializeField] int _HairAssetId = 0;
    [SerializeField] int _TopHeadAssetId = 0;
    [SerializeField] int _ClothesAssetId = 0;
    [SerializeField] int _FaceOrnamentAssetId = 0;
    [SerializeField] int _BodyOrnamentAssetId = 0;

    [SerializeField] Bodypart _Head = null;
    [SerializeField] Bodypart _Eyes = null;
    [SerializeField] Bodypart _Mouth = null;
    [SerializeField] Bodypart _Tattoo = null;
    [SerializeField] Bodypart _Hair = null;
    [SerializeField] Bodypart _TopHead = null;
    [SerializeField] Bodypart _Clothes = null;
    [SerializeField] Bodypart _FaceOrnament = null;
    [SerializeField] Bodypart _BodyOrnament = null;

    private void Start() 
    {
        if (_BodypartAvailable == null)
            return;
        
        // Sets the head asset and the position for the other parts
        if (_Head != null && _HeadAsset != null)
        {
            BodypartAsset headAsset = _BodypartAvailable.GetBodypartAsset(_HeadAsset._HeadAssetId);
            if (headAsset != null)
                _Head.SetSprite(headAsset._Sprite);

            // Sets the body parts position according to the given head
            if (_Eyes != null)
                _Eyes.transform.position = _HeadAsset._EyesPos;

            if (_Mouth != null)
                _Mouth.transform.position = _HeadAsset._MouthPos;

            if (_Tattoo != null)
                _Tattoo.transform.position = _HeadAsset._TattooPos;

            if (_Hair != null)
                _Hair.transform.position = _HeadAsset._HairPos;

            if (_TopHead != null)
                _TopHead.transform.position = _HeadAsset._TopHeadPos;

            if (_Clothes != null)
                _Clothes.transform.position = _HeadAsset._ClothesPos;

            if (_FaceOrnament != null)
                _FaceOrnament.transform.position = _HeadAsset._FaceOrnamentPos;
                
            if (_BodyOrnament != null)
                _BodyOrnament.transform.position = _HeadAsset._BodyOrnamentPos;
        }

        // sets the sprite for all body parts
        if (_Eyes != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetBodypartAsset(_EyesAssetId);
            if (asset != null)
                _Eyes.SetSprite(asset._Sprite);
        }
        
        if (_Mouth != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetBodypartAsset(_MouthAssetId);
            if (asset != null)
                _Mouth.SetSprite(asset._Sprite);
        }
        
        if (_Tattoo != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetBodypartAsset(_TattooAssetId);
            if (asset != null)
                _Tattoo.SetSprite(asset._Sprite);
        }
        
        if (_Hair != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetBodypartAsset(_HairAssetId);
            if (asset != null)
                _Hair.SetSprite(asset._Sprite);
        }

        if (_TopHead != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetBodypartAsset(_TopHeadAssetId);
            if (asset != null)
                _TopHead.SetSprite(asset._Sprite);
        }        
        
        if (_Clothes != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetBodypartAsset(_ClothesAssetId);
            if (asset != null)
                _Clothes.SetSprite(asset._Sprite);
        }

        if (_FaceOrnament != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetBodypartAsset(_FaceOrnamentAssetId);
            if (asset != null)
                _FaceOrnament.SetSprite(asset._Sprite);
        }
        
        if (_BodyOrnament != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetBodypartAsset(_BodyOrnamentAssetId);
            if (asset != null)
                _BodyOrnament.SetSprite(asset._Sprite);
        }
    }
}
