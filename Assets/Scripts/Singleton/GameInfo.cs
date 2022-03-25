using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
	public static GameInfo inst;
	public AudioSource audioSo;
	public static float PlayerBGM; // �����
	public static float PlayerSE; // ����
	public static bool PlayerVFX; // ����Ʈ ����
	public static bool PlayerDmg; //������ǥ�� ����
	public static int PlayerGold; // �÷��̾� ���
	public static int PlayerPoint; // �÷��̾� ����

	public int CharacterIdx;
	public int MapIdx;
	public int SkillIdx;
	public List<int> CharacterActive; // 0 ���� 1 ���Ű��� 2 ������
	public int CharacterMax;

	public static float HpPlus; // ü���߰�%
	public static float DamagePlus;//�������߰�%
	public static int BulletCntPlus;//����ü������
	public static float SkillCoolPlus;//�ɷ� ��ٿ� ����%
	public static float HpRegenPlus;//����(���) �ʸ��� ȸ��
	public static float Attack_RangePlus; //���ݹ��� ����%
	public static float MoveSpeedPlus; //�̵��ӵ�����%
	public static float DefencePlus; // �������� (���)
	public static float BulletSpeedPlus;//����ü �̼ӵ�������%
	public static float BulletTimePlus;//����ü ���ӽð� ����%
	public string Language = "Korean"; // ���




	void Awake()
	{
		inst = this;
		audioSo = inst.GetComponent<AudioSource>();
        for (int i = 0; i < CharacterMax; i++)
        {
			CharacterActive.Add(0);

		}
		CharacterActive[0] = 2;
	}

	public static void soundcheck()
    {
		inst.audioSo.volume = 1f;

	}

}
