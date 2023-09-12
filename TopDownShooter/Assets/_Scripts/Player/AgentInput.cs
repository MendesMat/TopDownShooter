using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    public class AgentInput : MonoBehaviour
    {
        #region Variaveis
        // Componentes
        private Camera mainCamera;

        // Atributos
        private bool fireButtonDown = false;

        // Eventos
        [field: SerializeField]
        private UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

        [field: SerializeField]
        private UnityEvent<Vector2> OnPointerPositionChange { get; set; }

        [field: SerializeField]
        private UnityEvent OnFireButtonPressed { get; set; }

        [field: SerializeField]
        private UnityEvent OnFireButtonReleased { get; set; }
        #endregion

        #region Metodos
        // Metodos Unity
        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            GetMovementInput();
            GetPointerInput();
            GetFireInput();
        }

        private void GetFireInput()
        {
            if (Input.GetAxisRaw("Fire1") > 0)
            {
                if (!fireButtonDown)
                {
                    fireButtonDown = true;
                    OnFireButtonPressed?.Invoke();
                }    
            }
            else
            {
                if (fireButtonDown)
                {
                    fireButtonDown = false;
                    OnFireButtonReleased?.Invoke();
                }       
            }
        }

        // Metodos Gerais
        private void GetPointerInput()
        {
            // Garantindo que a profundidade (eixo z) seja referente à main camera, ou seja, em 2D
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mainCamera.nearClipPlane;

            var mouseInWorldSpace = mainCamera.ScreenToWorldPoint(mousePosition);
            OnPointerPositionChange?.Invoke(mouseInWorldSpace);
        }

        private void GetMovementInput()
        {
            OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
        #endregion
    }
}

