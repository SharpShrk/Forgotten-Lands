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

/*
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private int _spawned;
    private float _timeAfterLastSpawn;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count >= _currentWaveNumber + 1)
            {
                AllEnemySpawned?.Invoke();
            }

            _currentWave = null;
        }
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;

        _player.AddMoney(enemy.Reward);
    }

    [System.Serializable]
    public class Wave
    {
        public GameObject Template;
        public float Delay;
        public int Count;
    }
 */

