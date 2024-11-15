using System;
using RicePaste.Scripts.Manager;
using UnityEngine;

namespace RicePaste.Scripts.Weapons
{
    public class Weapon : MonoBehaviour
    {
        private BoxCollider2D _boxCollider2D;
        
        [NonSerialized]
        public float _knockBack;
        [NonSerialized]
        public float _damage;
        [NonSerialized]
        public Animator Animator;
        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            Animator = GetComponent<Animator>();
        }
        private void OnCollider()
        {
            _boxCollider2D.enabled = true;
        }

        private void OffCollider()
        {
            _boxCollider2D.enabled = false;
        }

        // public virtual void Attack()
        // {
        //     Debug.Log("Weapon의 Attack 입니다.");
        // }

        
    }
}

