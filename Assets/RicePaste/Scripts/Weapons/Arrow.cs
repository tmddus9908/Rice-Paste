using System;
using RicePaste.Scripts.Manager;
using UnityEngine;
using UnityEngine.Serialization;

namespace RicePaste.Scripts.Weapons
{
    public class Arrow : MonoBehaviour
    {
        public int currentCount;
        public int maxCount;
        public Vector3 Scale;
        private Rigidbody2D _rigidbody;
        [NonSerialized]
        public float Damage;
        [NonSerialized]
        public float Knockback;
        
        private float _speed;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        public void Init(float damage, float knockback, float speed, int count)
        {
            _speed = speed;
            Damage = damage;
            Knockback = knockback;
            maxCount = count;
        }
        private void Start()
        {
            ResetArrowSpeed();
            ResetArrowScale();
        }
        private void OnEnable()
        {
            ResetArrowSpeed();
            ResetArrowScale();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
                ++currentCount;

            if (currentCount >= maxCount)
            {
                gameObject.SetActive(false);
                currentCount = 0;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Wall"))
            {
                gameObject.SetActive(false);
                currentCount = 0;
            }
        }
        private void ResetArrowSpeed()
        {
            Vector2 mousePos = (Vector2)GameManager.instance.player.cameraMouse;
            Vector2 dirVec = (mousePos - (Vector2)GameManager.instance.player.transform.position).normalized;
            
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(dirVec * _speed, ForceMode2D.Impulse);
        }

        private void ResetArrowScale()
        {
            Scale = GameManager.instance.player.equippedWeapon.GetComponent<PlayerBow>().scale;
            transform.localScale = Scale;
        }
    }
}

