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
        transform.localScale = Vector3.zero; // 위치 초기화는 굳이 필요하진 않다.

        // Property Set
        type = data.itemType;
        dataPerLevel = data.damagePerLevel[0];
        ApplyGear(); // Gear 자체가 새로 생겼을 때
    }

    public void LevelUp(float dataPerLevel)
    {
        this.dataPerLevel = dataPerLevel;
        ApplyGear(); // Gear 자체가 레벨업했을 때
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
