using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    public class AgentInput : MonoBehaviour
    {
        [field: SerializeField]
        public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

        private void Update()
        {
            GetMovementInput();
        }

        private void GetMovementInput()
        {
            OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }
}

