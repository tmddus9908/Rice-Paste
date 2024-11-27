using System;
using RicePaste.Scripts.Manager;
using RicePaste.Scripts.Players;
using UnityEngine;

namespace RicePaste.Scripts.Weapons
{
    public class Weapon : MonoBehaviour
    {
        
        
        private BoxCollider2D _boxCollider2D;
        private Player _player;
        
        [NonSerialized]
        public float KnockBack;
        [NonSerialized]
        public float Damage;
        [NonSerialized]
        public float Radius;      
        [NonSerialized]
        public Animator Animator;
        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            Animator = GetComponent<Animator>();
            _player = GameManager.Instance.player;
        }

        private void Update()
        {
            transform.position = _player.CameraMouse;
            
            // _player.Angle = Mathf.Atan2(_player.CameraMouse.y - transform.position.y, _player.CameraMouse.x - transform.position.x) * Mathf.Rad2Deg;
            // _player.equippedWeapon.transform.rotation = Quaternion.AngleAxis(_player.Angle - 180, Vector3.forward);
            //
            // _player.equippedWeapon.GetComponent<SpriteRenderer>().flipY = _player.CameraMouse.x > 0 ? true : false;
        }

        protected virtual void OnEnable()
        {
            transform.position = GameManager.Instance.player.CameraMouse;
        }

        private void OnCollider()
        {
            _boxCollider2D.enabled = true;
        }

        private void OffCollider()
        {
            _boxCollider2D.enabled = false;
        }

        protected void SetRadius(float radius)
        {
            Radius = radius;
            GameManager.Instance.player.GetComponentInChildren<PlayerAttackRange>().Radius = this.Radius;
            GameManager.Instance.player.GetComponentInChildren<PlayerAttackRange>().SetAttackRangeSprite();
        }
        // public virtual void Attack()
        // {
        //     Debug.Log("Weapon의 Attack 입니다.");
        // }

        
    }
}

