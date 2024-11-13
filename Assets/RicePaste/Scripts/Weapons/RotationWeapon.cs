using RicePaste.Scripts.Manager;
using UnityEngine;

namespace RicePaste.Scripts.Weapons
{
    public class RotationWeapon : MonoBehaviour
    {
        public int id;
        public int prefabId;
        public float damage;
        public int count;
        public float speed;


        private void Start()
        {
            Init();
        }

        private void Update()
        {
            switch (id)
            {
                case 0:
                    transform.Rotate(Vector3.back * speed * Time.deltaTime); // Vector3.forward(0,0,1)
                    break;
            }

            if (Input.GetButtonDown("Jump"))
            {
                LevelUp(20, 1);
            }
        }

        private void LevelUp(float damage, int count)
        {
            this.damage = damage;
            this.count += count;

            if (id == 0)
            {
                Batch();
            }
        }

        private void Init()
        {
            switch (id)
            {
                case 0:
                    speed = -150;
                    Batch();
                    break;
            }
        }

        private void Batch()
        {
        
            for (int i = 0; i < count; i++)
            {
                Transform shield;
                if (i < transform.childCount)
                {
                    shield = transform.GetChild(i);
                }
                else
                {
                    shield = GameManager.Instance.poolManager.Get(prefabId).transform;
                    shield.transform.parent = transform;
                }

                shield.localPosition = Vector3.zero;
                shield.localRotation = Quaternion.identity;
            
                Vector3 rotVec = Vector3.back * 360 * i / count;
                shield.Rotate(rotVec);
                shield.Translate(shield.up * 1.5f, Space.World);
                shield.GetComponent<Shield>().Init(damage, -1); // -1 is infinity per
            }
        }
    }
}

