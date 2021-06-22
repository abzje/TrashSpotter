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

[CreateAssetMenu(fileName = "Association", menuName = "Trashspotter/Association/Association", order = 4)]
public class Association : ScriptableObject
{
    public Sprite logo;
    public string assoName;
    public EAssociationCategory category;
    public string presentation;
    public string actions;
    // public List<int> _DoneEventsId; useless right now
}
