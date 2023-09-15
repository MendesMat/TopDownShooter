using System;
using UnityEngine;

namespace TopDownShooter
{
    [CreateAssetMenu(menuName = "Weapons/BulletData")]
    public class BulletDataSO : ScriptableObject
    {
        // Componentes
        [field: SerializeField] public GameObject BulletPrefab { get; set; }
        [field: SerializeField] private GameObject ImpactObstacleParticle { get; set; }
        [field: SerializeField] private GameObject ImpactEnemyParticle { get; set; }

        // Atributos
        [field: SerializeField] [field: Range(1, 100)] public float BulletSpeed { get; set; } = 1;
        [field: SerializeField] [field: Range(0, 100)] public float Friction { get; set; } = 0.1f;
        [field: SerializeField] [field: Range(1, 10)] private int Damage { get; set; } = 1;
        [field: SerializeField] [field: Range(1, 20)] private float KnockbackPower { get; set; } = 1;
        [field: SerializeField][field: Range(0.01f, 1)] private float KnockbackDelay { get; set; } = 0.1f;
        [field: SerializeField] private bool Bounce { get; set; }
        [field: SerializeField] private bool GoThrough { get; set; }
        [field: SerializeField] private bool IsRaycast { get; set; }

    }
}
