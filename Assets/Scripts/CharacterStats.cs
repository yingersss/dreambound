using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    public string name;
    public int level;
    public int maxHP;
    public int currentHP;
    public int attack;
    public int defense;
    public int speed;
}

public abstract class CharacterData : ScriptableObject
{
    public Sprite sprite;
    public CharacterStats stats;
}
