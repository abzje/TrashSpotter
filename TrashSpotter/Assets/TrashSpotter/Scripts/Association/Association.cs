using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EAssociationCategory
{
    HUMAN,
    AGRICULTURE,
    ECOLOGIE,
    INDUSTRY,
    ENERGY
}

[CreateAssetMenu(fileName = "Association", menuName = "Greenoide/Association", order = 3)]
public class Association : ScriptableObject
{
    public Image _Logo;
    public string _Name;
    public EAssociationCategory _Category;
    public string _Presentation;
    public string _Actions;
    // public List<int> _DoneEventsId; useless right now
}
