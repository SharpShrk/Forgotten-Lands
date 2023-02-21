using UnityEngine;

public class IceBlast : Projectile
{
    [SerializeField] private float _duration;
    [SerializeField] private float _speedReductionValue;    

    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ReduceSpeed(_duration, _speedReductionValue);

            Destroy(gameObject);
        }
    }
}
