using UnityEngine;
using Random = UnityEngine.Random;
using RicePaste.Scripts.Manager;

namespace RicePaste.Scripts.Enemy
{
    public class Spawner : MonoBehaviour
    {
        public Transform[] spawnPoint;
        public SpawnData[] spawnData;
    
        private int _level;
        private float _timer;

        private void Awake()
        {
            spawnPoint = GetComponentsInChildren<Transform>();
        }

        void Update()
        {
            _timer += Time.deltaTime;
            _level = Mathf.Min(Mathf.FloorToInt(GameManager.Instance.gameTime / 10f), spawnData.Length - 1); // 소수점 아래 삭제 후 정수만 사용, CeilToInt -> 소수점 아래 올리고 Int로 사용
        
            if (_timer > spawnData[_level].spawnTime)
            {
                _timer = 0;
                Spawn();
            }
        }

        private void Spawn()
        {
            GameObject enemy = GameManager.Instance.poolManager.Get(0);
            enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
            enemy.GetComponent<Enemy>().Init(spawnData[_level]);
        }
    }

// 직렬화 -> 개체를 저장 혹은 전송하기 위해 변환
    [System.Serializable]
    public class SpawnData
    {
        public int spriteType;
        public float spawnTime;
        public int health;
        public float speed;
    }
}
