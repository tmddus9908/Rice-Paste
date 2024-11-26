using System;
using RicePaste.Scripts.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


namespace RicePaste.Scripts.Players
{
    public class Player : MonoBehaviour
    {
        [NonSerialized]
        public Vector2 InputVec;
        [NonSerialized]
        public Vector2 CameraMouse;
        [NonSerialized]
        public float Angle;
        
        public float attackCooldown;
        public float moveSpeed;
        public bool isAttack;
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
            Vector2 nextVec = InputVec * moveSpeed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(_rigidbody.position + nextVec);
        }

        private void LateUpdate()
        {
            _animator.SetFloat("Speed", InputVec.magnitude);
        
            if (InputVec.x != 0)
                _spriteRenderer.flipX = InputVec.x > 0;
        }

        private void Update()
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            CameraMouse= Camera.main.ScreenToWorldPoint(new Vector2(mousePosition.x, mousePosition.y));
            
            if (Mouse.current.leftButton.isPressed && Time.time >= _lastAttackTime + attackCooldown)
            {
                Attack();
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

        public void OnMove(InputValue value)
        {
            InputVec = value.Get<Vector2>();
        }

        public void OnSwap()
        {
            SwapWeapon();
        }
        private void Attack()
        {
            Angle = Mathf.Atan2(CameraMouse.y - transform.position.y, CameraMouse.x - transform.position.x) * Mathf.Rad2Deg;
            equippedWeapon.transform.rotation = Quaternion.AngleAxis(Angle - 180, Vector3.forward);
            
            equippedWeapon.GetComponent<SpriteRenderer>().flipY = CameraMouse.x > 0 ? true : false;
        }

        private void SwapWeapon()
        {
            ++_weaponCount;
            equippedWeapon = weapons[_weaponCount];
            if (_weaponCount == 2)
                _weaponCount = -1;
        }
    }
}
