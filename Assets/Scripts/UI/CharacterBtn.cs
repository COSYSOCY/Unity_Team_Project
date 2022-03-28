using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBtn : MonoBehaviour
{
    public int CharacterIdx;
    public int CharactersNameNum;
    public int CharactersInfoNum;
    public int CharactersIconNum;
    public int CharactersSkillIconNum;
    public int CharactersBSNum;
    public int CharactersPrice;
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
    public int State;
    public CharacterManager manager;

    public Image MainImage;
    public GameObject LockImage;

    public void ButtonClicks()
    {
        manager = GameObject.FindGameObjectWithTag("CharManager").GetComponent<CharacterManager>();
        manager.CharacterChange(gameObject);
    }
}
