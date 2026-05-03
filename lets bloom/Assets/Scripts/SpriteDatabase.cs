using UnityEngine;

[CreateAssetMenu(fileName = "SpriteDatabase", menuName = "Scriptable Objects/SpriteDatabase")]
public class SpriteDatabase : ScriptableObject {
    public Sprite[] defaultSprites;
    public Sprite[] happySprites;
    public Sprite[] sadSprites;

    public int GetRandomID() {
        return Random.Range(0, defaultSprites.Length);
    }
    
    public Sprite getDefaultSprite(int id) {
        return defaultSprites[id];
    }
}
