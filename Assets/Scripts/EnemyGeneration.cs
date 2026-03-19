using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private Enemy _enemyToSpawn;
    [SerializeField] private Transform[] _spawnPoints;
    
    private float _currentCooldown;
    private Spawner[] _spawners;
    
    private void Awake()
    {
        InitializeSpawnPoints();
        InitializeSpawners();
    }

    private void Update()
    {
        _currentCooldown += Time.deltaTime;

        if (_currentCooldown >= _spawnCooldown)
        {
            SpawnEnemy();
            _currentCooldown = 0;
        }
    }

    private void InitializeSpawnPoints()
    {
        _spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            _spawnPoints[i] = transform.GetChild(i);
    }

    private void InitializeSpawners()
    {
        _spawners = GetComponentsInChildren<Spawner>();
    }

    private void SpawnEnemy()
    {
        int randomSpawnPoint = Random.Range(0, _spawnPoints.Length);
        
        Transform spawnPoint = _spawnPoints[randomSpawnPoint];
        Spawner spawner = _spawners[randomSpawnPoint];
        
        Enemy enemy = Instantiate(_enemyToSpawn, spawnPoint.position, Quaternion.identity);
        
        enemy.Init(spawner.EnemyDirection);
    }
}