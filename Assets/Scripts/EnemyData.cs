using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Battle/Enemy Data")]
public class EnemyData : CharacterData
{
    [TextArea] public string description;
    public int expReward;
    public int goldReward;
}
