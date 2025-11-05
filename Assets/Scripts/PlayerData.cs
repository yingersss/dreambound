using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Battle/Player Data")]
public class PlayerData : CharacterData
{
    public int currentExp;
    public int nextLevelExp;
    public int skillPoints;
}
