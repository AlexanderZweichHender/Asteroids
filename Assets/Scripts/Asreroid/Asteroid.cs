using Asteroids.Player;
using System.Collections;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public delegate void OnAsteroidDestroyed();
    public static event OnAsteroidDestroyed OnAsterdoidDestroyedEvent;

    [Header("Stats:")]
    [SerializeField] private GameObject explosionEffect;
    [SerializeField, Range(0.1f, 5f)] private float speed = 1f;
    [SerializeField, Range(0, 5)] private float lifeTime = 3f;

    private void Start()
    {
        SetRandomRotation();
        StartCoroutine(DeathCoroutine());
    }

    private void Update() => Move();

    private void SetRandomRotation()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.value * 360);
    }

    private void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {    
            OnAsterdoidDestroyedEvent?.Invoke();
            Destroy(bullet.gameObject);
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }        
    }    
}
