using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trigger_9 : MonoBehaviour
{
    public Bullet_Info info;
    public bool check;
    public float CurTime;

    public void StartFunc()
    {
        check = false;
        StartCoroutine(MoveFunc());
    }
    public IEnumerator MoveFunc()
    {
        yield return new WaitForSeconds(CurTime / 2f);
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!check)
            transform.Translate(Vector3.forward * Time.deltaTime * info.move * 0.1f);
        else
            transform.Translate(Vector3.back * Time.deltaTime * info.move * 0.1f);

    }
}
