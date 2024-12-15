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

        // public int level;
        public float knockBack;
        public float damage;
        public float radius;
        public Vector3 scale;
        public float cooldown;
        
        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _player = GameManager.instance.player;
        }

        protected virtual void Start()
        {
            damage = itemData.baseDamage;
            knockBack = itemData.baseKnockback;
            radius = itemData.baseRange;
            scale = itemData.baseScale;
            cooldown = itemData.baseCooldown;
            SetRadius(radius);
            SetScale(scale);
            SetCooldown(cooldown);
        }

        private void Update()
        {
            transform.position = _player.cameraMouse;
        }

        protected virtual void OnEnable()
        {
            transform.position = GameManager.instance.player.cameraMouse;
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

        public void SetScale(Vector3 Scale)
        {
            scale = Scale;
            gameObject.transform.localScale = Scale;
        }

        public void SetCooldown(float CoolDown)
        {
            cooldown = CoolDown;
            GameManager.instance.player.attackCooldown = cooldown;
        }
        public void SetMeleeWeaponStatus(float KnockBack, float Damage, float Radius, Vector3 Scale, float CoolDown)
        {
            knockBack = KnockBack;
            damage = Damage;
            radius = Radius;
            scale = Scale;
            SetRadius(radius);
            SetScale(scale);
            SetCooldown(CoolDown);
        }
        // public virtual void Attack()
        // {
        //     Debug.Log("Weapon의 Attack 입니다.");
        // }
    }
}

