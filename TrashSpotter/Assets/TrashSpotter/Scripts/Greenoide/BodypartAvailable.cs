using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BodypartAvailable", menuName = "Greenoide/BodypartAvailable", order = 2)]
public class BodypartAvailable : ScriptableObject
{
    public List<BodypartAsset> _AvailableBodyparts;

    public BodypartAsset GetBodypartAsset(int id)
    {
        foreach (BodypartAsset b in _AvailableBodyparts)
            if (b._Id == id)    
                return b;
        return null;
    }
}
