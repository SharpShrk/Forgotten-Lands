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

    private float _spawnTime;

    private void Start()
    {
        _spawnTime = _timeAfterLastSpawn;
    }

    private void Update()
    {
        InstantiateEnemy();
    }

    private void InstantiateEnemy()
    {
        if (_spawnTime < 0)
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

            _spawnTime = _timeAfterLastSpawn;
        }
        else
        {
            _spawnTime -= Time.deltaTime;
        }          
    }
}
