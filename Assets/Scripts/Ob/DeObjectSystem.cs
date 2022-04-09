using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeObjectSystem : MonoBehaviour
{
    public float Hp;
    public int DropIdx;

    public void Damaged(float damage)
    {
        float f = damage;
        if (f < 1)
        {
            f = 1f;
        }
        //GameObject clone = Instantiate(TextUi);
        GameObject clone = null;

        if (!GameInfo.inst.PlayerDmg)
        {

            clone = ObjectPooler.SpawnFromPool("TextUi", transform.position);
            clone.transform.SetParent(MainSingleton.instance.UiTextparentTransform);
            Bounds bounds = GetComponent<Collider>().bounds;
            clone.GetComponent<UIHUDText>().Play(f.ToString("F0"), Color.red, bounds);

        }
        GameObject Effect = ObjectPooler.SpawnFromPool("Enemy_Hit", transform.position, Quaternion.identity);
        //SoundManager.inst.SoundPlay(5);
        Hp -= f;
        if (Hp < 1 && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            Drop();
        }
    }

    public void Drop()
    {
        if (DropIdx==1)
        {

            float r = Random.Range(0, 100f);
            Vector3 p = new Vector3(transform.position.x, 0, transform.position.z);
            if (r >= 95)
            {
                ObjectPooler.SpawnFromPool("item_Hp_1", p, Quaternion.identity);
            }
            else if (r >= 86)
            {
                ObjectPooler.SpawnFromPool("item_gold_2", p, Quaternion.identity);
            }
            else if( r>= 16)
            {
                ObjectPooler.SpawnFromPool("item_gold", p, Quaternion.identity);
            }

        }
    }

}
