using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenoideManager : MonoBehaviour
{
    [Header ("Head asset")]
    [SerializeField] Head _Head = null;

    [Header ("Body part assets id")]
    [SerializeField] int _TattooAssetId = 0;
    [SerializeField] int _EyesAssetId = 0;
    [SerializeField] int _MouthAssetId = 0;
    [SerializeField] int _HairAssetId = 0;
    [SerializeField] int _TopHeadAssetId = 0;
    [SerializeField] int _EarAssetId = 0;
    [SerializeField] int _ClothesAssetId = 0;
    [SerializeField] int _OrnamentAssetId = 0;

    [Header ("Lists")]
    [SerializeField] List<Greenoide> _Greenoides;
    [SerializeField] List<Head> _HeadList = null;
    [SerializeField] public BodypartList _BodypartAvailable = null;



    private void Start() 
    {
        if (_Head == null && _BodypartAvailable == null)
            return;

        SetBodypartPosition();
        SetupSprites();
    }

    void SetBodypartPosition()
    {
        BodypartAsset headAsset = _BodypartAvailable.GetHeadAsset(_Head._HeadAssetId);
        if (headAsset != null)
        {
            foreach(Greenoide g in _Greenoides)
            {
                g.ChangeHead(headAsset._Sprite, _Head._Mask);
                g.SetBodypartPosition(_Head);
            }
        }
    }

    private void SetupSprites()
    {
        // sets the sprite for all body parts
        BodypartAsset asset = _BodypartAvailable.GetTattooAsset(_TattooAssetId);
        if (asset != null)
        {
            foreach (Greenoide g in _Greenoides)
                g.ChangeTattoo(asset._Sprite);
        }

        asset = _BodypartAvailable.GetEyesAsset(_EyesAssetId);
        if (asset != null)
        {
            foreach (Greenoide g in _Greenoides)
                g.ChangeEyes(asset._Sprite);
        }
        
        asset = _BodypartAvailable.GetMouthAsset(_MouthAssetId);
        if (asset != null)
        {
            foreach (Greenoide g in _Greenoides)
                g.ChangeMouth(asset._Sprite);
        }
        
        asset = _BodypartAvailable.GetHairAsset(_HairAssetId);
        if (asset != null)
        {
            foreach (Greenoide g in _Greenoides)
                g.ChangeHair(asset._Sprite);
        }

        asset = _BodypartAvailable.GetTopHeadAsset(_TopHeadAssetId);
        if (asset != null)
        {
            foreach (Greenoide g in _Greenoides)
                g.ChangeTopHead(asset._Sprite);
        }  

        Ears earAsset = _BodypartAvailable.GetEarsAsset(_EarAssetId);
        if (asset != null)
        {
            foreach (Greenoide g in _Greenoides)
                g.ChangeEars(earAsset._Sprite, earAsset._EarsBackSprite);
        } 
            
        asset = _BodypartAvailable.GetClothesAsset(_ClothesAssetId);
        if (asset != null)
        {
            foreach (Greenoide g in _Greenoides)
                g.ChangeClothes(asset._Sprite);
        } 

        asset = _BodypartAvailable.GetOrnamentAsset(_OrnamentAssetId);
        if (asset != null)
        {
            foreach (Greenoide g in _Greenoides)
                g.ChangeOrnament(asset._Sprite);
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

    #region ChangeBodyparts
    public void ChangeHead(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeHead(sprite, _Head._Mask);

        Head h = findHead(id);
        if (h != null)
        {
            _Head = h;
            SetBodypartPosition();
        }
    }
    public void ChangeTattoo(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeTattoo(sprite);
        _TattooAssetId = id;
    }
    public void ChangeEyes(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeEyes(sprite);
        _EyesAssetId = id;
    }
    public void ChangeMouth(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeMouth(sprite);
        _MouthAssetId = id;
    }
    public void ChangeHair(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeHair(sprite);
        _HairAssetId = id;
    }
    public void ChangeTopHead(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeTopHead(sprite);
        _TopHeadAssetId = id;
    }
    public void ChangeEars(Sprite sprite, Sprite earsBackSprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeEars(sprite, earsBackSprite);
        _EarAssetId = id;
    }
    public void ChangeClothes(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeClothes(sprite);
        _ClothesAssetId = id;
    }
    public void ChangeOrnament(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeOrnament(sprite);
        _OrnamentAssetId = id;
    }

    #endregion 
}
