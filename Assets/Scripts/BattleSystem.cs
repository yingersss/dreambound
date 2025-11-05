using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public Transform playerSpawn;
    public Transform enemySpawn;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    private void Start()
    {
        // Get enemy data from cache
        EnemyData enemyData = BattleDataCache.enemyEncounterData;

        if (enemyData == null)
        {
            Debug.LogError("No EnemyData found in BattleDataCache! Returning to overworld...");
            GameManager.instance.EndBattle();
            return;
        }

        InitializeBattle(enemyData);
    }

    private void InitializeBattle(EnemyData enemyData)
    {
        Debug.Log("Battle initialized with: " + enemyData.enemyName);

        // Spawn player
        Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity);

        // Spawn enemy
        GameObject enemyObj = Instantiate(enemyPrefab, enemySpawn.position, Quaternion.identity);

        // Apply enemy visuals
        SpriteRenderer sr = enemyObj.GetComponent<SpriteRenderer>();
        if (sr != null && enemyData.sprite != null)
            sr.sprite = enemyData.sprite;

        // Later: use enemyData to set stats, name, etc.
    }
}
