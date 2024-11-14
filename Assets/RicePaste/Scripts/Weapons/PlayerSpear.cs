using UnityEngine;

namespace RicePaste.Scripts.Weapons
{
    public class PlayerSpear : Weapon
    {
        public float damage;

        private void Start()
        {
            _damage = damage;
        }

        // public override void Attack()
        // {
        //     return;
        // }
    }    
}

