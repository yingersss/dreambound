using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    OVERWORLD,
    BATTLE
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameState currentState { get; private set; } = GameState.OVERWORLD;

    [Header("Player Data Reference")]
    public PlayerData playerData; // <-- Add this

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetState(GameState newState)
    {
        currentState = newState;
        Debug.Log("Game State changed to: " + newState);
    }

    public void StartBattle(EnemyData enemyData)
    {
        SetState(GameState.BATTLE);
        BattleDataCache.enemyEncounterData = enemyData;
        SceneManager.LoadScene("BattleScene");
    }

    public void EndBattle()
    {
        SetState(GameState.OVERWORLD);
        SceneManager.LoadScene("OverworldScene");
    }
}
