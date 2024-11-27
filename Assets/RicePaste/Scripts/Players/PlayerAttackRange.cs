using System;
using RicePaste.Scripts.Manager;
using UnityEngine;

namespace RicePaste.Scripts.Players
{
    public class PlayerAttackRange : MonoBehaviour
    {
        public Vector2 center;
        [NonSerialized]
        public float Radius;
        
        private void Update()
        {
            Debug.Log(Radius);
            center = GameManager.Instance.player.transform.position;

            float distance = Vector2.Distance(center, GameManager.Instance.player.CameraMouse);

            if (distance > Radius)
                GameManager.Instance.player.equippedWeapon.gameObject.SetActive(false);

            else if (distance <= Radius)
                GameManager.Instance.player.equippedWeapon.gameObject.SetActive(true);
        }

        public void SetAttackRangeSprite()
        {
            transform.localScale = new Vector2(Radius * 2, Radius * 2);
        }
    }
}
