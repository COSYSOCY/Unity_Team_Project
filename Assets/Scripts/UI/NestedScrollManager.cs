using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NestedScrollManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scrollbar;
    public Transform contentTr;

    public Slider tabSlider;

    public RectTransform[] BtnRect, BtnImageRect;

    const int SIZE = 5;
    float[] pos = new float[SIZE];
    float distance, targetPos, curPos;
    bool isDrag;
    int targetIndex;



    private void Start()
    {

        //�Ÿ��� ���� 0~1�� pos����

        //거리에 따라 0~1인 pos대입

        distance = 1f / (SIZE - 1f);
        for (int i = 0; i < SIZE; i++) pos[i] = distance * i;
    }

    float SetPos()
    {

        //���� �Ÿ��� �������� ����� ��ġ�� ��ȯ

        //절반 거리를 기준으로 가까운 위치를 반환

        for (int i = 0; i < SIZE; i++)
            if(scrollbar.value <pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance *0.5f)
            {
                targetIndex = i;
                return pos[i];         
            }
        return 0;
    }

    public void OnBeginDrag(PointerEventData eventData) => curPos = SetPos();

    public void OnDrag(PointerEventData eventData) => isDrag = true;
    

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        targetPos = SetPos();


        //���ݰŸ��� �����ʾƵ� ���콺�� ������ �̵��ϸ�
        if(curPos == targetPos)
        {            
            //  <<<��ũ���� �������� ������ �̵��� ��ǥ�� �ϳ� ����
            if(eventData.delta.x > 18 && curPos - distance >= 0)
            {
                --targetIndex;
                targetPos = curPos - distance;
            }

            // >>>��ũ���� ���������� ������ �̵��� ��ǥ
            else if (eventData.delta.x < -18 && curPos + distance <= 1.01f)
            {
                ++targetIndex;
                targetPos = curPos + distance;
            }
        }

        //��ǥ�� ������ũ���̰�, ������ �ŰܿԴٸ� ������ũ���� ������ �ø�
        VerticalScrollUp();

        
    }
   void VerticalScrollUp()
    { 

        for (int i = 1; i < SIZE; i++)
            if (contentTr.GetChild(i).GetComponent<ScrollScript>() && curPos != pos[i] && targetPos == pos[i])
                contentTr.GetChild(i).GetChild(1).GetComponent<Scrollbar>().value = 1;
    }
    public void Update()
    {
        tabSlider.value = scrollbar.value;

        if (!isDrag)
        {
            scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);


            //��ǥ ��ư�� ũ�Ⱑ Ŀ��

            //목표 버튼은 크기가 커짐

            for (int i = 0; i < SIZE; i++) BtnRect[i].sizeDelta = new Vector2(i == targetIndex ? 360 : 180, BtnRect[i].sizeDelta.y);            
        }

        if (Time.time < 0.1f) return;

        for (int i = 0; i < SIZE; i++)
        {

            //��ư �������� �ε巴�� ��ư�� �߾����� �̵�, ũ��� 1 �ؽ�Ʈ ��Ȱ��

            //버튼 아이콘이 부드럽게 버튼의 중앙으로 이동, 크기는 1 텍스트 비활성

            Vector3 BtnTargetPos = BtnRect[i].anchoredPosition3D;
            Vector3 BtnTargetScale = Vector3.one;
            bool textActive = false;


            //������ ��ư �������� �ణ���� �ø���, ũ�⵵ Ű���, �ؽ�Ʈ�� Ȱ��ȭ

            //선택한 버튼 아이콘은 약간위로 올리고, 크기도 키우고, 텍스트도 활성화

            if(i == targetIndex)
            {
                BtnTargetPos.y = -23f;
                BtnTargetScale = new Vector3(1.2f, 1.2f, 1);
                textActive = true;
            }

            BtnImageRect[i].anchoredPosition3D = Vector3.Lerp(BtnImageRect[i].anchoredPosition3D, BtnTargetPos, 0.25f);
            BtnImageRect[i].localScale = Vector3.Lerp(BtnImageRect[i].localScale, BtnTargetScale, 0.25f);
            BtnImageRect[i].transform.GetChild(0).gameObject.SetActive(textActive);
        }
    }

    public void TabClick(int n)
    {
        curPos = SetPos();
        targetIndex = n;
        targetPos = pos[n];
        VerticalScrollUp();
    }
}
