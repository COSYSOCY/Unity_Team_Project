using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager inst;
	public bool PlayerBGM; // �����
	public bool PlayerSE; // ����
	public bool PlayerDmg; //������ǥ�� ����
	public bool PlayerCoolUi; //��Ÿ��ǥ�� ����
	public int PlayerGold; // �÷��̾� ���
	public int PlayerKill; // �÷��̾� ų��

	public int CharacterIdx; //ĳ���͹�ȣ
	public int MapIdx; // �ʹ�ȣ
	public int SkillIdx; // ��ų��ȣ
    private void Awake()
    {
        if (null == inst)
        {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
