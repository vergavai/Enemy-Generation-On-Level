using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3 _enemyDirection;

    public Vector3 EnemyDirection => _enemyDirection;
}
