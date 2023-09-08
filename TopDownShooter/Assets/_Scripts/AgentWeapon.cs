using UnityEngine;

namespace TopDownShooter
{
    public class AgentWeapon : MonoBehaviour
    {
        protected float aimAngle;

        public virtual void AimWeapon(Vector2 pointerPosition)
        {
            var aimDirection = (Vector3)pointerPosition - transform.position;

            aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.forward);
        }
    }
}
