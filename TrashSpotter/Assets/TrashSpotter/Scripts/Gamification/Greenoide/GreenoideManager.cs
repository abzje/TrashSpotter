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
    [SerializeField] int _EarsAssetId = 0;
    [SerializeField] int _ClothesAssetId = 0;
    [SerializeField] int _OrnamentAssetId = 0;

    [Header ("Lists")]
    [SerializeField] public List<Greenoide> _Greenoides;
    [SerializeField] List<Head> _HeadList = null;
    [SerializeField] public BodypartList _BodypartAvailable = null;
    List<int> _CurrentBodyPartsIds;

    #region MonoBehavior Methods
    void Start() 
    {
        if (_Head == null && _BodypartAvailable == null)
            return;

        SetBodypartPosition();
        SetupSprites();
        SetCurrentBodyPartsIds();
    }
    #endregion

    #region Getting data
    /// <summary>
	/// Look for the head in the list of Heads
	/// </summary>
    /// <param name="id"> The head id</param>
    Head findHead(int id)
    {
        foreach (Head h in _HeadList)
        {
            if (h._HeadAssetId == id)
                return h;
        }
        return null;
    }

    private void SetCurrentBodyPartsIds()
    {
        _CurrentBodyPartsIds = new List<int>();
        _CurrentBodyPartsIds.Add(_Head._HeadAssetId);
        _CurrentBodyPartsIds.Add(_TattooAssetId);
        _CurrentBodyPartsIds.Add(_EyesAssetId);
        _CurrentBodyPartsIds.Add(_MouthAssetId);
        _CurrentBodyPartsIds.Add(_HairAssetId);
        _CurrentBodyPartsIds.Add(_TopHeadAssetId);
        _CurrentBodyPartsIds.Add(_EarsAssetId);
        _CurrentBodyPartsIds.Add(_ClothesAssetId);
        _CurrentBodyPartsIds.Add(_OrnamentAssetId);
    }

    public List<int> GetCurrentBodyPartsIds()
    {
        return _CurrentBodyPartsIds;
    }

    #region Get Body Parts Sprite
    public Sprite GetHeadSprite()
    {
        BodypartAsset asset = _BodypartAvailable.GetHeadAsset(_Head._HeadAssetId);
        if (asset)
            return asset._Sprite;
        return null;
    }
    public Sprite GetTattooSprite()
    {
        BodypartAsset asset = _BodypartAvailable.GetTattooAsset(_TattooAssetId);
        if (asset)
            return asset._Sprite;
        return null;
    }
    public Sprite GetEyesSprite()
    {
        BodypartAsset asset = _BodypartAvailable.GetEyesAsset(_EyesAssetId);
        if (asset)
            return asset._Sprite;
        return null;
    }
    public Sprite GetMouthSprite()
    {
        BodypartAsset asset = _BodypartAvailable.GetMouthAsset(_MouthAssetId);
        if (asset)
            return asset._Sprite;
        return null;
    }
    public Sprite GetHairSprite()
    {
        BodypartAsset asset = _BodypartAvailable.GetHairAsset(_HairAssetId);
        if (asset)
            return asset._Sprite;
        return null;
    }
    public Sprite GetTopHeadSprite()
    {
        BodypartAsset asset = _BodypartAvailable.GetTopHeadAsset(_TopHeadAssetId);
        if (asset)
            return asset._Sprite;
        return null;
    }
    public Sprite GetEarsSprite()
    {
        BodypartAsset asset = _BodypartAvailable.GetEarsAsset(_EarsAssetId);
        if (asset)
            return asset._Sprite;
        return null;
    }
    public Sprite GetClothesSprite()
    {
        BodypartAsset asset = _BodypartAvailable.GetClothesAsset(_ClothesAssetId);
        if (asset)
            return asset._Sprite;
        return null;
    }
    public Sprite GetOrnamentSprite()
    {
        BodypartAsset asset = _BodypartAvailable.GetOrnamentAsset(_OrnamentAssetId);
        if (asset)
            return asset._Sprite;
        return null;
    }
    #endregion
    #endregion

    #region Greenoide Interfacing Methods

    /// <summary>
	/// Set the body parts positions according to the head data
	/// </summary>
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

    void SetupSprites()
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

        Ears earAsset = _BodypartAvailable.GetEarsAsset(_EarsAssetId);
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

    #region Change Bodyparts
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

        _CurrentBodyPartsIds.Remove(_Head._HeadAssetId);
        _Head._HeadAssetId = id;
        _CurrentBodyPartsIds.Add(id);
    }
    public void ChangeTattoo(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeTattoo(sprite);
        
        _CurrentBodyPartsIds.Remove(_TattooAssetId);
        _TattooAssetId = id;
        _CurrentBodyPartsIds.Add(id);
    }
    public void ChangeEyes(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeEyes(sprite);

        _CurrentBodyPartsIds.Remove(_EyesAssetId);
        _EyesAssetId = id;
        _CurrentBodyPartsIds.Add(id);
    }
    public void ChangeMouth(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeMouth(sprite);

        _CurrentBodyPartsIds.Remove(_MouthAssetId);
        _MouthAssetId = id;
        _CurrentBodyPartsIds.Add(id);
    }
    public void ChangeHair(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeHair(sprite);

        _CurrentBodyPartsIds.Remove(_HairAssetId);
        _HairAssetId = id;
        _CurrentBodyPartsIds.Add(id);
    }
    public void ChangeTopHead(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeTopHead(sprite);

        _CurrentBodyPartsIds.Remove(_TopHeadAssetId);
        _TopHeadAssetId = id;
        _CurrentBodyPartsIds.Add(id);
    }
    public void ChangeEars(Sprite sprite, Sprite earsBackSprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeEars(sprite, earsBackSprite);

        _CurrentBodyPartsIds.Remove(_EarsAssetId);
        _EarsAssetId = id;
        _CurrentBodyPartsIds.Add(id);
    }
    public void ChangeClothes(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeClothes(sprite);

        _CurrentBodyPartsIds.Remove(_ClothesAssetId);
        _ClothesAssetId = id;
        _CurrentBodyPartsIds.Add(id);
    }
    public void ChangeOrnament(Sprite sprite, int id)
    {
        foreach(Greenoide g in _Greenoides)
            g.ChangeOrnament(sprite);

        _CurrentBodyPartsIds.Remove(_OrnamentAssetId);
        _OrnamentAssetId = id;
        _CurrentBodyPartsIds.Add(id);
    }

    #endregion 
    
    #endregion 
}
