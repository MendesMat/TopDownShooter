using UnityEngine;

namespace TopDownShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AgentMovement : MonoBehaviour
    {
        protected Rigidbody2D rb2d; // inicializado no inspector

        [field: SerializeField]
        public MovementDataSO MovementData { get; set; }

        [SerializeField]
        protected float currentVelocity = 3f;
        protected Vector2 movementDirection;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rb2d.velocity = currentVelocity * movementDirection.normalized;
        }

        public void MoveAgent(Vector2 movementInput)
        {
            if(movementInput.magnitude > 0)
            {
                movementDirection = movementInput.normalized;
            }

            currentVelocity = CalculateSpeed(movementInput);
        }

        private float CalculateSpeed(Vector2 movementInput)
        {
            if (movementInput.magnitude > 0)
            {
                currentVelocity += MovementData.acceleration * Time.deltaTime;
            }

            else
            {
                currentVelocity -= MovementData.deacceleration * Time.deltaTime;
            }

            return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);
        }
    }
}