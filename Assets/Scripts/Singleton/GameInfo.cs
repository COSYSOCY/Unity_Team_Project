using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
	static GameInfo inst;
	public static float PlayerBGM; // �����
	public static float PlayerSE; // ����
	public static bool PlayerVFX; // ����Ʈ ����
	public static bool PlayerDmg; //������ǥ�� ����
	public static int PlayerGold; // �÷��̾� ���
	
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
	public static string Language = "Korean"; // ���




	void Awake() => inst = this;


}
