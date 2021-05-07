using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greenoide : MonoBehaviour
{
    [SerializeField] BodypartList _BodypartAvailable = null;

    [SerializeField] Head _HeadAsset = null;
    [SerializeField] int _TattooAssetId = 0;
    [SerializeField] int _EyesAssetId = 0;
    [SerializeField] int _MouthAssetId = 0;
    [SerializeField] int _HairAssetId = 0;
    [SerializeField] int _TopHeadAssetId = 0;
    [SerializeField] int _EarAssetId = 0;
    [SerializeField] int _EarBackAssetId = 0;
    [SerializeField] int _ClothAssetId = 0;
    [SerializeField] int _OrnamentAssetId = 0;

    [SerializeField] Bodypart _Head = null;
    [SerializeField] Bodypart _Tattoo = null;
    [SerializeField] Bodypart _Eyes = null;
    [SerializeField] Bodypart _Mouth = null;
    [SerializeField] Bodypart _Hair = null;
    [SerializeField] Bodypart _TopHead = null;
    [SerializeField] Bodypart _Ears = null;
    [SerializeField] Bodypart _EarsBack = null;
    [SerializeField] Bodypart _Cloth = null;
    [SerializeField] Bodypart _Ornament = null;
    [SerializeField] SpriteMask _HeadMask = null;

    private void Start() 
    {
        if (_BodypartAvailable == null)
            return;
        
        // Sets the head asset and the position for the other parts
        if (_Head != null && _HeadAsset != null)
        {
            BodypartAsset headAsset = _BodypartAvailable.GetHeadAsset(_HeadAsset._HeadAssetId);
            if (headAsset != null)
                _Head.SetSprite(headAsset._Sprite);

            // Sets the body parts position according to the given head
            if (_Tattoo != null)
                _Tattoo.transform.position = _HeadAsset._TattooPos;

            if (_Eyes != null)
                _Eyes.transform.position = _HeadAsset._EyesPos;

            if (_Mouth != null)
                _Mouth.transform.position = _HeadAsset._MouthPos;

            if (_Hair != null)
                _Hair.transform.position = _HeadAsset._HairPos;

            if (_TopHead != null)
                _TopHead.transform.position = _HeadAsset._TopHeadPos;
            
            if (_Ears != null)
                _Ears.transform.position = _HeadAsset._EarsPos;

            if (_EarsBack != null)
                _EarsBack.transform.position = _HeadAsset._EarsBackPos;

            if (_Cloth != null)
                _Cloth.transform.position = _HeadAsset._ClothPos;

            if (_Ornament != null)
                _Ornament.transform.position = _HeadAsset._OrnamentPos;
        }

        // sets the sprite for all body parts
        if (_Tattoo != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetTattooAsset(_TattooAssetId);
            if (asset != null)
            {
                _Tattoo.SetSprite(asset._Sprite);
                if (_HeadMask != null)
                    _HeadMask.sprite = _HeadAsset._Mask;
            }
        }

        if (_Eyes != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetEyesAsset(_EyesAssetId);
            if (asset != null)
                _Eyes.SetSprite(asset._Sprite);
        }
        
        if (_Mouth != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetMouthAsset(_MouthAssetId);
            if (asset != null)
                _Mouth.SetSprite(asset._Sprite);
        }
        
        if (_Hair != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetHairAsset(_HairAssetId);
            if (asset != null)
                _Hair.SetSprite(asset._Sprite);
        }

        if (_TopHead != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetTopHeadAsset(_TopHeadAssetId);
            if (asset != null)
                _TopHead.SetSprite(asset._Sprite);
        }        

        if (_Ears != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetEarsAsset(_EarAssetId);
            if (asset != null)
                _Ears.SetSprite(asset._Sprite);
        }

        if (_EarsBack != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetEarsBackAsset(_EarBackAssetId);
            if (asset != null)
                _EarsBack.SetSprite(asset._Sprite);
        }
        
        if (_Cloth != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetClothesAsset(_ClothAssetId);
            if (asset != null)
                _Cloth.SetSprite(asset._Sprite);
        }

        if (_Ornament != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetOrnamentAsset(_OrnamentAssetId);
            if (asset != null)
                _Ornament.SetSprite(asset._Sprite);
        }
    }
}
