using RicePaste.Scripts.Manager;
using RicePaste.Scripts.Players;
using UnityEngine;

namespace RicePaste.Scripts.Weapons.AnimCS
{
    public class StateIdle : StateMachineBehaviour
    {
        private Player _player;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _player = GameManager.Instance.player;
            animator.SetBool("isAttack", false);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if(_player.isAttack)
                animator.SetBool("isAttack", true);

        }
    }
}

