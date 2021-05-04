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
    [SerializeField] int _EarAssetId = 0;
    [SerializeField] int _ClothAssetId = 0;
    [SerializeField] int _OrnamentAssetId = 0;
    [SerializeField] int _EarBackAssetId = 0;

    [SerializeField] Bodypart _Eyes = null;
    [SerializeField] Bodypart _Mouth = null;
    [SerializeField] Bodypart _Tattoo = null;
    [SerializeField] Bodypart _Hair = null;
    [SerializeField] Bodypart _TopHead = null;
    [SerializeField] Bodypart _Ear = null;
    [SerializeField] Bodypart _Cloth = null;
    [SerializeField] Bodypart _Ornament = null;
    [SerializeField] Bodypart _EarBack = null;
    [SerializeField] Bodypart _Head = null;

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
            
            if (_Ear != null)
                _Ear.transform.position = _HeadAsset._EarPos;

            if (_Cloth != null)
                _Cloth.transform.position = _HeadAsset._ClothPos;

            if (_Ornament != null)
                _Ornament.transform.position = _HeadAsset._OrnamentPos;
                
            if (_EarBack != null)
                _EarBack.transform.position = _HeadAsset._EarBackPos;
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

        if (_Ear != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetBodypartAsset(_EarAssetId);
            if (asset != null)
                _Ear.SetSprite(asset._Sprite);
        }

        if (_TopHead != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetBodypartAsset(_TopHeadAssetId);
            if (asset != null)
                _TopHead.SetSprite(asset._Sprite);
        }        
        
        if (_Cloth != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetBodypartAsset(_ClothAssetId);
            if (asset != null)
                _Cloth.SetSprite(asset._Sprite);
        }

        if (_Ornament != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetBodypartAsset(_OrnamentAssetId);
            if (asset != null)
                _Ornament.SetSprite(asset._Sprite);
        }
        
        if (_EarBack != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetBodypartAsset(_EarBackAssetId);
            if (asset != null)
                _EarBack.SetSprite(asset._Sprite);
        }
    }
}
