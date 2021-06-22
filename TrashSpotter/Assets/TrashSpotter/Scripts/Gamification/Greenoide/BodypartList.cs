using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BodypartList", menuName = "Trashspotter/Do not use/BodypartList", order = 5)]
public class BodypartList : ScriptableObject
{
    public List<BodypartAsset> headList;
    public List<BodypartAsset> tattooList;
    public List<BodypartAsset> eyesList;
    public List<BodypartAsset> mouthList;
    public List<BodypartAsset> hairList;
    public List<BodypartAsset> topHeadList;
    public List<Ears> earsList;
    public List<BodypartAsset> clothesList;
    public List<BodypartAsset> ornamentList;

    public BodypartAsset GetHeadAsset(int id)
    {
        foreach (BodypartAsset b in headList)
            if (b.id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetTattooAsset(int id)
    {
        foreach (BodypartAsset b in tattooList)
            if (b.id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetEyesAsset(int id)
    {
        foreach (BodypartAsset b in eyesList)
            if (b.id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetMouthAsset(int id)
    {
        foreach (BodypartAsset b in mouthList)
            if (b.id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetHairAsset(int id)
    {
        foreach (BodypartAsset b in hairList)
            if (b.id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetTopHeadAsset(int id)
    {
        foreach (BodypartAsset b in topHeadList)
            if (b.id == id)    
                return b;
        return null;
    }

    public Ears GetEarsAsset(int id)
    {
        foreach (Ears b in earsList)
            if (b.id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetClothesAsset(int id)
    {
        foreach (BodypartAsset b in clothesList)
            if (b.id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetOrnamentAsset(int id)
    {
        foreach (BodypartAsset b in ornamentList)
            if (b.id == id)    
                return b;
        return null;
    }

    public BodypartAsset GetBodypartAsset(int index)
    {
        if (index >= GetCount() || index < 0)
            return null;
        
        int count = headList.Count; // Used to find in which list to find the asset
        int indexInList = index; // We subtract index with the size of the list we go through so the index is the right one when we get to the right list
        
        // We go through each list until we find the right one
        // HEAD
        if (index < count)
            return headList[indexInList];
        
        // TATTOO
        count += tattooList.Count;
        indexInList -= headList.Count;
        
        if (index < count)
            return tattooList[indexInList];

        // EYES
        count += eyesList.Count;
        indexInList -= tattooList.Count;
        
        if (index < count)
            return eyesList[indexInList];

        // MOUTH
        count += mouthList.Count;
        indexInList -= eyesList.Count;
        
        if (index < count)
            return mouthList[indexInList];

        // HAIR
        count += hairList.Count;
        indexInList -= mouthList.Count;
        
        if (index < count)
            return hairList[indexInList];

        // TOP HEAD
        count += topHeadList.Count;
        indexInList -= hairList.Count;
        
        if (index < count)
            return topHeadList[indexInList];

        // EARS
        count += earsList.Count;
        indexInList -= topHeadList.Count;
        
        if (index < count)
            return earsList[indexInList];

        // CLOTHES
        count += clothesList.Count;
        indexInList -= earsList.Count;
        
        if (index < count)
            return clothesList[indexInList];

        // ORNAMENT
        count += ornamentList.Count;
        indexInList -= clothesList.Count;
        
        if (index < count)
            return ornamentList[indexInList];

        return null; // impossible
    }

    public int GetCount()
    {
        return  headList.Count + tattooList.Count + eyesList.Count + 
                mouthList.Count + hairList.Count + topHeadList.Count + 
                earsList.Count + clothesList.Count + ornamentList.Count;
    }
}
