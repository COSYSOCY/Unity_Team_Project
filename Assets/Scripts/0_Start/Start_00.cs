using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start_00 : MonoBehaviour
{
    bool check = false;
    string log;
    public bool click;
    int exit = 0;
    private void Start()
    {

        StartCoroutine(startfunc());
    }
    IEnumerator startfunc()
    {
        yield return new WaitForSeconds(1);
        if (GameInfo.inst.PcTestMode)
        {
            ServerDataSystem.inst.LoadData2adasdasdasd();
        }
        else
        {
            GPGSBinder.Inst.Login((success, localUser) => Check(success));
        }
    }
    public void Logic()
    {
        if (click)
        {
            return;
        }
        if (GameInfo.inst.PcTestMode)
        {
            ServerDataSystem.inst.LoadData2adasdasdasd();
        }
        else
        {
            click = true;
        GPGSBinder.Inst.Login((success, localUser) => Check(success));
        }
    }
    public void Check(bool su)
    {
        if (exit >=4)
        {
            return;
        }
        if (!su)
        {
            exit++;
            GPGSBinder.Inst.Login((success, localUser) => Check(success));
        }
        else
        {
            if (ServerDataSystem.inst.IsSave == false)
            {
                //ServerDataSystem.inst.ServerLoad();
                ServerDataSystem.inst.LoadData2adasdasdasd();

                GameInfo.inst.UserName = Social.localUser.userName;
                GameInfo.inst.Id = Social.localUser.id;

            }
        }
    }
    //void Update()
    //{
    //    return;
    //    if (Input.GetMouseButtonUp(0)&&GameInfo.inst.GameStart&&!check)
    //    {
    //        check = true;
    //        //StartCoroutine(ServerDataSystem.inst.LoadData());
    //        ServerDataSystem.inst.LoadData2();
    //       // Destroy(gameObject);    
    //    }
    //}

}
