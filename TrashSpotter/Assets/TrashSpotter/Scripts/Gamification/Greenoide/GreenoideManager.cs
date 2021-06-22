using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.TrashSpotter;

public class GreenoideManager : MonoBehaviour
{
    [Header ("Head asset")]
    [SerializeField] Head headData = null;

    [Header ("Body part assets id")]
    [SerializeField] int tattooAssetId = 0;
    [SerializeField] int eyesAssetId = 0;
    [SerializeField] int mouthAssetId = 0;
    [SerializeField] int hairAssetId = 0;
    [SerializeField] int topHeadAssetId = 0;
    [SerializeField] int earsAssetId = 0;
    [SerializeField] int clothesAssetId = 0;
    [SerializeField] int ornamentAssetId = 0;

    [Header ("Totem")]
    [SerializeField] public TotemAnimal totem;

    [Header ("Lists")]
    [SerializeField] public List<Greenoide> greenoides;
    [SerializeField] List<Head> headList = null;
    [SerializeField] public BodypartList bodypartAvailable = null;
    [SerializeField] public List<string> names = null;
    List<int> currentBodyPartsIds;

    #region MonoBehavior Methods
    void Start() 
    {
        if (headData == null && bodypartAvailable == null)
            return;

        SetBodypartPosition();
        SetupSprites();
        SetCurrentBodyPartsIds();

        // Buy the starting elements of the greenoide
        BodypartAsset asset = bodypartAvailable.GetHeadAsset(headData.headAssetId);
        if (asset)
            asset.isBought = true;

        asset = bodypartAvailable.GetEyesAsset(eyesAssetId);
        if (asset)
            asset.isBought = true;

        asset = bodypartAvailable.GetMouthAsset(mouthAssetId);
        if (asset)
            asset.isBought = true;
    }
    #endregion

    #region Getting data
    /// <summary>
	/// Look for the head in the list of Heads
	/// </summary>
    /// <param name="id"> The head id</param>
    Head findHead(int id)
    {
        foreach (Head h in headList)
        {
            if (h.headAssetId == id)
                return h;
        }
        return null;
    }

    private void SetCurrentBodyPartsIds()
    {
        currentBodyPartsIds = new List<int>();
        currentBodyPartsIds.Add(headData.headAssetId);
        currentBodyPartsIds.Add(tattooAssetId);
        currentBodyPartsIds.Add(eyesAssetId);
        currentBodyPartsIds.Add(mouthAssetId);
        currentBodyPartsIds.Add(hairAssetId);
        currentBodyPartsIds.Add(topHeadAssetId);
        currentBodyPartsIds.Add(earsAssetId);
        currentBodyPartsIds.Add(clothesAssetId);
        currentBodyPartsIds.Add(ornamentAssetId);
    }

    public List<int> GetCurrentBodyPartsIds()
    {
        return currentBodyPartsIds;
    }

    #region Get Body Parts Sprite
    public Sprite GetHeadSprite()
    {
        BodypartAsset asset = bodypartAvailable.GetHeadAsset(headData.headAssetId);
        if (asset)
            return asset.sprite;
        return null;
    }
    public Sprite GetTattooSprite()
    {
        BodypartAsset asset = bodypartAvailable.GetTattooAsset(tattooAssetId);
        if (asset)
            return asset.sprite;
        return null;
    }
    public Sprite GetEyesSprite()
    {
        BodypartAsset asset = bodypartAvailable.GetEyesAsset(eyesAssetId);
        if (asset)
            return asset.sprite;
        return null;
    }
    public Sprite GetMouthSprite()
    {
        BodypartAsset asset = bodypartAvailable.GetMouthAsset(mouthAssetId);
        if (asset)
            return asset.sprite;
        return null;
    }
    public Sprite GetHairSprite()
    {
        BodypartAsset asset = bodypartAvailable.GetHairAsset(hairAssetId);
        if (asset)
            return asset.sprite;
        return null;
    }
    public Sprite GetTopHeadSprite()
    {
        BodypartAsset asset = bodypartAvailable.GetTopHeadAsset(topHeadAssetId);
        if (asset)
            return asset.sprite;
        return null;
    }
    public Sprite GetEarsSprite()
    {
        BodypartAsset asset = bodypartAvailable.GetEarsAsset(earsAssetId);
        if (asset)
            return asset.sprite;
        return null;
    }
    public Sprite GetClothesSprite()
    {
        BodypartAsset asset = bodypartAvailable.GetClothesAsset(clothesAssetId);
        if (asset)
            return asset.sprite;
        return null;
    }
    public Sprite GetOrnamentSprite()
    {
        BodypartAsset asset = bodypartAvailable.GetOrnamentAsset(ornamentAssetId);
        if (asset)
            return asset.sprite;
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
        BodypartAsset headAsset = bodypartAvailable.GetHeadAsset(headData.headAssetId);
        if (headAsset != null)
        {
            foreach(Greenoide g in greenoides)
            {
                g.ChangeHead(headAsset.sprite, headData.mask);
                g.SetBodypartPosition(headData);
            }
        }
    }

