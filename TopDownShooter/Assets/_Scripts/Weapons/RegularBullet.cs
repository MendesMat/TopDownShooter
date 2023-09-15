using UnityEngine;

namespace TopDownShooter
{
    public class RegularBullet : AbstractBullet
    {
        private Rigidbody2D rb;

        public override BulletDataSO BulletData 
        { 
            get => base.BulletData;

            set
            {
                base.BulletData = value;
                rb = GetComponent<Rigidbody2D>();
                rb.drag = BulletData.Friction;
            }
        }

        private void FixedUpdate()
        {
            MoveBullet();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                HitObstacle();
            }

            Destroy(gameObject);
        }

        private void MoveBullet()
        {
            if (rb != null && BulletData != null)
            {
                rb.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);
            }
        }

        private void HitObstacle()
        {

        }
    }
}
