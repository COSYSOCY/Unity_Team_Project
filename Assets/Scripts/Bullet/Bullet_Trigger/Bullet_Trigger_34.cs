using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_34 : MonoBehaviour
{
    public Bullet_Info info;
    public bool isC = false;
    private void OnEnable()
    {
        isC = false;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy")&&other.gameObject.activeSelf)
        {
            if (!isC&&info.Up)
            {
                isC = true;
                GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_34_1", transform.position, Quaternion.Euler(new Vector2(0,Random.Range(0,360f))));
                bullet.GetComponent<Bullet_Info>().damage = info.damage;
                bullet.GetComponent<Bullet_Info>().pie = info.pie;
                bullet.GetComponent<Bullet_Info>().move = info.move;
                bullet.GetComponent<Bullet_Info>().Destorybullet(info.real1 * 0.5f);
                bullet.transform.localScale = new Vector3(info.real2, info.real2, info.real2);
            }
            if (info.KnokTime > 0)
            {
                other.GetComponent<Enemy_Info>().KnockEnemy(info.KnokTime);
            }
            info.pie--;
            other.GetComponent<Enemy_Info>().Damaged(info.damage);
            if (info.pie <1)
            {
                gameObject.SetActive(false);

            }

        }
        else if (other.gameObject.CompareTag("DeOb"))
            {
                other.GetComponent<DeObjectSystem>().Damaged(info.damage);
            info.pie--;
            if (info.pie < 1)
            {
                gameObject.SetActive(false);

            }
        }

    }
}
