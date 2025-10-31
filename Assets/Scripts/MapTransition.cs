using Unity.Cinemachine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundary;
    [SerializeField] Direction direction;
    [SerializeField] float transitionDistance = 1f;
    CinemachineConfiner2D confiner;
    enum Direction {
        Up,
        Down,
        Left,
        Right
    }

    private void Awake()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundary;
            UpdatePlayerPosition(collision.gameObject);
        }
    }
    
    private void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPos = player.transform.position;

        switch (direction)
        {
            case Direction.Up:
                newPos.y += transitionDistance;
                break;
            case Direction.Down:
                newPos.y -= transitionDistance;
                break;
            case Direction.Left:
                newPos.x -= transitionDistance;
                break;
            case Direction.Right:
                newPos.x += transitionDistance;
                break;
        }
        player.transform.position = newPos;
	}
}
