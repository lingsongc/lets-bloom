using UnityEngine;

[CreateAssetMenu(fileName = "SpriteDatabase", menuName = "Scriptable Objects/SpriteDatabase")]
public class SpriteDatabase : ScriptableObject {
    public Sprite[] defaultSprites;
    public Sprite[] happySprites;
    public Sprite[] sadSprites;

    public int GetRandomID() {
        return Random.Range(0, defaultSprites.Length);
    }
    
    public Sprite GetDefaultSprite(int id) {
        return defaultSprites[id];
    }
    
    public Sprite GetHappySprite(int id) {
        return happySprites[id];
    }
    
    public Sprite GetSadSprite(int id) {
        return sadSprites[id];
    }
}
