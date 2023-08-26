using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AgentMovement : MonoBehaviour
    {
        #region Variaveis
        // Componentes
        protected Rigidbody2D rb2d;

        [field: SerializeField]
        public MovementDataSO MovementData { get; set; }

        // Atributos
        [SerializeField]
        protected float currentVelocity = 3f;
        protected Vector2 movementDirection;

        // Eventos
        [field: SerializeField]
        public UnityEvent<float> OnVelocityChange { get; set; }
        #endregion

        #region Metodos
        // Metodos Unity
        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            OnVelocityChange?.Invoke(currentVelocity);
            rb2d.velocity = currentVelocity * movementDirection;
        }

        // Metodos Gerais
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
        #endregion
    }
}