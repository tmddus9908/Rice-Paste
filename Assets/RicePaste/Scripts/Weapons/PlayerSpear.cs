using UnityEngine;

namespace RicePaste.Scripts.Weapons
{
    public class PlayerSpear : Weapon
    {
        public float damage;
        public float knockback;
        public float radius;

        private void Start()
        {
            Damage = damage;
            KnockBack = knockback;
            SetRadius(radius);
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            SetRadius(radius);
        }
        // public override void Attack()
        // {
        //     return;
        // }
    }    
}

