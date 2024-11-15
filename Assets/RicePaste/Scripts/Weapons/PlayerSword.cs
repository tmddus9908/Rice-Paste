using UnityEngine;

namespace RicePaste.Scripts.Weapons
{
    public class PlayerSword : Weapon
    {
        public float damage;
        public float knockback;
        
        private void Start()
        {
            _damage = damage;
            _knockBack = knockback;
        }
        // public override void Attack()
        // {
        //     return;
        // }
    }    
}

