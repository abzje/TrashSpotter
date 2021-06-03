using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BodypartList", menuName = "Greenoide/BodypartList", order = 4)]
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

    public BodypartAsset GetBodypartAsset(int index)
    {
        if (index >= GetCount() || index < 0)
            return null;
        
        int count = _HeadList.Count; // Used to find in which list to find the asset
        int indexInList = index; // We subtract index with the size of the list we go through so the index is the right one when we get to the right list
        
        // We go through each list until we find the right one
        // HEAD
        if (index < count)
            return _HeadList[indexInList];
        
        // TATTOO
        count += _TattooList.Count;
        indexInList -= _HeadList.Count;
        
        if (index < count)
            return _TattooList[indexInList];

        // EYES
        count += _EyesList.Count;
        indexInList -= _TattooList.Count;
        
        if (index < count)
            return _EyesList[indexInList];

        // MOUTH
        count += _MouthList.Count;
        indexInList -= _EyesList.Count;
        
        if (index < count)
            return _MouthList[indexInList];

        // HAIR
        count += _HairList.Count;
        indexInList -= _MouthList.Count;
        
        if (index < count)
            return _HairList[indexInList];

        // TOP HEAD
        count += _TopHeadList.Count;
        indexInList -= _HairList.Count;
        
        if (index < count)
            return _TopHeadList[indexInList];

        // EARS
        count += _EarsList.Count;
        indexInList -= _TopHeadList.Count;
        
        if (index < count)
            return _EarsList[indexInList];

        // EARS BACK
        count += _EarsBackList.Count;
        indexInList -= _EarsList.Count;
        
        if (index < count)
            return _EarsBackList[indexInList];

        // CLOTHES
        count += _ClothesList.Count;
        indexInList -= _EarsBackList.Count;
        
        if (index < count)
            return _ClothesList[indexInList];

        // ORNAMENT
        count += _OrnamentList.Count;
        indexInList -= _ClothesList.Count;
        
        if (index < count)
            return _OrnamentList[indexInList];

        return null; // impossible
    }

    public int GetCount()
    {
        return  _HeadList.Count + _TattooList.Count + _EyesList.Count + 
                _MouthList.Count + _HairList.Count + _TopHeadList.Count + 
                _EarsList.Count + _EarsBackList.Count + _ClothesList.Count + _OrnamentList.Count;
    }
}
