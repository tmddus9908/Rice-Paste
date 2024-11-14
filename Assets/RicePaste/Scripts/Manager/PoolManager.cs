using System.Collections.Generic;
using UnityEngine;

namespace RicePaste.Scripts.Manager
{
    public class PoolManager : MonoBehaviour
    {
        // .. 프리펩들을 보관할 변수
        public GameObject[] prefabs;
        // .. 풀 담당을 하는 리스트들
        private List<GameObject>[] _pools;

        private void Awake()
        {
            _pools = new List<GameObject>[prefabs.Length];

            for (int i = 0; i < _pools.Length; i++)
            {
                _pools[i] = new List<GameObject>();
            }
        }

        public GameObject Get(int index)
        {
            GameObject select = null;
            // .. 선택한 풀의 놀고(비활성화된) 있는 게임오브젝트 접근
            foreach (GameObject item in _pools[index])
            {
                if (!item.activeSelf)
                {
                    // .. 발견하면 select 변수에 할당
                    select = item;
                    select.SetActive(true);
                    break;
                }
            }
            // .. 못찾으면
            if (!select)
            {
                // .. 새롭게 생성해서 select 변수에 할당
                select = Instantiate(prefabs[index], transform);
                _pools[index].Add(select); 
            }
            return select;
        }
    }
}

