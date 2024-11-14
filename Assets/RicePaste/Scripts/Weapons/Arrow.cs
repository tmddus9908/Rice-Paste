using RicePaste.Scripts.Manager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RicePaste.Scripts.Weapons
{
    public class Arrow : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        public float damage;
        public float speed;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
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
        public void Init(float damage, float speed)
        {
            this.damage = damage;
            this.speed = speed;
        }

        private void ResetArrowSpeed()
        {
            Vector2 mousePos = (Vector2)GameManager.Instance.player.CameraMouse;
            Vector2 dirVec = (mousePos - (Vector2)GameManager.Instance.player.transform.position).normalized;
            
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(dirVec * speed, ForceMode2D.Impulse);
        }
    }
}

