using UnityEngine;

namespace TopDownShooter
{
    [RequireComponent(typeof(Animator))]
    public class AgentAnimations : MonoBehaviour
    {
        private Animator agentAnimator;

        private void Awake()
        {
            agentAnimator = GetComponent<Animator>();
        }

        private void SetWalkAnimation(bool val)
        {
            agentAnimator.SetBool("Walk", val);
        }

        private void AnimatePlayer(float velocity)
        {
            SetWalkAnimation(velocity > 0);
        }
    }
}