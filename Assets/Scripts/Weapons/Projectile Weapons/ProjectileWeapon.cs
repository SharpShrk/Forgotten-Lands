using System.Collections;
using UnityEngine;

public abstract class ProjectileWeapon : Weapons
{
    [SerializeField] protected Transform _shootPoint;
    [SerializeField] private ObjectPool _projectilePool;

    [SerializeField] protected int _angleThirdLevel;
    [SerializeField] protected float _attackCooldown = 1f;

    protected bool _isAttackCooldownReset;
    protected Coroutine _attackCooldownCoroutine;

    protected void OneShot()
    {
        GameObject projectile = _projectilePool.GetObject();
        RotateProjectile(projectile);
    }

    protected void TrippleShot(int angle)
    {
        GameObject leftProjectile = _projectilePool.GetObject();
        RotateProjectile(leftProjectile);
        leftProjectile.transform.Rotate(new Vector3(0, 0, leftProjectile.transform.rotation.z + angle));

        GameObject rightProjectile = _projectilePool.GetObject();
        RotateProjectile(rightProjectile);
        rightProjectile.transform.Rotate(new Vector3(0, 0, leftProjectile.transform.rotation.z - angle));

        GameObject projectile = _projectilePool.GetObject();
        RotateProjectile(projectile);
    }

    protected void FiveShot(int angle, int angleFiveLelev)
    {
        TrippleShot(angle);

        GameObject leftLeftProjectile = _projectilePool.GetObject();
        RotateProjectile(leftLeftProjectile);
        leftLeftProjectile.transform.Rotate(new Vector3(0, 0, leftLeftProjectile.transform.rotation.z + angleFiveLelev));

        GameObject rightRightProjectile = _projectilePool.GetObject();
        RotateProjectile(rightRightProjectile);
        rightRightProjectile.transform.Rotate(new Vector3(0, 0, rightRightProjectile.transform.rotation.z - angleFiveLelev));
    }

    protected IEnumerator AttackCooldown()
    {
        var attackCooldown = new WaitForSeconds(_attackCooldown);

        _isAttackCooldownReset = false;

        yield return attackCooldown;

        _isAttackCooldownReset = true;
    }

    private void RotateProjectile(GameObject projectile)
    {
        projectile.transform.position = _shootPoint.position;
        projectile.transform.rotation = _shootPoint.rotation;
    }
}
