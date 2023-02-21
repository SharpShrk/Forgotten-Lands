using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damage;

    private string _tagCollider = "DamageCollider";
    private string _tagTarget = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.tag == _tagCollider && collision.tag == _tagTarget)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
            {
                player.ApplyDamage(_damage);
            }
        }        
    }
}
