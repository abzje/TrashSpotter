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
    [SerializeField] int _ClothesAssetId = 0;
    [SerializeField] int _OrnamentAssetId = 0;

    [SerializeField] Bodypart _Head = null;
    [SerializeField] Bodypart _Tattoo = null;
    [SerializeField] Bodypart _Eyes = null;
    [SerializeField] Bodypart _Mouth = null;
    [SerializeField] Bodypart _Hair = null;
    [SerializeField] Bodypart _TopHead = null;
    [SerializeField] Bodypart _Ears = null;
    [SerializeField] Bodypart _EarsBack = null;
    [SerializeField] Bodypart _Clothes = null;
    [SerializeField] Bodypart _Ornament = null;
    [SerializeField] SpriteMask _HeadMask = null;

    [SerializeField] List<Head> _HeadList = null;

    private void Start() 
    {
        if (_BodypartAvailable == null)
            return;
        
        SetBodypartPosition();
        SetupSprites();
    }

    private void SetBodypartPosition()
    {
        
        // Sets the head asset and the position for the other parts
        if (_Head != null && _HeadAsset != null)
        {
            BodypartAsset headAsset = _BodypartAvailable.GetHeadAsset(_HeadAsset._HeadAssetId);
            if (headAsset != null)
            {
                _Head.transform.localPosition = new Vector3(0, 0, -0.5f);
                _Head.SetSprite(headAsset._Sprite);
            }

            // Sets the body parts position according to the given head
            if (_Tattoo != null)
                _Tattoo.transform.localPosition = new Vector3(_HeadAsset._TattooPos.x, _HeadAsset._TattooPos.y, -1f);

            if (_Eyes != null)
                _Eyes.transform.localPosition = new Vector3(_HeadAsset._EyesPos.x, _HeadAsset._EyesPos.y, -1f);

            if (_Mouth != null)
                _Mouth.transform.localPosition = new Vector3(_HeadAsset._MouthPos.x, _HeadAsset._MouthPos.y, -1f);

            if (_Hair != null)
                _Hair.transform.localPosition = new Vector3(_HeadAsset._HairPos.x, _HeadAsset._HairPos.y, -1f);

            if (_TopHead != null)
                _TopHead.transform.localPosition = new Vector3(_HeadAsset._TopHeadPos.x, _HeadAsset._TopHeadPos.y, -1.5f);
            
            if (_Ears != null)
                _Ears.transform.localPosition = new Vector3(_HeadAsset._EarsPos.x, _HeadAsset._EarsPos.y, -2f);;

            if (_EarsBack != null)
                _EarsBack.transform.localPosition = new Vector3(_HeadAsset._EarsBackPos.x, _HeadAsset._EarsBackPos.y, 0f);

            if (_Clothes != null)
                _Clothes.transform.localPosition = new Vector3(_HeadAsset._ClothesPos.x, _HeadAsset._ClothesPos.y, -1f);

            if (_Ornament != null)
                _Ornament.transform.localPosition = new Vector3(_HeadAsset._OrnamentPos.x, _HeadAsset._OrnamentPos.y, -1.5f);
        }
    }

    private void SetupSprites()
    {
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
        
        if (_Clothes != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetClothesAsset(_ClothesAssetId);
            if (asset != null)
                _Clothes.SetSprite(asset._Sprite);
        }

        if (_Ornament != null)
        {
            BodypartAsset asset = _BodypartAvailable.GetOrnamentAsset(_OrnamentAssetId);
            if (asset != null)
                _Ornament.SetSprite(asset._Sprite);
        }
    }

    private Head findHead(int id)
    {
        foreach (Head h in _HeadList)
        {
            if (h._HeadAssetId == id)
                return h;
        }
        return null;
    }

    public void ChangeHead(Sprite sprite, int id)
    {
        _Head.SetSprite(sprite);
        Head h = findHead(id);
        if (h != null)
        {
            _HeadAsset = h;
            SetBodypartPosition();
        }
    }
    public void ChangeTattoo(Sprite sprite, int id)
    {
        _Tattoo.SetSprite(sprite);
        _TattooAssetId = id;
    }
    public void ChangeEyes(Sprite sprite, int id)
    {
        _Eyes.SetSprite(sprite);
        _EyesAssetId = id;
    }
    public void ChangeMouth(Sprite sprite, int id)
    {
        _Mouth.SetSprite(sprite);
        _MouthAssetId = id;
    }
    public void ChangeHair(Sprite sprite, int id)
    {
        _Hair.SetSprite(sprite);
        _HairAssetId = id;
    }
    public void ChangeTopHead(Sprite sprite, int id)
    {
        _TopHead.SetSprite(sprite);
        _TopHeadAssetId = id;
    }
    public void ChangeEars(Sprite sprite, int id)
    {
        _Ears.SetSprite(sprite);
        _EarAssetId = id;
    }
    public void ChangeEarsBack(Sprite sprite, int id)
    {
        _EarsBack.SetSprite(sprite);
        _EarBackAssetId = id;
    }
    public void ChangeClothes(Sprite sprite, int id)
    {
        _Clothes.SetSprite(sprite);
        _ClothesAssetId = id;
    }
    public void ChangeOrnament(Sprite sprite, int id)
    {
        _Ornament.SetSprite(sprite);
        _OrnamentAssetId = id;
    }
}
