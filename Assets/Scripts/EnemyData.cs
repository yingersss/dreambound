using UnityEngine;

[CreateAssetMenu(fileName = "Combat/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int health;
    public int level;
    public GameObject prefab;
    public Sprite sprite;
}
