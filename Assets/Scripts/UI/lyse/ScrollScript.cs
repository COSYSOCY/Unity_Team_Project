using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollScript : ScrollRect
{
    bool forParent;
    NestedScrollManager NM;
    ScrollRect paretnScrollRect;

    protected override void Start()
    {
        NM = GameObject.FindWithTag("NestedScrollManager").GetComponent<NestedScrollManager>();
        paretnScrollRect = GameObject.FindWithTag("NestedScrollManager").GetComponent<ScrollRect>();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        //드래그가 시작하는 순간 수평이동이 크면 부모가 드래그 시작한것, 수직이동이 크면 자식이 드래그 시작한것
        forParent = Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y);

        if(forParent)
        {
            NM.OnBeginDrag(eventData);
            paretnScrollRect.OnBeginDrag(eventData);
        }
        else base.OnBeginDrag(eventData);
    }
    public override void OnDrag(PointerEventData eventData)
    {
        if (forParent)
        {
            NM.OnDrag(eventData);
            paretnScrollRect.OnDrag(eventData);
        }
        else base.OnDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (forParent)
        {
            NM.OnEndDrag(eventData);
            paretnScrollRect.OnEndDrag(eventData);
        }
        else base.OnEndDrag(eventData);
    }
}
