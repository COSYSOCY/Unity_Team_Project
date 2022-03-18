using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoving : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler, IDragHandler
{
    public Transform player;
    [SerializeField] private float moveSpeed;
    public Vector3 move;
    private bool isMove;
    private bool isStop;
    public LevelUp levelup;
    public RectTransform pad;
    public RectTransform stick;
    public void OnDrag(PointerEventData eventData)
    {
        if (isStop == false&& levelup.testcheck == false)
        {
            stick.position = eventData.position;
            stick.localPosition =
            Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.5f);
            move = new Vector3(stick.localPosition.x, 0, stick.localPosition.y).normalized;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (isStop == false&& levelup.testcheck == false)
        {
            pad.position = eventData.position;
            pad.gameObject.SetActive(true);
            StartCoroutine("Movement");
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (levelup.testcheck==false)
        {

        stick.localPosition = Vector2.zero;
        pad.gameObject.SetActive(false);
        StopCoroutine("Movement");
        move = Vector3.zero;
        }
    }
    IEnumerator Movement()
    {
        if (isStop == false)
        {
            while (true)
            {
                player.Translate(move * moveSpeed * Time.deltaTime, Space.World);
                //player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(move), 20 * Time.deltaTime);
                player.rotation = Quaternion.LookRotation(move);
                yield return null;
            }
        }
    }

}