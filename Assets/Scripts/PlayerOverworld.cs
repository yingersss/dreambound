using UnityEngine;

public class PlayerOverworld : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
            EnemyOverworld enemy = other.GetComponent<EnemyOverworld>();
            if (enemy != null)
            {
                GameManager.instance.StartBattle(enemy.enemyData);
            }
		}
	}
}
