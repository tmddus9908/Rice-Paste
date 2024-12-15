using System;
using RicePaste.Scripts.Manager;
using RicePaste.Scripts.Weapons;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


namespace RicePaste.Scripts.Players
{
    public class Player : MonoBehaviour
    {
        public Vector2 inputVec;
        public Vector2 cameraMouse;
        public float angle;
        public int statusPoint;
        
        public float attackCooldown;
        public float moveSpeed;
        public bool isAttack;
        public bool isHit;
        public Weapon[] weapons = new Weapon[3];
        public Weapon equippedWeapon;

        private int _weaponCount;
        private float _lastAttackTime = -Mathf.Infinity;
       
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
    
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }
        private void FixedUpdate()
        {
            Vector2 nextVec = inputVec * moveSpeed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(_rigidbody.position + nextVec);
        }

        private void LateUpdate()
        {
            _animator.SetFloat("Speed", inputVec.magnitude);
        
            if (inputVec.x != 0)
                _spriteRenderer.flipX = inputVec.x > 0;
        }

        private void Update()
        {
            SetWeaponPos();
            if (Mouse.current.leftButton.isPressed && Time.time >= _lastAttackTime + attackCooldown)
            {
                // Attack();
                isAttack = true;
                _lastAttackTime = Time.time;
            }
            else if (!Mouse.current.leftButton.isPressed)
            {
                isAttack = false;
            }
            else if (Time.time < _lastAttackTime + attackCooldown)
                isAttack = false;
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            Hit(other);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Hit(other);
        }

        private void Hit(Collision2D other)
        {
            if (GameManager.instance.health > 0)
            {
                if (other.transform.CompareTag("Enemy") && !isHit)
                {
                    isHit = true;
                    GameManager.instance.health -= other.gameObject.GetComponent<Enemy.Enemy>().attackDamage;
                    // KnockBack(other);
                    _animator.SetTrigger("Hit");
                }
            }

            else if (GameManager.instance.health <= 0)
            {
                _animator.SetTrigger("Dead");
                Test2();
            }
        }
        public void OnMove(InputValue value)
        {
            inputVec = value.Get<Vector2>();
        }

        public void OnSwap()
        {
            SwapWeapon();
        }
        private void SetWeaponPos()
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            cameraMouse= Camera.main.ScreenToWorldPoint(new Vector2(mousePosition.x, mousePosition.y));
            
            angle = Mathf.Atan2(cameraMouse.y - transform.position.y, cameraMouse.x - transform.position.x) * Mathf.Rad2Deg;
            equippedWeapon.transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
            
            equippedWeapon.GetComponent<SpriteRenderer>().flipY = cameraMouse.x > 0 ? true : false;
        }

        // private void KnockBack(Collision2D collision)
        // {
        //     Vector3 enemyPos = collision.transform.position;
        //     Vector3 dirVec = (transform.position - enemyPos).normalized;
        //     Debug.Log(dirVec);
        //     _rigidbody.AddForce(dirVec * 5f, ForceMode2D.Impulse);
        // }
        
        private void SwapWeapon()
        {
            equippedWeapon.gameObject.SetActive(false);
            
            ++_weaponCount;
            
            equippedWeapon = weapons[_weaponCount];
            
           Test();

            if (_weaponCount == 2)
                _weaponCount = -1;
        }

        private async void Test()
        {
            equippedWeapon.gameObject.SetActive(true);

            await Task.Delay(1);
            equippedWeapon.SetRadius(equippedWeapon.radius);
            equippedWeapon.SetScale(equippedWeapon.scale);
            equippedWeapon.SetCooldown(equippedWeapon.cooldown);
        }

        private async void Test2()
        {
            await Task.Delay(1);
            equippedWeapon.SetScale(Vector3.zero);
            GameManager.instance.uiManager.escui.EscUI();
        }
    }
}
