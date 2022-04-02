using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{

    public void EnemyItemDrop(Vector3 pos,int Idx,int itemIdx)
    {
        Vector3 p = new Vector3(pos.x, 0, pos.z);
        int itemRnd = Random.Range(0, 1000);

        if (itemRnd <= 500)
        {
            if (itemIdx == 1)
            {
                ObjectPooler.SpawnFromPool("item_xp_1", p, Quaternion.identity);
            }
            if (itemIdx == 2)
            {
                ObjectPooler.SpawnFromPool("item_xp_2", p, Quaternion.identity);
            }
            if (itemRnd >= 950)
            {
                GameObject card = ObjectPooler.SpawnFromPool("item_Card_1", p, Quaternion.identity);
                card.GetComponent<ItemPull>().CardCreate(Random.Range(1, 10));
            }

        }
        if (itemIdx == 1001)
        {
            GameObject card = ObjectPooler.SpawnFromPool("item_Card_1", p, Quaternion.identity);
            card.GetComponent<ItemPull>().CardCreate(Random.Range(1, 10));
        }

    }

}
