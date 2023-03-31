using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    [SerializeField,Range(0,100)] private float lifeTime = 2f;

    private void Start() => StartCoroutine(DeathCoroutine());

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
