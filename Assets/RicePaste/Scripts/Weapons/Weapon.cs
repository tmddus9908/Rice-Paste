using System;
using RicePaste.Scripts.Item;
using RicePaste.Scripts.Manager;
using RicePaste.Scripts.Players;
using UnityEngine;
using UnityEngine.Serialization;

namespace RicePaste.Scripts.Weapons
{
    public class Weapon : MonoBehaviour
    {
        
        
        private BoxCollider2D _boxCollider2D;
        private Player _player;
        
        public ItemData itemData;
        
        [FormerlySerializedAs("KnockBack")] public float knockBack;
        public float damage;
        public float radius;      
        [NonSerialized]
        public Animator Animator;
        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            Animator = GetComponent<Animator>();
            _player = GameManager.instance.player;
        }

        protected virtual void Start()
        {
            damage = itemData.baseDamage;
            knockBack = itemData.baseKnockback;
            radius = itemData.baseRange;
            SetRadius(radius);
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
            transform.position = GameManager.instance.player.CameraMouse;
        }

        private void OnCollider()
        {
            _boxCollider2D.enabled = true;
        }

        private void OffCollider()
        {
            _boxCollider2D.enabled = false;
        }

        public void SetRadius(float Radius)
        {
            radius = Radius;
            GameManager.instance.player.GetComponentInChildren<PlayerAttackRange>().Radius = radius;
            GameManager.instance.player.GetComponentInChildren<PlayerAttackRange>().SetAttackRangeSprite();
        }

        public void SetMeleeWeaponStatus(float KnockBack, float Damage, float Radius)
        {
            knockBack = KnockBack;
            damage = Damage;
            radius = Radius;
            SetRadius(radius);
        }
        // public virtual void Attack()
        // {
        //     Debug.Log("Weapon의 Attack 입니다.");
        // }

        
    }
}

