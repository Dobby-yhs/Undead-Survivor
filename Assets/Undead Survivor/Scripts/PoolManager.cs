using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // .. 프리팹들을 보관할 변수
    public GameObject[] prefabs;

    // ... 풀 담당을 하는 리스트
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject GetObject(int index)
    {
        GameObject select = null;

        // ... 선택한 풀의 놀고 있는(비활성화 된된) 게임 오브젝트 접근
        foreach (GameObject obj in pools[index])
        {
            if (!obj.activeSelf)
            {
                // ... 발견하면 select 변수에 할당
                select = obj;
                select.SetActive(true);

                break;
            }
        }

        // ... 못 찾았다면 새롭게 생성하고 select 변수에 할당
        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
