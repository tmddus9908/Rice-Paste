using System;
using RicePaste.Scripts.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;


namespace RicePaste.Scripts.Players
{
    public class Player : MonoBehaviour
    {
        public float attackCooldown;
        private float _lastAttackTime = -Mathf.Infinity;
        
        
        
        public float moveSpeed;
        
        public bool isAttack;
        public Weapon weapon;
        
        [NonSerialized]
        public Vector2 InputVec;
        [NonSerialized]
        public Vector2 CameraMouse;
        [NonSerialized]
        public float Angle;
        
        
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
            if (Mouse.current.leftButton.isPressed && Time.time >= _lastAttackTime + attackCooldown)
            {
                Attack();
                _lastAttackTime = Time.time;
            }
            else if (!Mouse.current.leftButton.isPressed)
                weapon.gameObject.SetActive(false);
        }

        public void OnMove(InputValue value)
        {
            InputVec = value.Get<Vector2>();
        }

        private void Attack()
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            CameraMouse= Camera.main.ScreenToWorldPoint(new Vector2(mousePosition.x, mousePosition.y));
            weapon.transform.position = CameraMouse;
            
            weapon.gameObject.SetActive(true);
            
            Angle = Mathf.Atan2(CameraMouse.y - transform.position.y, CameraMouse.x - transform.position.x) * Mathf.Rad2Deg;
            weapon.transform.rotation = Quaternion.AngleAxis(Angle - 180, Vector3.forward);

            weapon.GetComponent<SpriteRenderer>().flipY = CameraMouse.x > 0 ? true : false;

            weapon.Attack();
        }
    }
}
