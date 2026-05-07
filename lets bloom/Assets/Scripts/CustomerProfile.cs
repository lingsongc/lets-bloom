using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomerProfile {
    
    public List<TraitDefinition> preferTraits;
    private List<string> preferDescriptions;
    public List<TraitDefinition> profileTraits;
    private List<string> profileDescriptions;
    
    private SpriteDatabase spriteDatabase;
    public int spriteID;
    public Sprite sprite;

    public void SetSpriteDatabase(SpriteDatabase database) {
        spriteDatabase = database;
    }
    
    public void SetTraits(List<TraitDefinition> preferTraitList, List<string> preferDescriptionList,
        List<TraitDefinition> profileTraitList, List<string> profileDescriptionList) {
        preferTraits = preferTraitList;
        preferDescriptions = preferDescriptionList;
        profileTraits = profileTraitList;
        profileDescriptions = profileDescriptionList;
    }

    public void SetHappy() {
        sprite = spriteDatabase.GetHappySprite(spriteID);
    }

    public void SetSad() {
        sprite = spriteDatabase.GetSadSprite(spriteID);
    }

    public string GetPreferDescription() {
        return string.Join("\n \n", preferDescriptions);
    }
    
    public string GetProfileDescription() {
        return string.Join("\n \n", profileDescriptions);
    }
}
