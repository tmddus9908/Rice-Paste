using RicePaste.Scripts.Manager;
using RicePaste.Scripts.Players;
using UnityEngine;

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
            _rigidbody.AddForce(GameManager.Instance.player.weapon.GetComponent<PlayerBow>().arrowSpawner.position * speed, ForceMode2D.Impulse);
        }

        private void OnEnable()
        {
            _rigidbody.AddForce(GameManager.Instance.player.weapon.GetComponent<PlayerBow>().arrowSpawner.position * speed, ForceMode2D.Impulse);
        }

        private void OnDisable()
        {
            _rigidbody.velocity = Vector2.zero;
        }

        public void Init(float damage, float speed)
        {
            this.damage = damage;
            this.speed = speed;
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
    }
}

