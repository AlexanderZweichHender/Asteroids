using System.Collections;
using UnityEngine;

namespace Asteroids.Player
{
    public class PlayerGun : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField, Range(0, 100)] private float fireRate = 1f;
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bulletPrefab;

        [Header("Sounds:")]
        [SerializeField] private AudioSource source;
        [SerializeField] private AudioClip shootSound;

        private bool canFire = true;
        private InputConfig inputActions;

        private void Awake()
        {
            inputActions = new InputConfig();
            inputActions.Player.Shoot.performed += context => Shoot();
        }

        private void OnEnable() => inputActions.Enable();
        private void OnDisable() => inputActions.Disable();

        private void Shoot()
        {
            if(canFire)
            {
                StartCoroutine(Fire());
            }
        }

        private IEnumerator Fire()
        {
            canFire = false;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            PlayShootSound();
            StartCoroutine(FireRateHandler());
            yield return null;
        }

        private IEnumerator FireRateHandler()
        {
            float timeToNextFire = 1 / fireRate;
            yield return new WaitForSeconds(timeToNextFire);
            canFire = true;
        }

        private void PlayShootSound()
        {
            if(Time.timeScale != 0)
            {
                source.PlayOneShot(shootSound);
            }            
        }
    }
}
