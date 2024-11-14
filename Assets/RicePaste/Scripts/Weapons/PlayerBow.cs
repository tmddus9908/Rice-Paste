using RicePaste.Scripts.Manager;
using UnityEngine;

namespace RicePaste.Scripts.Weapons
{
    public class PlayerBow : Weapon
    {
        public int prefabId;
        public float damage;
        public float speed;
        public Transform arrowSpawner;

        private void Start()
        {
            _damage = damage;
        }
        public void Attack()
        {
            Transform arrow = GameManager.Instance.poolManager.Get(prefabId).transform;;
            arrow.transform.parent = GameManager.Instance.poolManager.transform;
            
            arrow.localPosition = Vector3.zero;
            arrow.localRotation = Quaternion.identity;
            
            arrow.position = arrowSpawner.position;
            arrow.GetComponent<Arrow>().Init(damage, speed);
            arrow.transform.rotation = Quaternion.AngleAxis(GameManager.Instance.player.Angle - 180, Vector3.forward);
            arrow.GetComponent<SpriteRenderer>().flipY = GameManager.Instance.player.CameraMouse.x > 0 ? true : false;
            
        }
    }
}
