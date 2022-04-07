using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_test : MonoBehaviour
{
    /* 닿으면 리스트안에 넣기 중복방지용으로 리스트안에있는애들 충돌처리안되게
리스트안에있는애들 정지시키고 따라서 움직이게 이동방향 블랙홀 방향으로
     */
    public List<GameObject> asd;
   // public List<Vector3> asd2;

    private void OnDisable()
    {
        if (asd.Count>0)
        {
            for (int i = 0; i < asd.Count; i++)
            {
                //asd[i].GetComponent<Enemy_Info>().Speed = asd[i].GetComponent<Enemy_Info>().SpeedOri;
                //asd[i].GetComponent<Enemy_Info>().nav.isStopped = false;
            }
        }
        asd.Clear();
        //asd2.Clear();
    }
    public Bullet_Info info;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy")&&other.gameObject.activeSelf&&asd.Contains(other.gameObject)==false)
        {
            other.GetComponent<Enemy_Info>().Damaged(info.damage);
            //other.GetComponent<Enemy_Info>().Speed=0;
           // other.GetComponent<Enemy_Info>().nav.isStopped = true;

            asd.Add(other.gameObject);
           // asd2.Add(transform.position - other.transform.position);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (asd.Contains(other.gameObject) == true)
        {
            asd.Remove(other.gameObject);
           // other.GetComponent<Enemy_Info>().nav.isStopped = false;
        }
    }

    private void Update()
    {
        Vector3 sss = transform.forward;
        transform.Translate(Vector3.forward * Time.deltaTime * info.move * 0.1f);
        if (asd.Count>0)
        {
            for (int i = 0; i < asd.Count; i++)
            {
                if (asd[i].activeSelf)
                {

                //asd[i].transform.position=transform.position+(sss* Time.deltaTime * info.move * 0.1f);
                asd[i].transform.position= asd[i].transform.position+(sss* Time.deltaTime * info.move * 0.1f);
                }
                //asd[i].transform.Translate(sss * Time.deltaTime * info.move * 0.1f);
            }
        }
    }
}