    void SetupSprites()
    {
        // sets the sprite for all body parts
        BodypartAsset asset = bodypartAvailable.GetTattooAsset(tattooAssetId);
        if (asset != null && asset.level <= Gamification.Instance.Level)
        {
            foreach (Greenoide g in greenoides)
                g.ChangeTattoo(asset.sprite);
        }

        asset = bodypartAvailable.GetEyesAsset(eyesAssetId);
        if (asset != null && asset.level <= Gamification.Instance.Level)
        {
            foreach (Greenoide g in greenoides)
                g.ChangeEyes(asset.sprite);
        }
        
        asset = bodypartAvailable.GetMouthAsset(mouthAssetId);
        if (asset != null && asset.level <= Gamification.Instance.Level)
        {
            foreach (Greenoide g in greenoides)
                g.ChangeMouth(asset.sprite);
        }
        
        asset = bodypartAvailable.GetHairAsset(hairAssetId);
        if (asset != null && asset.level <= Gamification.Instance.Level)
        {
            foreach (Greenoide g in greenoides)
                g.ChangeHair(asset.sprite);
        }

        asset = bodypartAvailable.GetTopHeadAsset(topHeadAssetId);
        if (asset != null && asset.level <= Gamification.Instance.Level)
        {
            foreach (Greenoide g in greenoides)
                g.ChangeTopHead(asset.sprite);
        }  

        Ears earAsset = bodypartAvailable.GetEarsAsset(earsAssetId);
        if (asset != null && asset.level <= Gamification.Instance.Level)
        {
            foreach (Greenoide g in greenoides)
                g.ChangeEars(earAsset.sprite, earAsset.earsBackSprite);
        } 
            
        asset = bodypartAvailable.GetClothesAsset(clothesAssetId);
        if (asset != null && asset.level <= Gamification.Instance.Level)
        {
            foreach (Greenoide g in greenoides)
                g.ChangeClothes(asset.sprite);
        } 

        asset = bodypartAvailable.GetOrnamentAsset(ornamentAssetId);
        if (asset != null && asset.level <= Gamification.Instance.Level)
        {
            foreach (Greenoide g in greenoides)
                g.ChangeOrnament(asset.sprite);
        } 
    }

    public void ChangeTotem(TotemAnimal newTotem)
    {
        totem = newTotem;
    }

    #region Change Bodyparts
    public void ChangeHead(Sprite sprite, int id)
    {
        foreach(Greenoide g in greenoides)
            g.ChangeHead(sprite, headData.mask);

        Head h = findHead(id);
        if (h != null)
        {
            headData = h;
            SetBodypartPosition();
        }

        currentBodyPartsIds.Remove(headData.headAssetId);
        headData.headAssetId = id;
        currentBodyPartsIds.Add(id);
    }
    public void ChangeTattoo(Sprite sprite, int id)
    {
        foreach(Greenoide g in greenoides)
            g.ChangeTattoo(sprite);
        
        currentBodyPartsIds.Remove(tattooAssetId);
        tattooAssetId = id;
        currentBodyPartsIds.Add(id);
    }
    public void ChangeEyes(Sprite sprite, int id)
    {
        foreach(Greenoide g in greenoides)
            g.ChangeEyes(sprite);

        currentBodyPartsIds.Remove(eyesAssetId);
        eyesAssetId = id;
        currentBodyPartsIds.Add(id);
    }
    public void ChangeMouth(Sprite sprite, int id)
    {
        foreach(Greenoide g in greenoides)
            g.ChangeMouth(sprite);

        currentBodyPartsIds.Remove(mouthAssetId);
        mouthAssetId = id;
        currentBodyPartsIds.Add(id);
    }
    public void ChangeHair(Sprite sprite, int id)
    {
        foreach(Greenoide g in greenoides)
            g.ChangeHair(sprite);

        currentBodyPartsIds.Remove(hairAssetId);
        hairAssetId = id;
        currentBodyPartsIds.Add(id);
    }
    public void ChangeTopHead(Sprite sprite, int id)
    {
        foreach(Greenoide g in greenoides)
            g.ChangeTopHead(sprite);

        currentBodyPartsIds.Remove(topHeadAssetId);
        topHeadAssetId = id;
        currentBodyPartsIds.Add(id);
    }
    public void ChangeEars(Sprite sprite, Sprite earsBackSprite, int id)
    {
        foreach(Greenoide g in greenoides)
            g.ChangeEars(sprite, earsBackSprite);

        currentBodyPartsIds.Remove(earsAssetId);
        earsAssetId = id;
        currentBodyPartsIds.Add(id);
    }
    public void ChangeClothes(Sprite sprite, int id)
    {
        foreach(Greenoide g in greenoides)
            g.ChangeClothes(sprite);

        currentBodyPartsIds.Remove(clothesAssetId);
        clothesAssetId = id;
        currentBodyPartsIds.Add(id);
    }
    public void ChangeOrnament(Sprite sprite, int id)
    {
        foreach(Greenoide g in greenoides)
            g.ChangeOrnament(sprite);

        currentBodyPartsIds.Remove(ornamentAssetId);
        ornamentAssetId = id;
        currentBodyPartsIds.Add(id);
    }

    #endregion 

    #endregion 
}
