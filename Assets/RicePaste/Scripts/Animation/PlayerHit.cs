using RicePaste.Scripts.Players;
using UnityEngine;

namespace RicePaste.Scripts.Animation
{
    public class PlayerHit : StateMachineBehaviour
    {
        private Player _player;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _player = animator.GetComponent<Player>();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _player.isHit = false;
            animator.ResetTrigger("Hit");
        }
    }
}