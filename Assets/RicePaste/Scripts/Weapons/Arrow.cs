using System;
using RicePaste.Scripts.Manager;
using UnityEngine;

namespace RicePaste.Scripts.Weapons
{
    public class Arrow : MonoBehaviour
    {
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
        public void Init(float damage, float knockback, float speed)
        {
            _speed = speed;
            Damage = damage;
            Knockback = knockback;
        }
        private void Start()
        {
            ResetArrowSpeed();
        }
        private void OnEnable()
        {
            ResetArrowSpeed();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Enemy"))
                gameObject.SetActive(false);
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Wall"))
                gameObject.SetActive(false);
        }
        private void ResetArrowSpeed()
        {
            Vector2 mousePos = (Vector2)GameManager.Instance.player.CameraMouse;
            Vector2 dirVec = (mousePos - (Vector2)GameManager.Instance.player.transform.position).normalized;
            
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(dirVec * _speed, ForceMode2D.Impulse);
        }
    }
}

