using UnityEngine;

namespace RicePaste.Scripts.Weapons.AnimCS
{
    public class StateIdle : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("isAttack", true);
        }
    }
}

