using UnityEngine;

public class FirePillar : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _duration;
    [SerializeField] private float _timeBetweenDamage;
    [SerializeField] private float _damageOverTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
            enemy.TakeBurning(_duration, _timeBetweenDamage, _damageOverTime);
        }
    }
}
