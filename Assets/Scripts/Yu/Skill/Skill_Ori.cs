using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Ori : MonoBehaviour
{
    public GameObject Player; //플레이어
    public GameObject bulletPrefab; //총알Prefab
    public Transform bulletPos;//총알생성위치 (따로 생성되는위치가 필요할때 사용)
    public Skill_Info info;
    public float Cool_Main;
    public float Cool_sub1;
    public float Cool_sub2;
    protected bool start = false;

    public virtual void LevelUp()
    {

    }

}
