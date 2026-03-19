using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private GameObject _enemyToSpawn;
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
        
        Enemy enemy = Instantiate(_enemyToSpawn, spawnPoint.position, Quaternion.identity).GetComponent<Enemy>();
        enemy.Init(spawner.EnemyDirection);
        _currentCooldown = 0;
    }
}