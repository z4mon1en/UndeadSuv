using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // ������ ������ ���� 
    public GameObject[] prefabs;

    // Ǯ ��� ����Ʈ
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

        //������ Ǯ�� ���(��Ȱ��ȭ��) �ִ� ���ӿ�����Ʈ ����
        foreach(GameObject item in pools[i])
        {
            if (!item.activeSelf)
            {
                //�߰��ϸ� select������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        }

        //��ã����, ���� �����ϰ� select������ �Ҵ�
        if(!select) // = if(select == null)
        {
            select = Instantiate(prefabs[i], transform);
            pools[i].Add(select);
        }

        return select;
    }
}