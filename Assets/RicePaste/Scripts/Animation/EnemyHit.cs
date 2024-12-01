using UnityEngine;

namespace RicePaste.Scripts.Animation
{
    public class EnemyHit : StateMachineBehaviour
    {
        private Enemy.Enemy _enemy;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _enemy = animator.GetComponent<Enemy.Enemy>();
            _enemy.isHit = true;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _enemy.isHit = false;
            animator.ResetTrigger("Hit");
        }
    }
}

