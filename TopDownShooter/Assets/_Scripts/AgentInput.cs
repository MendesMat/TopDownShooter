using System;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    public class AgentInput : MonoBehaviour
    {
        #region Variaveis
        // Componentes
        private Camera mainCamera;

        // Eventos
        [field: SerializeField]
        public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

        [field: SerializeField]
        public UnityEvent<Vector2> OnPointerPositionChange { get; set; }
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
        }

        // Metodos Gerais
        private void GetPointerInput()
        {
            // Garantindo que a profundidade (eixo z), seja referente à main camera
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

