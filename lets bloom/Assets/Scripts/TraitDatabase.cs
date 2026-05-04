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
    
    [SerializeField] private int exactMatchScore = 5;
    [SerializeField] private int strongMatchScore = 2;
    [SerializeField] private int weakMatchScore = 1;
    [SerializeField] private int timeoutPenalty = -2;
    
    
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

    public int GetScore(CustomerProfile customerA, CustomerProfile customerB) {
        int score = 0;

        foreach (var preferTraitA in customerA.preferTraits) {
            foreach (var profileTraitB in customerB.profileTraits) {
                if (preferTraitA.traitName == profileTraitB.traitName) {
                    score += exactMatchScore;
                } else {
                    score += preferTraitA.NumStrongMatch(profileTraitB) * strongMatchScore;
                    score += preferTraitA.NumWeakMatch(profileTraitB) * weakMatchScore;
                }
            }
        }
        
        foreach (var preferTraitB in customerB.preferTraits) {
            foreach (var profileTraitA in customerA.profileTraits) {
                if (preferTraitB.traitName == profileTraitA.traitName) {
                    score += exactMatchScore;
                } else {
                    score += preferTraitB.NumStrongMatch(profileTraitA) * strongMatchScore;
                    score += preferTraitB.NumWeakMatch(profileTraitA) * weakMatchScore;
                }
            }
        }
        
        return score;
    }
}
