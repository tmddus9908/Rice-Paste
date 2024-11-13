using UnityEngine;

namespace RicePaste.Scripts.Weapons
{
    public class Weapon : MonoBehaviour
    {
        private BoxCollider2D _boxCollider2D;
    
        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }
        private void OnCollider()
        {
            _boxCollider2D.enabled = true;
        }

        private void OffCollider()
        {
            _boxCollider2D.enabled = false;
        }
    }
}

