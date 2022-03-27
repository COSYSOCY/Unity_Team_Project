using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : MonoBehaviour
{
    public SkillManager manager;
    public List<GameObject> CharList;
    public List<GameObject> MapList;
    public Transform parent;
    public PlayerMoving moving;
    public GameObject Hpbar;
    public IEnumerator IStart()
    {
        GameObject g = Instantiate(CharList[GameInfo.inst.CharacterIdx], parent.position, Quaternion.identity, parent);
        moving.ani = g.GetComponent<Animator>();
        moving.GameStart = true;
        Hpbar.SetActive(true);
        //MapManager.instance.Maps = MapList[GameInfo.inst.MapIdx];
        //MapManager.instance.GameStart = true;
        MapList[GameInfo.inst.MapIdx].SetActive(true);
        GameInfo.inst.audioSo.Pause();
        yield return new WaitForSeconds(1);
        manager.Skills[GameInfo.inst.SkillIdx].SetActive(true);
        CharAddFunc(GameInfo.inst.CharacterIdx);

    }
    void Start()
    {
        StartCoroutine(IStart());
    }

    public void CharAddFunc(int i)
    {
        switch (i)
        {
            case 0:
                //�߰� �׼�
                break;
            case 1:
                //�߰� �׼�
                break;
            case 2:
                //�߰� �׼�
                break;
            case 3:
                //�߰� �׼�
                break;
            case 4:
                //�߰� �׼�
                break;
            case 5:
                //�߰� �׼�
                break;
            case 6:
                //�߰� �׼�
                break;
            default:
                break;
        }
    }


}
