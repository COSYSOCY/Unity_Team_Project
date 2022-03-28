using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoving : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler, IDragHandler
{
    public Transform player;
   // [SerializeField] private float moveSpeed;
    public Vector3 move;
    private bool isMove;
    private bool isStop;
    public LevelUp levelup;
    public RectTransform pad;
    public RectTransform stick;
    public Animator ani;
    public PlayerInfo playerinfo;
    public bool GameStart;
    public void OnDrag(PointerEventData eventData)
    {
        if (isStop == false&& levelup.testcheck == false && GameStart)
        {
            stick.position = eventData.position;
            stick.localPosition =
            Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.5f);
            move = new Vector3(stick.localPosition.x, 0, stick.localPosition.y).normalized;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (isStop == false&& levelup.testcheck == false && GameStart)
        {
            pad.position = eventData.position;
            pad.gameObject.SetActive(true);
            StartCoroutine("Movement");
            ani.SetBool("idle", false);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (levelup.testcheck==false && GameStart)
        {

        stick.localPosition = Vector2.zero;
        pad.gameObject.SetActive(false);
        StopCoroutine("Movement");
        move = Vector3.zero;
            ani.SetBool("idle", true);
        }
        
    }
    IEnumerator Movement()
    {

        if (isStop == false && GameStart)
        {
            while (true)
            {
                player.Translate(move * playerinfo._Speed()*0.1f * Time.deltaTime, Space.World);
                //Vector3 pos=player.position;
                //pos.y = 0;
                //player.position = pos;
                //player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(move), 20 * Time.deltaTime);
                if (move != Vector3.zero)
                    player.rotation = Quaternion.LookRotation(move);



                yield return null;
            }
        }
        else
        {
            
        }
    }

}