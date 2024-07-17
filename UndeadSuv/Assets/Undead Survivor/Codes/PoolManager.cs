using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리펩 보관할 변수 
    public GameObject[] prefabs;

    // 풀 담당 리스트
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int i)
    {
        GameObject select = null;

        //선택한 풀의 놀고(비활성화된) 있는 게임오브젝트 접근
        foreach(GameObject item in pools[i])
        {
            if (!item.activeSelf)
            {
                //발견하면 select변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        //못찾으면, 새로 생성하고 select변수에 할당
        if(!select) // = if(select == null)
        {
            select = Instantiate(prefabs[i], transform);
            pools[i].Add(select);
        }

        return select;
    }
}