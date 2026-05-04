using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "TraitDefinition", menuName = "Scriptable Objects/TraitDefinition")]
public class TraitDefinition : ScriptableObject {
    public string traitName;
    public TraitDatabase.TraitCategory category;
    
    public List<string> strongTags;
    public List<string> weakTags;
    public List<string> lines;

    public int NumStrongMatch(TraitDefinition otherTrait) {
        return this.strongTags.Intersect(otherTrait.strongTags).Count();
    }
    
    public int NumWeakMatch(TraitDefinition otherTrait) {
        return this.weakTags.Intersect(otherTrait.weakTags).Count();
    }
}
