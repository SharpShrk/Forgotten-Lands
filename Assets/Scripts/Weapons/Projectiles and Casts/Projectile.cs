using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected float _damage;
    [SerializeField] protected float _speed;

    protected Camera mainCamera;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float cameraHalfHeight = mainCamera.orthographicSize;

        if (transform.position.x < mainCamera.transform.position.x - cameraHalfWidth ||
            transform.position.x > mainCamera.transform.position.x + cameraHalfWidth ||
            transform.position.y < mainCamera.transform.position.y - cameraHalfHeight ||
            transform.position.y > mainCamera.transform.position.y + cameraHalfHeight)
        {
            Destroy(gameObject);
        }
    }    
}
