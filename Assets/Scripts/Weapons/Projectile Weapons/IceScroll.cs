using UnityEngine;

public class IceScroll : ProjectileWeapon
{
    [SerializeField] private int _angleFiveLelev;

    private void Start()
    {
        _isAttackCooldownReset = true;
        _attackCooldownCoroutine = StartCoroutine(AttackCooldown());
    }

    private void Update()
    {
        if (_isAttackCooldownReset == true && _isEquipped == true)
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

        RotateShootPoint();

        if (_level >= 5)
        {
            FiveShot(_angleThirdLevel, _angleFiveLelev);
        }
        else if (_level >= 3)
        {
            TrippleShot(_angleThirdLevel);
        }
        else
        {
            OneShot();
        }
    }
}
