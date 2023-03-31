using UnityEngine;

namespace Asteroids.Player
{
    [HelpURL("https://xvideos.com")]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement stats:")]
        [SerializeField, Range(0, 10)] private float speed = 10f;
        [SerializeField, Range(0, 200)] private float turnSpeed = 100f;

        [Header("Effects:")]
        [SerializeField] private ParticleSystem engineEffect;

        private InputConfig inputActions;

        private void Awake()
        {
            inputActions = new InputConfig();
        }

        private void OnEnable() => inputActions.Enable();
        private void OnDisable() => inputActions.Disable();

        private void LateUpdate()
        {
            Vector2 direction = inputActions.Player.Move.ReadValue<Vector2>();
            Move(direction);
        }

        /// <summary>
        /// Moves player in the direction
        /// </summary>
        /// <param name="direction"></param>
        private void Move(Vector2 direction)
        {            
            float inptuMagnitude = Mathf.Clamp01(direction.magnitude);
            transform.Translate(direction * speed * inptuMagnitude * Time.deltaTime, Space.World);
            Rotate(direction);
            SetEngineActivity(direction);
        }

        /// <summary>
        /// Rotates player in the direction
        /// </summary>
        /// <param name="direction"></param>
        private void Rotate(Vector2 direction)
        {
            if (direction != Vector2.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(transform.forward, direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, turnSpeed * Time.deltaTime);
            }
        }

        private void SetEngineActivity(Vector2 direction)
        {
            if(direction == Vector2.zero)
            {
                engineEffect.Stop();
            }
            else
            { 
                engineEffect.Play();
            }
        }
    }
}
