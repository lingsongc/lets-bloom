using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TraitDefinition", menuName = "Scriptable Objects/TraitDefinition")]
public class TraitDefinition : ScriptableObject {
    public string traitName;
    public TraitDatabase.TraitCategory category;
    
    public List<string> strongTags;
    public List<string> weakTags;
    public List<string> lines;
}
