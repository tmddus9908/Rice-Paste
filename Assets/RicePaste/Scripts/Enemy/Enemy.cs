using System.Collections;
using UnityEngine;
using RicePaste.Scripts.Manager;
using RicePaste.Scripts.Weapons;

namespace RicePaste.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public float speed;
        public float health;
        public float maxHealth;
    
        public RuntimeAnimatorController[] animatorControllers;
        public Rigidbody2D target;

        public bool isLive;
    
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        private void OnEnable()
        {
            target = GameManager.Instance.player.GetComponent<Rigidbody2D>();
            isLive = true;
            health = maxHealth;
        }

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            if (!isLive || _animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
                return;
        
            Vector2 dirVec = target.position - _rigidbody.position;
            Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        
            _rigidbody.MovePosition(_rigidbody.position + nextVec);
            _rigidbody.velocity = Vector2.zero;
        }

        private void LateUpdate()
        {
            if (!isLive)
                return;

            _spriteRenderer.flipX = target.position.x > _rigidbody.position.x;
        }

        public void Init(SpawnData data)
        {
            _animator.runtimeAnimatorController = animatorControllers[data.spriteType];
            speed = data.speed;
            maxHealth = data.health;
            health = data.health;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.tag)
            {
                case "Shield":
                    health -= other.GetComponent<Shield>().damage;
                    StartCoroutine(KnockBack());
                    break;
                case "Weapon":
                    health -= other.GetComponent<Weapon>()._damage;
                    StartCoroutine(KnockBack());
                    break;
                case "Arrow":
                    health -= other.GetComponent<Arrow>().damage;
                    StartCoroutine(KnockBack());
                    break;
                
                default:
                    return;
            }
            if (health > 0)
            {
                _animator.SetTrigger("Hit");
            }
            else
            {
                Dead();
            }
        }

        IEnumerator KnockBack()
        {
            yield return null;
            Vector3 playerPos = GameManager.Instance.player.transform.position;
            Vector3 dirVec = (transform.position - playerPos).normalized;
            _rigidbody.AddForce(dirVec * 3, ForceMode2D.Impulse);
        }
        private void Dead()
        {
            gameObject.SetActive(false);
        }
    }
}

