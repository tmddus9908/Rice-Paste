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
        public int attackDamage;
        
        public RuntimeAnimatorController[] animatorControllers;
        public Rigidbody2D target;

        public bool isLive;
        public bool isHit;
        
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        private void OnEnable()
        {
            target = GameManager.instance.player.GetComponent<Rigidbody2D>();
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
            attackDamage = data.damage;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Weapon") || _animator.GetCurrentAnimatorStateInfo(0).IsName("Hit") || !isLive || isHit)
                return;

            if(other.GetComponent<Weapon>())
                health -= other.GetComponent<Weapon>().damage;
            else if(other.GetComponent<Shield>())
                health -= other.GetComponent<Shield>().damage;
            else if (other.GetComponent<Arrow>())
                health -= other.GetComponent<Arrow>().Damage;

            KnockBack(other);
            
            if (health > 0)
            {
                _animator.SetTrigger("Hit");
            }
            else
            {
                isLive = false;
                Dead();
                GameManager.instance.kill++;
                GameManager.instance.GetExp();
            }
        }

        private void KnockBack(Collider2D collision)
        {
            Vector3 playerPos = GameManager.instance.player.transform.position;
            Vector3 dirVec = (transform.position - playerPos).normalized;
            
            if(collision.GetComponent<Weapon>())
                _rigidbody.AddForce(dirVec * collision.GetComponent<Weapon>().knockBack , ForceMode2D.Impulse);
            else if(collision.GetComponent<Shield>())
                _rigidbody.AddForce(dirVec * collision.GetComponent<Shield>().knockback , ForceMode2D.Impulse);
            else if(collision.GetComponent<Arrow>())
                _rigidbody.AddForce(dirVec * collision.GetComponent<Arrow>().Knockback , ForceMode2D.Impulse);
        }
        private void Dead()
        {
            gameObject.SetActive(false);
        }
    }
}

