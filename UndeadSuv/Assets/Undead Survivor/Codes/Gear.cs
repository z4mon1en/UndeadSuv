using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public ItemData.ItemType type;
    public float dataPerLevel;

    public void Init(ItemData data)
    {
        //Basic Set
        name = "Gear " + data.itemId;
        transform.parent = GameManager.instance.player.transform;
        transform.localScale = Vector3.zero; // ��ġ �ʱ�ȭ�� ���� �ʿ����� �ʴ�.

        // Property Set
        type = data.itemType;
        dataPerLevel = data.damagePerLevel[0];
        ApplyGear(); // Gear ��ü�� ���� ������ ��
    }

    public void LevelUp(float dataPerLevel)
    {
        this.dataPerLevel = dataPerLevel;
        ApplyGear(); // Gear ��ü�� ���������� ��
    }

    void ApplyGear()
    {
        switch (type)
        {
            case ItemData.ItemType.Glove:
                RateUp();
                break;
            case ItemData.ItemType.Shoe:
                SpeedUp();
                break;
        }
    }


    void RateUp()
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();
        
        foreach (Weapon weapon in weapons)
        {
            switch (weapon.id)
            {
                case 0:
                    weapon.speed = 150 + (150 * dataPerLevel);
                    break;
                default:
                    weapon.speed = 0.5f * (1f - dataPerLevel); 
                    break;
            }
        }
    }

    void SpeedUp()
    {
        float speed = 5;
        GameManager.instance.player.speed = speed + (speed * dataPerLevel);
    }
}
