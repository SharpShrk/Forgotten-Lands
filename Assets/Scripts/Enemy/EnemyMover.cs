using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Enemy enemy;
    private Coroutine _takeSlowdownSpeedCoroutine;
    private bool _isSlow;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        _isSlow = false;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, enemy.Target.transform.position, _speed * Time.deltaTime);
    }

    public void ReduceSpeed(float duration, float speedReductionValue)
    {
        if (_isSlow == true)
        {
            return;
        }
        else
        {
            if (_takeSlowdownSpeedCoroutine != null)
            {
                StopCoroutine(_takeSlowdownSpeedCoroutine);
            }

            _isSlow = true;
            _takeSlowdownSpeedCoroutine = StartCoroutine(ApplySlowdownSpeed(duration, speedReductionValue));
        }
    }

    private IEnumerator ApplySlowdownSpeed(float duration, float speedReductionValue)
    {
        float currentSpeed = _speed;
        var slowdownDuration = new WaitForSeconds(duration);

        _speed = _speed * speedReductionValue;

        yield return slowdownDuration;

        _speed = currentSpeed;
        _isSlow = false;
    }
}
