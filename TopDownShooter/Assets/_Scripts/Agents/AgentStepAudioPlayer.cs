using UnityEngine;

namespace TopDownShooter
{
    public class AgentStepAudioPlayer : AbstractAudioPlayer
    {
        [SerializeField]
        private AudioClip stepClip;
        
        // Sendo chamado no primeiro frame da animação de Walk do player
        public void PlayStepSound()
        {
            PlayClipWithVariablePitch(stepClip);
        }
    }
}
