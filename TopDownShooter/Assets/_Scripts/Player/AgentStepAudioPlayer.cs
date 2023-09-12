using UnityEngine;

namespace TopDownShooter
{
    [RequireComponent(typeof(AudioSource))]
    public class AgentStepAudioPlayer : MonoBehaviour
    {
        #region Variaveis
        // Componentes
        private AudioSource audioSource;

        // Atributos
        [SerializeField]
        private float pitchRandomness = 0.05f;
        private float basePitch;

        [SerializeField]
        private AudioClip stepClip;
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
        
        private void PlayClipWithVariablePitch(AudioClip clip)
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

        // Sendo chamado no primeiro frame da animação de Walk do player
        public void PlayStepSound()
        {
            PlayClipWithVariablePitch(stepClip);
        }
        #endregion
    }
}
