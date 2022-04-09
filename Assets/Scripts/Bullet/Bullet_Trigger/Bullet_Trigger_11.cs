using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_11 : MonoBehaviour
{

    public List<GameObject> CheckList;


    private void OnDisable()
    {
        if (CheckList.Count>0)
        {
            for (int i = 0; i < CheckList.Count; i++)
            {

            }
        }
        CheckList.Clear();

    }
    public Bullet_Info info;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy")&&other.gameObject.activeSelf&&CheckList.Contains(other.gameObject)==false)
        {
            other.GetComponent<Enemy_Info>().Damaged(info.damage);
            if (!other.GetComponent<Enemy_Info>().IsBoss)
            {

            CheckList.Add(other.gameObject);
            }
          
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (CheckList.Contains(other.gameObject) == true)
        {
            CheckList.Remove(other.gameObject);
        }
    }

    private void Update()
    {
        Vector3 sss = transform.forward;
        transform.Translate(Vector3.forward * Time.deltaTime * info.move * 0.1f);
        if (CheckList.Count>0)
        {
            for (int i = 0; i < CheckList.Count; i++)
            {
                if (CheckList[i].activeSelf)
                {

                    CheckList[i].transform.position=transform.position+(sss* Time.deltaTime * info.move * 0.1f);
                //CheckList[i].transform.position= CheckList[i].transform.position+(sss* Time.deltaTime * info.move * 0.1f);
                //CheckList[i].transform.position= CheckList[i].transform.position+(sss* Time.deltaTime * info.move * 0.1f);
                }
                else
                {
                    CheckList.RemoveAt(i);
                    if (i== CheckList.Count-1)
                    {
                        return;
                    }
                }
                //asd[i].transform.Translate(sss * Time.deltaTime * info.move * 0.1f);
            }
        }
    }
}
