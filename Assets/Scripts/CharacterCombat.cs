using UnityEngine;

// this class is used to copy character stats into a class during battle
// it's temporary so that we can modify stats when needed in health and dispose of it after battle without affecting the original data
public class CharacterCombat : MonoBehaviour
{
    public string characterName;
    public int currentHP;
    public int maxHP;
    public int attack;
    public int defense;
    public SpriteRenderer spriteRenderer; // for displaying visuals later

    public void Initialize(CharacterData data)
    {
        if (data == null)
            {
                Debug.LogError("CharacterCombat.Initialize received null data!");
                return;
            }
        characterName = data.stats.name;
        maxHP = data.stats.maxHP;
        currentHP = data.stats.currentHP;
        attack = data.stats.attack;
        defense = data.stats.defense;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer && data.sprite)
            spriteRenderer.sprite = data.sprite;
        
        Debug.Log($"Initialized {characterName} with {maxHP} HP");

    }
}
