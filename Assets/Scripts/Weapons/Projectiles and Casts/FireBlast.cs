using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlast : Projectile
{
    [SerializeField] private float _duration;
    [SerializeField] private float _timeBetweenDamage;
    [SerializeField] private float _damageOverTime;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeBurning(_duration, _timeBetweenDamage, _damageOverTime);

            Destroy(gameObject);
        }
    }
}