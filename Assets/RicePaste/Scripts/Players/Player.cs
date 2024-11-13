using RicePaste.Scripts.Weapons;
using UnityEngine;
using UnityEngine.InputSystem;


namespace RicePaste.Scripts.Players
{
    public class Player : MonoBehaviour
    {
        public float speed;
        public Vector2 inputVec;

        public bool isAttack;
        public Weapon weapon;
        Rigidbody2D _rigidbody;
        SpriteRenderer _spriteRenderer;
        Animator _animator;
    
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }
        private void FixedUpdate()
        {
            Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
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
            if (Mouse.current.leftButton.isPressed)
            {
                Vector2 mousePosition = Mouse.current.position.ReadValue();
                Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector2(mousePosition.x, mousePosition.y));
                weapon.transform.position = pos;
                float angle = Mathf.Atan2(pos.y - transform.position.y, pos.x - transform.position.x) * Mathf.Rad2Deg;
                weapon.transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
                // _weapon.gameObject.SetActive(true);
                if (pos.x > 0)
                    weapon.GetComponent<SpriteRenderer>().flipY = true;
                else
                    weapon.GetComponent<SpriteRenderer>().flipY = false;
            
                isAttack = true;

            }
        }

        public void OnMove(InputValue value)
        {
            inputVec = value.Get<Vector2>();
        }
    }

}
