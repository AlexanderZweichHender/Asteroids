using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Stats:")]
    [SerializeField, Range(0, 100)] private float bulletSpeed = 1f;
    [SerializeField] private float bulletLifeTime = 5f;

    private void Start() => StartCoroutine(DeathCoroutine());
    private void LateUpdate() => Move();

    private void Move()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }   
}
