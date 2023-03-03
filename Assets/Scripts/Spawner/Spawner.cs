using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _timeAfterLastSpawn = 1f;
    [SerializeField] private int _numberEnemiesinAtPoint;
    [SerializeField] private float _spawnPointRadius;
    [SerializeField] private Player _player;
    [SerializeField] private ObjectPool _enemyPool;
    [SerializeField] private Shop _shop;

    private bool _spawning;
    private Coroutine _spawnCoroutine;

    private void OnEnable()
    {
        
        _shop.GameRestarted += StartSpawningEnemies;
        _player.GameOver += StopSpawningEnemies;
    }

    private void OnDisable()
    {
        _shop.GameRestarted -= StartSpawningEnemies;
        _player.GameOver -= StopSpawningEnemies;
    }

    private void Start()
    {
        StartSpawningEnemies();
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        _spawning = true;

        while (_spawning)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

            for (int i = 0; i < _numberEnemiesinAtPoint; i++)
            {
                GameObject enemy = _enemyPool.GetObject();

                enemy.transform.position = spawnPoint.position + Random.insideUnitSphere * _spawnPointRadius;
                enemy.transform.rotation = spawnPoint.rotation;

                enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, spawnPoint.transform.position.z);

                Enemy enemyScript = enemy.GetComponent<Enemy>();
                enemyScript.Init(_player);
            }

            yield return new WaitForSeconds(_timeAfterLastSpawn);
        }
    }

    private void StopSpawningEnemies()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }

        _spawning = false;
    }

    private void StartSpawningEnemies()
    {
        _spawnCoroutine = StartCoroutine(SpawnEnemiesCoroutine());
    }
}
