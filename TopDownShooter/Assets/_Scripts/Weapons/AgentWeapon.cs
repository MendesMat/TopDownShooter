using UnityEngine;

namespace TopDownShooter
{
    public class AgentWeapon : MonoBehaviour
    {
        // Componentes - OBS remover serializeField depois
        [SerializeField] private Weapon weapon;
        [SerializeField] private WeaponRenderer weaponRenderer;
        
        // Atributos
        private float aimAngle;

        private void Awake()
        {
            AssignWeapon();
        }

        private void AssignWeapon()
        {
            weapon = GetComponentInChildren<Weapon>();
            weaponRenderer = GetComponentInChildren<WeaponRenderer>();    
        }

        private void AimWeapon(Vector2 pointerPosition)
        {
            var aimDirection = (Vector3)pointerPosition - transform.position;

            // Recebe o angulo da mira em graus
            aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            AdjustWeaponRendering();

            transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.forward);
        }

        // Ajusta o sprite da arma de acordo com a angulação da mira
        private void AdjustWeaponRendering()
        {
            if (weaponRenderer != null)
            {
                weaponRenderer.FlipSprite(aimAngle > 90 || aimAngle < -90);
                weaponRenderer.RenderBehindPlayer(aimAngle < 180 && aimAngle > 0);
            }
        }

        private void StartShooting()
        {
            if (weapon != null)
            {
                weapon.TryShooting();
            }    
        }

        private void StopShooting()
        {
            if(weapon != null)
            {
                weapon.StopShooting();
            }
        }
    }
} 
