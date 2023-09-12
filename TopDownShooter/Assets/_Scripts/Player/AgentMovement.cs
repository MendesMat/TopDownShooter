using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class AgentMovement : MonoBehaviour
    {
        #region Variaveis
        // Componentes
        private Rigidbody2D rb2d;

        [field: SerializeField]
        private MovementDataSO MovementData { get; set; }

        // Atributos
        private float currentVelocity;
        private Vector2 movementDirection;

        // Eventos
        [field: SerializeField]
        private UnityEvent<float> OnVelocityChange { get; set; }
        #endregion

        #region Funções Unity
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
        #endregion

        #region Métodos Gerais
        // Invocado pelo Input Action Asset
        public void MoveAgent(Vector2 movementInput)
        {
            // Recebe a direção
            if(movementInput.magnitude > 0)
            {
                movementDirection = movementInput.normalized;
            }

            // Recebe a velocidade
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