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
        RouletFunc();
        MainSingleton.instance.playerstat.IsAdIn = false;
        Vector3 pos = parent.position;
        pos.y = -0.25f;
        GameObject g = Instantiate(CharList[GameInfo.inst.CharacterIdx], pos, Quaternion.identity, parent);
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
        MainSingleton.instance.playerinfo.PowerUp();
        yield return new WaitForSeconds(1);
        MainSingleton.instance.pullrange.Check();
        MainSingleton.instance.playerstat.PlayerHpMax();
        MainSingleton.instance.playerinfo.Hp = MainSingleton.instance.playerinfo.MaxHp;
        manager.All_Skill[GameInfo.inst.SkillIdx].SetActive(true);
        

    }
    void Start()
    {
        StartCoroutine(IStart());

    }

    public void RouletFunc()
    {

        switch (GameInfo.inst.Roulette)
        {

            case 1000:
                MainSingleton.instance.playerinfo.Bonus_Dmg += 20;
                break;
            case 1001:
            MainSingleton.instance.playerstat.ReCnt++;
                break;
            case 1002:
            MainSingleton.instance.playerinfo.Bonus_SpeedP += 20;
                break;
            case 1003:
            MainSingleton.instance.playerinfo.Bonus_GoldPuls += 20;
                break;
            case 1004:
            MainSingleton.instance.playerinfo.Bonus_XpPuls += 20;
        break;
            case 1005:
            MainSingleton.instance.playerinfo.Bonus_HpC += 50;
        break;
            case 1006:
            MainSingleton.instance.playerinfo.Bonus_Cool += 20;
                break;
            case 1007:
             MainSingleton.instance.playerinfo.Bonus_Cri += 10;
        break;
            default:
                break;
        }

}

    public void CharAddFunc(int i)
    {
        switch (i)
        {
            case 0:
                //추가 액션
                //MainSingleton.instance.playerinfo.Bonus_BtCnt++;
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Eff_Body04").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Eff_Head04").GetComponent<SkinnedMeshRenderer>().material);
                break;
            case 1:
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Eff_Body6").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Eff_Dog").GetComponent<SkinnedMeshRenderer>().material);

                //추가 액션
                break;
            case 2:
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Body03").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Head03").GetComponent<SkinnedMeshRenderer>().material);

                //추가 액션
                break;
            case 3:
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Body14").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Head14").GetComponent<SkinnedMeshRenderer>().material);
                //추가 액션
                break;
            case 4:
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Body11").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Head11").GetComponent<SkinnedMeshRenderer>().material);
                //추가 액션
                break;
            case 5:
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Body12").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Head12").GetComponent<SkinnedMeshRenderer>().material);
                //추가 액션
                break;
            case 6:
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Body05").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Head05").GetComponent<SkinnedMeshRenderer>().material);
                //추가 액션
                break;
            case 7:
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Body16").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Head16").GetComponent<SkinnedMeshRenderer>().material);
                //추가 액션
                break;
            case 8:
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Body19").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Head19").GetComponent<SkinnedMeshRenderer>().material);
                //추가 액션
                break;
            case 9:
                //MainSingleton.instance.playerinfo.Bonus_Range+=2f;
                
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Body06").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Head06").GetComponent<SkinnedMeshRenderer>().material);
                //추가 액션
                break;
            case 10:

                MainSingleton.instance.HitEffect.Add(GameObject.Find("Belt1").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Cloth1").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Glove6").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Helm5").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Shoe1").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("ShoulderPad5").GetComponent<SkinnedMeshRenderer>().material);

                break;
            case 11:

                MainSingleton.instance.HitEffect.Add(GameObject.Find("Cloth4").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Glove3").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Helm6").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Shoe5").GetComponent<SkinnedMeshRenderer>().material);
                break;
            case 12:

                MainSingleton.instance.HitEffect.Add(GameObject.Find("Cloth6").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Glove1").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Helm6").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("Shoe2").GetComponent<SkinnedMeshRenderer>().material);
                MainSingleton.instance.HitEffect.Add(GameObject.Find("ShoulderPad3").GetComponent<SkinnedMeshRenderer>().material);

                break;
            default:
                break;
        }
    }


}
