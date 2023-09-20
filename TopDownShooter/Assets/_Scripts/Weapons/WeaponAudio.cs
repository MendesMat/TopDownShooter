using UnityEngine;

namespace TopDownShooter
{
    public class WeaponAudio : AbstractAudioPlayer
    {
        [SerializeField] private AudioClip shootBulletClip = null;
        [SerializeField] private AudioClip outOfBulletsClip = null;

        public void PlayShootSound()
        {
            PlayClipWithVariablePitch(shootBulletClip);
        }

        public void PlayOutOfBulletsSound()
        {
            PlayClipWithVariablePitch(outOfBulletsClip);
        }
    }
}
