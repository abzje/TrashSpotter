using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BodypartList", menuName = "Greenoide/BodypartList", order = 2)]
public class BodypartList : ScriptableObject
{
    public List<BodypartAsset> _BodypartList;

    public BodypartAsset GetBodypartAsset(int id)
    {
        foreach (BodypartAsset b in _BodypartList)
            if (b._Id == id)    
                return b;
        return null;
    }
}
