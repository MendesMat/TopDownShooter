using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class AgentRenderer : MonoBehaviour
    {
        protected SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void FaceDirection(Vector2 pointerInput)
        {
            var direction = (Vector3)pointerInput - transform.position; // Input do mouse, naturalmente, é um Vector3
            
            // Usando a posição do Player como referência, calculamos a angulação de Vector2.up até direction (posição do mouse relativa ao player)
            // Se o ângulo for negativo, o mouse está à direta do player. Se o angulo é positivo, o mouse está à esquerda do player
            var result = Vector3.Cross(Vector2.up, direction);

            // Se mouse está à esquerda
            if(result.z > 0)
            {
                spriteRenderer.flipX = true;
            }
            // Se o mouse está à direita
            else if(result.z < 0) 
            {
                spriteRenderer.flipX= false;
            }
        }
    }
}
