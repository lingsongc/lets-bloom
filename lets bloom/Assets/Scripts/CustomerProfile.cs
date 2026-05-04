using System.Collections.Generic;
using UnityEngine;

public class CustomerProfile {
    
    public List<TraitDefinition> preferTraits;
    public List<string> preferDescriptions;
    public List<TraitDefinition> profileTraits;
    public List<string> profileDescriptions;
    
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
}
