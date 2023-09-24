using UnityEngine;

namespace TopDownShooter
{
    public class AgentStepAudioPlayer : AbstractAudioPlayer
    {
        [SerializeField]
        private AudioClip stepClip;
        
        // Sendo chamado no primeiro frame da anima��o de Walk do player
        public void PlayStepSound()
        {
            PlayClipWithVariablePitch(stepClip);
        }
    }
}
