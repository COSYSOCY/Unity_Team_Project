using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainSingleton : MonoBehaviour
{
    public static MainSingleton instance = null;
    public PlayerInfo playerinfo;
    public GameObject Player;
    public Transform ItemCreateTranform;
    public ItemSystem dropSystem;
    public UIManager uimanager;
    public PlayerStatus playerstat;
    public GameObject birdtarget;
    public SkillManager skillmanager;

    public Skill_Item_16 item16;
    public Skill_Item_17 item17;
    public Skill_Item_31 item31;
    public PullRange pullrange;
    public Transform UiTextparentTransform;

    public NavMeshAgent nav;

    public PlayerMoving playermoving;

    public List<Material> HitEffect;
    public BoxScritps BoxScritp;
    public SkillCoolTimeSystem[] CoolTimeSystem;
    public SkillCoolTimeSystem[] CoolTimeSystem_Item;
    private void Awake()
    {
            instance = this;
    }
}
