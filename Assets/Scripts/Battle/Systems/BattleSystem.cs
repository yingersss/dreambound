using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public enum BattleState
{
    START,
    PLAYER_TURN,
    ENEMY_TURN,
    WON,
    LOST
}
public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    public Transform playerSpawn;
    // public Transform platyerSpawn2; for later use
    public Transform enemySpawn;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Text dialogueText;

    private void Start()
    {
        state = BattleState.START;
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
        Debug.Log("Battle initialized with: " + enemyData.name);

        // Spawn player
        GameObject player1 = Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity);
        var player1Stats = player1.GetComponent<CharacterCombat>(); // store player stats temporarily for battle
        // player1Stats.Initialize(GameManager.instance.playerData);

        // Spawn enemy
        GameObject enemy1 = Instantiate(enemyPrefab, enemySpawn.position, Quaternion.identity);
        var enemy1Stats = enemy1.GetComponent<CharacterCombat>();
        enemy1Stats.Initialize(enemyData);

        if (dialogueText != null)
            dialogueText.text = enemyData.name + " appeared!";
        else
            Debug.LogWarning("DialogueText not assigned in BattleSystem!");


        // Apply enemy visuals
        // SpriteRenderer sr = enemy1.GetComponent<SpriteRenderer>();
        // if (sr != null && enemyData.sprite != null)
        //    sr.sprite = enemyData.sprite;

        // Later: use enemyData to set stats, name, etc.
    }
}
