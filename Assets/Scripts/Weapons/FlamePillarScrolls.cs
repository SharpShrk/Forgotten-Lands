using System.Collections;
using UnityEngine;

public class FlamePillarScrolls : Weapons
{
    [SerializeField] private float _range;
    [SerializeField] private float _radius;
    [SerializeField] private float _duration;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private GameObject _firePillarPrefab;

    private bool _isAttackCooldownReset;
    private Coroutine _firePillarCoroutine;
    private Coroutine _attackCooldownCoroutine;

    private void Start()
    {
        _isAttackCooldownReset = false;
        _attackCooldownCoroutine = StartCoroutine(AttackCooldown());
    }

    private void Update()
    {
        if (_isAttackCooldownReset == true  && _isEquipped == true)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (_attackCooldownCoroutine != null)
        {
            StopCoroutine(_attackCooldownCoroutine);
        }

        _attackCooldownCoroutine = StartCoroutine(AttackCooldown());

        _firePillarCoroutine = StartCoroutine(CastFirePillar());
    }

    private IEnumerator CastFirePillar()
    {
        var duration = new WaitForSeconds(_duration);

        Vector3 randomPosition = transform.position + Random.insideUnitSphere * _range;
        GameObject firePillar = Instantiate(_firePillarPrefab, randomPosition, Quaternion.identity);
        firePillar.transform.localScale = Vector3.one * _radius;

        yield return duration;

        Destroy(firePillar);
    }

    private IEnumerator AttackCooldown()
    {
        var attackCooldown = new WaitForSeconds(_attackCooldown);

        _isAttackCooldownReset = false;

        yield return attackCooldown;

        _isAttackCooldownReset = true;
    }
}

