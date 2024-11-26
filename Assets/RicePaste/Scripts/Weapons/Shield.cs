using System;
using UnityEngine;

namespace RicePaste.Scripts.Weapons
{
    public class Shield : MonoBehaviour
    {
        public float damage;
        public float knockback;
        [NonSerialized]
        public int per;

        public void Init(float damage, int per)
        {
            this.damage = damage;
            this.per = per;
        }
    }
}

