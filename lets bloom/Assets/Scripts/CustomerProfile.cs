using System.Collections.Generic;
using UnityEngine;

public class CustomerProfile {
    
    public List<TraitDefinition> preferTraits;
    public List<string> preferDescriptions;
    public List<TraitDefinition> profileTraits;
    public List<string> profileDescriptions;
    
    public int spriteID;
    public Sprite sprite;
    
    public void SetTraits(List<TraitDefinition> preferTraitList, List<string> preferDescriptionList,
        List<TraitDefinition> profileTraitList, List<string> profileDescriptionList) {
        preferTraits = preferTraitList;
        preferDescriptions = preferDescriptionList;
        profileTraits = profileTraitList;
        profileDescriptions = profileDescriptionList;
    }
}
