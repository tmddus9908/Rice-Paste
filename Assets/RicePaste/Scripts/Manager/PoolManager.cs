using System.Collections.Generic;
using UnityEngine;

namespace RicePaste.Scripts.Manager
{
    public class PoolManager : MonoBehaviour
    {
        // .. 프리펩들을 보관할 변수
        public GameObject[] prefabs;
        // .. 풀 담당을 하는 리스트들
        public List<GameObject>[] Pools;

        private void Awake()
        {
            Pools = new List<GameObject>[prefabs.Length];

            for (int i = 0; i < Pools.Length; i++)
            {
                Pools[i] = new List<GameObject>();
            }
        }

        public GameObject Get(int index)
        {
            GameObject select = null;
            // .. 선택한 풀의 놀고(비활성화된) 있는 게임오브젝트 접근
            foreach (GameObject item in Pools[index])
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
                Pools[index].Add(select); 
            }
            return select;
        }
    }
}

