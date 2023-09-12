using UnityEngine;

namespace TopDownShooter
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class WeaponRenderer : MonoBehaviour
    {
        [SerializeField] protected int playerSortingOrder;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void FlipSprite(bool val)
        {
            // O código comentado abaixo gera um bug no posicionamento do sprite
            // SpriteRenderer.flipY = val;

            float flipModifier = val ? -1 : 1;
            flipModifier *= Mathf.Abs(transform.localScale.y);

            transform.localScale = new Vector3(transform.localScale.x, flipModifier);
        }

        public void RenderBehindPlayer(bool val)
        {
            if (val)
            {
                spriteRenderer.sortingOrder = playerSortingOrder - 1;
            }
            else
            {
                spriteRenderer.sortingOrder = playerSortingOrder + 1;
            }
        }
    }
}
