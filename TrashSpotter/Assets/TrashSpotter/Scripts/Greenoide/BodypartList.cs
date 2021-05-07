using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BodypartList", menuName = "Greenoide/BodypartList", order = 2)]
public class BodypartList : ScriptableObject
{
    public List<BodypartAsset> _HeadList;
    public List<BodypartAsset> _TattooList;
    public List<BodypartAsset> _EyesList;
    public List<BodypartAsset> _MouthList;
    public List<BodypartAsset> _HairList;
    public List<BodypartAsset> _TopHeadList;
    public List<BodypartAsset> _EarsList;
    public List<BodypartAsset> _EarsBackList;
    public List<BodypartAsset> _ClothesList;
    public List<BodypartAsset> _OrnamentList;

    public BodypartAsset GetHeadAsset(int id)
    {
        foreach (BodypartAsset b in _HeadList)
            if (b._Id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetTattooAsset(int id)
    {
        foreach (BodypartAsset b in _TattooList)
            if (b._Id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetEyesAsset(int id)
    {
        foreach (BodypartAsset b in _EyesList)
            if (b._Id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetMouthAsset(int id)
    {
        foreach (BodypartAsset b in _MouthList)
            if (b._Id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetHairAsset(int id)
    {
        foreach (BodypartAsset b in _HairList)
            if (b._Id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetTopHeadAsset(int id)
    {
        foreach (BodypartAsset b in _TopHeadList)
            if (b._Id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetEarsAsset(int id)
    {
        foreach (BodypartAsset b in _EarsList)
            if (b._Id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetEarsBackAsset(int id)
    {
        foreach (BodypartAsset b in _EarsBackList)
            if (b._Id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetClothesAsset(int id)
    {
        foreach (BodypartAsset b in _ClothesList)
            if (b._Id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetOrnamentAsset(int id)
    {
        foreach (BodypartAsset b in _OrnamentList)
            if (b._Id == id)    
                return b;
        return null;
    }
}
