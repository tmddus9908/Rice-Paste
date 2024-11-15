using System;

namespace RicePaste.Scripts.Weapons
{
    public class Shield : Weapon
    {
        public float damage;
        public float knockback;
        [NonSerialized]
        public int per;

        public void Init(float damage, int per)
        {
            this.damage = damage;
            this.per = per;
            _damage = damage;
            _knockBack = knockback;
        }
    }
}

