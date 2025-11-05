using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState  // add more states as needed
{
    Overworld,
    Battle
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; } // Singleton instance
    public GameState currentState { get; private set; } = GameState.Overworld;

    private void Awake()
    {
        if (instance != null && instance != this) // Ensure only one instance exists
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject); // Persist across scenes
    }

    public void SetState(GameState newState)
    {
        currentState = newState;
        Debug.Log("Game State changed to: " + newState);
    }

    public void StartBattle(EnemyData enemyData)
    {
        SetState(GameState.Battle);
        BattleDataCache.enemyEncounterData = enemyData;
        SceneManager.LoadScene("BattleScene");
    }
    
    
    public void EndBattle()
	{
        SetState(GameState.Overworld);
        SceneManager.LoadScene("OverworldScene");
	}

}
