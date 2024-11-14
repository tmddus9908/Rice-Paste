using UnityEngine;

namespace RicePaste.Scripts.Weapons
{
    public class PlayerSword : Weapon
    {
        public float damage;
        
        private void Start()
        {
            _damage = damage;
        }

        // private void OnEnable()
        // {
        //     Animator.stop
        // }

        private void OnDisable()
        {
            
        }
        public override void Attack()
        {
            return;
        }
    }    
}

