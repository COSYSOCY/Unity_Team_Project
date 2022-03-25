using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBtn : MonoBehaviour
{
    public int CharacterIdx;
    public int CharactersNameNum;
    public int CharactersInfoNum;
    public int CharactersIconNum;
    public int CharactersSkillIconNum;
    public int CharactersBSNum;
    public float CharactersHpMax;
    public float CharactersHpRegen;
    public float CharactersDefece;
    public float CharactersSpeed;
    public float CharactersAtPlus;
    public float CharactersAtRange;
    public float CharactersBtSpeed;
    public float CharactersBtTime;
    public int CharactersBtCnt;
    public float CharactersBtCool;
    public float CharactersRange;
    public float CharactersXpPlus;
    public CharacterManager manager;

    public void ButtonClicks()
    {
        manager = GameObject.Find("CharacterManager").GetComponent<CharacterManager>();
        manager.CharacterChange(gameObject);
    }
}
