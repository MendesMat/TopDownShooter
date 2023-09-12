using System;
using UnityEngine;

namespace TopDownShooter
{
    [CreateAssetMenu(menuName = "Weapons/WeaponData")]
    public class WeaponDataSO : ScriptableObject
    {
        [field: SerializeField] [field: Range(0,100)] public int AmmoCapacity { get; set; }
        [field: SerializeField] public bool AutomaticFire { get; set; }
        [field: SerializeField] [field: Range(0.1f, 2)] public float WeaponDelay { get; set; }
        [field: SerializeField] [field: Range(0, 10)] private float spreadAngle { get; set; }

        [SerializeField] private bool multiBulletShoot;
        [SerializeField] [Range(1, 10)] private int bulletsPerShot = 1;

        internal int GetBulletCount()
        {
            if (multiBulletShoot)
            {
                return bulletsPerShot;
            }

            return 1;
        }
    }
}