using UnityEngine;

namespace TopDownShooter
{
    public abstract class AbstractBullet : MonoBehaviour
    {
        [field: SerializeField] public virtual BulletDataSO BulletData { get; set; }
    }
}
