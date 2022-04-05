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
        MainSingleton.instance.playerstat.IsAdIn = false;
        GameObject g = Instantiate(CharList[GameInfo.inst.CharacterIdx], parent.position, Quaternion.identity, parent);
        CharAddFunc(GameInfo.inst.CharacterIdx);
        moving.ani = g.GetComponent<Animator>();
        moving.GameStart = true;
        Hpbar.SetActive(true);
        manager.Skills = manager.CharSkillAndItem[GameInfo.inst.CharacterIdx].Skill;
        manager.Skill_Items = manager.CharSkillAndItem[GameInfo.inst.CharacterIdx].SkillItem;

        Time.timeScale = 1f;
        //MapManager.instance.Maps = MapList[GameInfo.inst.MapIdx];
        //MapManager.instance.GameStart = true;
        MapList[GameInfo.inst.MapIdx].SetActive(true);
        GameInfo.inst.audioSo.Pause();
        SoundManager.inst.BGMPlay(2);
        MainSingleton.instance.pullrange.Check();
        yield return new WaitForSeconds(1);
        manager.All_Skill[GameInfo.inst.SkillIdx].SetActive(true);
        

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
                //추가 액션
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Eff_Body04").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Eff_Head04").GetComponent<SkinnedMeshRenderer>().material);
                break;
            case 1:
                //추가 액션
                break;
            case 2:
                //추가 액션
                break;
            case 3:
                //추가 액션
                break;
            case 4:
                //추가 액션
                break;
            case 5:
                //추가 액션
                break;
            case 6:
                //추가 액션
                break;
            default:
                break;
        }
    }


}
