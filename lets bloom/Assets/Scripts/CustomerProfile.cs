using System.Collections.Generic;
using UnityEngine;

public class CustomerProfile {
    
    private List<TraitDefinition> preferTraits;
    private List<string> preferDescriptions;
    private List<TraitDefinition> profileTraits;
    private List<string> profileDescriptions;
    
    public void SetTraits(List<TraitDefinition> preferTraitList, List<string> preferDescriptionList,
        List<TraitDefinition> profileTraitList, List<string> profileDescriptionList) {
        preferTraits = preferTraitList;
        preferDescriptions = preferDescriptionList;
        profileTraits = profileTraitList;
        profileDescriptions = profileDescriptionList;
    }
}
