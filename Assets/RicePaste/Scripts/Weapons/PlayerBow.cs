using RicePaste.Scripts.Manager;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace RicePaste.Scripts.Weapons
{
    public class PlayerBow : Weapon
    {
        public int prefabId;
        public float damage;
        public float knockback;
        public float arrowSpeed;
        public float radius;
        public Transform arrowSpawner;

        private void Start()
        {
            Damage = damage;
            KnockBack = knockback;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            SetRadius(radius);
        }

        public void Attack()
        {
            Transform arrow = GameManager.instance.poolManager.Get(prefabId).transform;;
            arrow.transform.parent = GameManager.instance.poolManager.transform;
            
            arrow.localPosition = Vector3.zero;
            arrow.localRotation = Quaternion.identity;
            
            arrow.position = arrowSpawner.position;
            arrow.GetComponent<Arrow>().Init(damage, knockback, arrowSpeed);
            arrow.transform.rotation = Quaternion.AngleAxis(GameManager.instance.player.Angle - 180, Vector3.forward);
            arrow.GetComponent<SpriteRenderer>().flipY = GameManager.instance.player.CameraMouse.x > 0 ? true : false;
        }
    }
}
