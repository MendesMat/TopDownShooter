using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace TopDownShooter
{
    public class Weapon : MonoBehaviour
    {
        #region Variáveis
        // Componentes
        [SerializeField] private WeaponDataSO weaponData;
        [SerializeField] private GameObject muzzle;

        // Atributos
        public int ammo = 10;
        private bool isShooting = false;
        [SerializeField] private bool reloadCoroutine = false; // Remover serializacao depois

        // Eventos
        [field: SerializeField] private UnityEvent OnShoot { get; set; }
        [field: SerializeField] private UnityEvent OnShootNoAmmo { get; set; }

        // Propriedades
        private bool AmmoFull { get => Ammo >= weaponData.AmmoCapacity; }

        public int Ammo
        {
            get { return ammo; }

            set
            {
                ammo = Mathf.Clamp(value, 0, weaponData.AmmoCapacity);
            }
        }
        #endregion

        #region Funções Unity
        private void Start()
        {
            Ammo = weaponData.AmmoCapacity;
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

                    for(int i = 0; i < weaponData.GetBulletCount(); i++)
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
            if (!weaponData.AutomaticFire)
            {
                isShooting = false;
            }
        }

        private IEnumerator DelayNextShootCoroutine()
        {
            reloadCoroutine = true;
            yield return new WaitForSeconds(weaponData.WeaponDelay);
            reloadCoroutine = false;
        }

        private void ShootBullet()
        {
            SpawnBullet(muzzle.transform.position, CalculateBulletAngle(muzzle));
        }

        private void SpawnBullet(Vector3 position, Quaternion angle)
        {
            var bulletPrefab = Instantiate(weaponData.BulletData.BulletPrefab, position, angle);
            bulletPrefab.GetComponent<AbstractBullet>().BulletData = weaponData.BulletData;
        }

        private Quaternion CalculateBulletAngle(GameObject muzzle)
        {
            float spread = Random.Range(-weaponData.spreadAngle, weaponData.spreadAngle);
            Quaternion bulletSpread = Quaternion.Euler(new Vector3(0, 0, spread));
            return muzzle.transform.rotation * bulletSpread;
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
