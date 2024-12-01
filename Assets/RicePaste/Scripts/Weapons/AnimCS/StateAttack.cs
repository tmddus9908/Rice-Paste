using UnityEngine;

namespace RicePaste.Scripts.Weapons.AnimCS
{
    public class StateAttack : StateMachineBehaviour
    {
        private Weapon _weapon;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _weapon = animator.GetComponent<Weapon>();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            float time = stateInfo.normalizedTime;
            if(time >= 1)
            {
                animator.SetBool("isAttack", false);
                _weapon.gameObject.SetActive(false);
            }
        }
    }
}