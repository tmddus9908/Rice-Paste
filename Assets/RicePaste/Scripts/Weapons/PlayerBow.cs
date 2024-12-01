using RicePaste.Scripts.Manager;
using UnityEngine;

namespace RicePaste.Scripts.Weapons
{
    public class PlayerBow : Weapon
    {
        public int prefabId;
        public float arrowSpeed;
        public int arrowCount;
        public Transform arrowSpawner;


        protected override void Start()
        {
            base.Start();
            arrowCount = itemData.baseCount;
        }

        public void Attack()
        {
            Transform arrow = GameManager.instance.poolManager.Get(prefabId).transform;;
            arrow.transform.parent = GameManager.instance.poolManager.transform;
            
            arrow.localPosition = Vector3.zero;
            arrow.localRotation = Quaternion.identity;
            
            arrow.position = arrowSpawner.position;
            arrow.GetComponent<Arrow>().Init(damage, knockBack, arrowSpeed, arrowCount);
            arrow.transform.rotation = Quaternion.AngleAxis(GameManager.instance.player.angle - 180, Vector3.forward);
            arrow.GetComponent<SpriteRenderer>().flipY = GameManager.instance.player.cameraMouse.x > 0 ? true : false;
        }

        public void SetRangeWeaponStatus(float KnockBack, float Damage, float Radius,  int Speed, int Count, Vector3 Scale, float CoolDown)
        {
            knockBack = KnockBack;
            damage = Damage;
            radius = Radius;
            scale = Scale;
            arrowSpeed += Speed;
            arrowCount = Count;
            GameManager.instance.player.attackCooldown = CoolDown;
            SetRadius(radius);
            SetScale(scale);
            SetCooldown(CoolDown);
        }
    }
}
