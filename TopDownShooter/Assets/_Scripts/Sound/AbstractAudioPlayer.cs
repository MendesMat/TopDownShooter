using UnityEngine;

namespace TopDownShooter
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class AbstractAudioPlayer : MonoBehaviour
    {   
        #region Variaveis
        // Componentes
        private AudioSource audioSource;

        // Atributos
        [SerializeField]
        private float pitchRandomness = 0.05f;
        private float basePitch;
        #endregion

        #region Metodos
        // Metodos Unity
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            basePitch = audioSource.pitch;
        }

        protected void PlayClipWithVariablePitch(AudioClip clip)
        {
            var randomPitch = Random.Range(-pitchRandomness, pitchRandomness);
            audioSource.pitch = basePitch + randomPitch;
            PlayClip(clip);
        }

        private void PlayClip(AudioClip clip)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
        #endregion
    }
}
