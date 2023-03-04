using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyMover))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _armor;
    [SerializeField] private GameObject _coin;
    [SerializeField] private ParticleSystem _particleBurning;

    private ObjectPool _pool;
    private Player _targetPlayer;
    private CoinSpawner _coinSpawner;
    private bool _isBurning;
    private Coroutine _takeBurningCoroutine;
    private EnemyMover _mover;
    private Shop _shop;
    private float _currentArmor;

    public Player Target => _targetPlayer; 

    private void Start()
    {
        _isBurning = false;
        _mover = GetComponent<EnemyMover>();
        _coinSpawner = FindObjectOfType<CoinSpawner>();
        _pool = FindObjectOfType<ObjectPool>();
        _currentArmor = _armor;        
    }

    private void OnEnable()
    {
        _shop = FindObjectOfType<Shop>();
        _shop.GameRestarted += EnemyDestroing;
    }

    private void OnDisable()
    {
        _shop.GameRestarted -= EnemyDestroing;
    }

    public void Init(Player target)
    {
        _targetPlayer = target;
    }

    public void ApplyDamage(float damage)
    {   
        if (_currentArmor < damage)
        {
            _health = _health - (damage - _currentArmor);
            TryDying();
        }        
    }

    public void ReduceArmor(float deltaArmor)
    {
        _currentArmor -= deltaArmor;

        if(_armor <= 0)
        {
            _currentArmor = 0;
        }
    }

    public void ReturnArmor()
    {
        _currentArmor = _armor;
    }

    public void ReduceSpeed(float duration, float speedReductionValue)
    {
        _mover.ReduceSpeed(duration, speedReductionValue);
    }

    public void TakeBurning(float duration, float timeBetweenDamage, float damage)
    {
        if (_isBurning == true)
        {
            return;
        }
        else
        {
            if (_takeBurningCoroutine != null)
            {
                StopCoroutine(_takeBurningCoroutine);
            }

            _isBurning = true;

            _takeBurningCoroutine = StartCoroutine(ApplyBurning(duration, timeBetweenDamage, damage));
            _particleBurning.Play();
        }             
    }

    private IEnumerator ApplyBurning(float duration, float timeBetweenDamage, float damage)
    {
        var damageCooldown = new WaitForSeconds(duration);
        Coroutine _applyDamageOverTimeCoroutine;

        _applyDamageOverTimeCoroutine = StartCoroutine(ApplyBurningDamageOverTime(timeBetweenDamage, damage));

        yield return damageCooldown;

        _isBurning = false;

        _particleBurning.Stop();
        StopCoroutine(_applyDamageOverTimeCoroutine);
    }

    private IEnumerator ApplyBurningDamageOverTime(float timeBetweenDamage, float damage)
    {
        var burningCooldown = new WaitForSeconds(timeBetweenDamage);

        while (_isBurning)
        {
            if (_currentArmor < damage)
            {
                _health = _health - (damage - _currentArmor);
                TryDying();
            }

            yield return burningCooldown;
        }             
    }

    private void TryDying()
    {
        if (_health <= 0)
        {
            _coinSpawner.SpawnCoin(transform.position);
            EnemyDestroing();

            PlayerLevel playerLevel = _targetPlayer.GetComponent<PlayerLevel>();
            playerLevel.AddExperincePoint();
            _targetPlayer.AddScore();
        }
    }

    private void EnemyDestroing()
    {
        _pool.ReturnObject(gameObject);
    }
}
