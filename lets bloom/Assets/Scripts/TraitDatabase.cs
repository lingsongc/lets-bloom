using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TraitDatabase", menuName = "Scriptable Objects/TraitDatabase")]
public class TraitDatabase : ScriptableObject {
    public enum TraitCategory {
        Appearance,
        Personality,
        Trait,
        Hobby
    }
    
    public List<TraitDefinition> appearances;
    public List<TraitDefinition> personalities;
    public List<TraitDefinition> traits;
    public List<TraitDefinition> hobbies;
    
    public List<TraitDefinition> GetTraits() {
        return new List<TraitDefinition>() {
            SelectTrait(appearances),
            SelectTrait(personalities),
            SelectTrait(traits),
            SelectTrait(hobbies)
        };
    }

    public TraitDefinition SelectTrait(List<TraitDefinition> category) {
        // Access a random Trait from the category
        int index = Random.Range(0, category.Count);
        return category[index];
    }

    public List<string> GetDescriptions(List<TraitDefinition> traitDefs) {
        List<string> descriptions = new List<string>();
        
        // Access a random Description from each trait
        foreach (var trait in traitDefs) {
            descriptions.Add(trait.lines[Random.Range(0, trait.lines.Count)]);
        }
        
        return descriptions;
    }
}
