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
            var direction = (Vector3)pointerInput - transform.position; // Input do mouse, naturalmente, � um Vector3
            
            // Usando a posi��o do Player como refer�ncia, calculamos a angula��o de Vector2.up at� direction (posi��o do mouse relativa ao player)
            // Se o �ngulo for negativo, o mouse est� � direta do player. Se o angulo � positivo, o mouse est� � esquerda do player
            var result = Vector3.Cross(Vector2.up, direction);

            // Se mouse est� � esquerda
            if(result.z > 0)
            {
                spriteRenderer.flipX = true;
            }
            // Se o mouse est� � direita
            else if(result.z < 0) 
            {
                spriteRenderer.flipX= false;
            }
        }
    }
}
