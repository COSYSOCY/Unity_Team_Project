using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_17 : MonoBehaviour
{
    public Bullet_Info info;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy") && other.gameObject.activeSelf)
        {
            if (MainSingleton.instance.playerstat.SkillItemactive[17] >= 1)
            {
                Create2(other.gameObject);
            }
            else
            {
                Create1(other.gameObject);
            }


                gameObject.SetActive(false);
            
        }
        else if (other.gameObject.CompareTag("DeOb"))
        {
            if (MainSingleton.instance.playerstat.SkillItemactive[17] >= 1)
            {
                Create2(other.gameObject);
            }
            else
            {
                Create1(other.gameObject);
            }
            gameObject.SetActive(false);
        }

    }

    void Create1(GameObject g)
    {
        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_17_1", transform.position, transform.rotation);
        bullet.transform.localScale = new Vector3(info.real1, info.real1, info.real1);
        bullet.GetComponent<Bullet_Info>().damage = info.damage;
        bullet.GetComponent<Bullet_Info>().move = info.move;
        bullet.GetComponent<Bullet_Info>().Destorybullet(info.KnokTime);
        bullet.GetComponent<Bullet_Trigger_17_2>().nodagame = g.gameObject;

        GameObject bullet2 = ObjectPooler.SpawnFromPool("Bullet_17_1", transform.position, transform.rotation*Quaternion.Euler(new Vector2(0,-30f)));
        bullet2.transform.localScale = new Vector3(info.real1, info.real1, info.real1);
        bullet2.GetComponent<Bullet_Info>().damage = info.damage;
        bullet2.GetComponent<Bullet_Info>().move = info.move;
        bullet2.GetComponent<Bullet_Info>().Destorybullet(info.KnokTime);
        bullet2.GetComponent<Bullet_Trigger_17_2>().nodagame = g.gameObject;
        GameObject bullet3 = ObjectPooler.SpawnFromPool("Bullet_17_1", transform.position, transform.rotation * Quaternion.Euler(new Vector2(0, 30f)));
        bullet3.transform.localScale = new Vector3(info.real1, info.real1, info.real1);
        bullet3.GetComponent<Bullet_Info>().damage = info.damage;
        bullet3.GetComponent<Bullet_Info>().move = info.move;
        bullet3.GetComponent<Bullet_Info>().Destorybullet(info.KnokTime);
        bullet3.GetComponent<Bullet_Trigger_17_2>().nodagame = g.gameObject;
    }
    void Create2(GameObject g)
    {
        GameObject bullet = ObjectPooler.SpawnFromPool("Bullet_17_1", transform.position, transform.rotation);
        bullet.transform.localScale = new Vector3(info.real1, info.real1, info.real1);
        bullet.GetComponent<Bullet_Info>().damage = info.damage;
        bullet.GetComponent<Bullet_Info>().move = info.move;
        bullet.GetComponent<Bullet_Info>().Destorybullet(info.KnokTime);
        bullet.GetComponent<Bullet_Trigger_17_2>().nodagame = g.gameObject;

        GameObject bullet2 = ObjectPooler.SpawnFromPool("Bullet_17_1", transform.position, transform.rotation * Quaternion.Euler(new Vector2(0, -20f)));
        bullet2.transform.localScale = new Vector3(info.real1, info.real1, info.real1);
        bullet2.GetComponent<Bullet_Info>().damage = info.damage;
        bullet2.GetComponent<Bullet_Info>().move = info.move;
        bullet2.GetComponent<Bullet_Info>().Destorybullet(info.KnokTime);
        bullet2.GetComponent<Bullet_Trigger_17_2>().nodagame = g.gameObject;
        GameObject bullet3 = ObjectPooler.SpawnFromPool("Bullet_17_1", transform.position, transform.rotation * Quaternion.Euler(new Vector2(0, 20f)));
        bullet3.transform.localScale = new Vector3(info.real1, info.real1, info.real1);
        bullet3.GetComponent<Bullet_Info>().damage = info.damage;
        bullet3.GetComponent<Bullet_Info>().move = info.move;
        bullet3.GetComponent<Bullet_Info>().Destorybullet(info.KnokTime);
        bullet3.GetComponent<Bullet_Trigger_17_2>().nodagame = g.gameObject;
        GameObject bullet4 = ObjectPooler.SpawnFromPool("Bullet_17_1", transform.position, transform.rotation * Quaternion.Euler(new Vector2(0, -40f)));
        bullet4.transform.localScale = new Vector3(info.real1, info.real1, info.real1);
        bullet4.GetComponent<Bullet_Info>().damage = info.damage;
        bullet4.GetComponent<Bullet_Info>().move = info.move;
        bullet4.GetComponent<Bullet_Info>().Destorybullet(info.KnokTime);
        bullet4.GetComponent<Bullet_Trigger_17_2>().nodagame = g.gameObject;
        GameObject bullet5 = ObjectPooler.SpawnFromPool("Bullet_17_1", transform.position, transform.rotation * Quaternion.Euler(new Vector2(0, 40f)));
        bullet5.transform.localScale = new Vector3(info.real1, info.real1, info.real1);
        bullet5.GetComponent<Bullet_Info>().damage = info.damage;
        bullet5.GetComponent<Bullet_Info>().move = info.move;
        bullet5.GetComponent<Bullet_Info>().Destorybullet(info.KnokTime);
        bullet5.GetComponent<Bullet_Trigger_17_2>().nodagame = g.gameObject;
    }
}
