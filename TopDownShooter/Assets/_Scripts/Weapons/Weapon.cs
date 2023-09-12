using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TopDownShooter
{
    public class Weapon : MonoBehaviour
    {
        #region Variáveis
        // Componentes
        [SerializeField] private WeaponDataSO weaponDataSO;
        [SerializeField] private GameObject muzzle;

        // Atributos
        public int ammo = 10;
        private bool isShooting = false;
        [SerializeField] private bool reloadCoroutine = false; // Remover serializacao depois

        // Eventos
        [field: SerializeField] private UnityEvent OnShoot { get; set; }
        [field: SerializeField] private UnityEvent OnShootNoAmmo { get; set; }

        // Propriedades
        private bool AmmoFull { get => Ammo >= weaponDataSO.AmmoCapacity; }

        public int Ammo
        {
            get { return ammo; }

            set
            {
                ammo = Mathf.Clamp(value, 0, weaponDataSO.AmmoCapacity);
            }
        }
        #endregion

        #region Funções Unity
        private void Start()
        {
            Ammo = weaponDataSO.AmmoCapacity;
        }

        private void Update()
        {
            UseWeapon();
        }
        #endregion

        #region Funções e Métodos Gerais
        private void UseWeapon()
        {
            // Se estou atirando e não estou carregando
            if (isShooting && !reloadCoroutine)
            {
                if (Ammo > 0)
                {
                    Ammo--;
                    OnShoot?.Invoke();

                    for(int i = 0; i < weaponDataSO.GetBulletCount(); i++)
                    {
                        ShootBullet();
                    }
                }
                else
                {
                    isShooting = false;
                    OnShootNoAmmo?.Invoke();
                    return;
                }

                FinishShooting();
            }
        }

        private void FinishShooting()
        {
            StartCoroutine(DelayNextShootCoroutine());
            if (!weaponDataSO.AutomaticFire)
            {
                isShooting = false;
            }
        }

        private IEnumerator DelayNextShootCoroutine()
        {
            reloadCoroutine = true;
            yield return new WaitForSeconds(weaponDataSO.WeaponDelay);
            reloadCoroutine = false;
        }

        private void ShootBullet()
        {
            Debug.Log("Shooting!");
        }

        public void TryShooting()
        {
            isShooting = true;
        }

        public void StopShooting()
        {
            isShooting = false;
        }

        private void ReloadAmmo(int ammo)
        {
            Ammo += ammo;
        }
        #endregion
    }
}
