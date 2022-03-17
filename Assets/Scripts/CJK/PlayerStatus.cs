using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    const float hp = 100;
    float curHp;
    [SerializeField] Slider hpbar;

    private bool isDead;
    void Start()
    {
        curHp = hp;
    }
    void Update()
    {
        SliderUpdate();
    }
    public void SliderUpdate()
    {
        hpbar.value = curHp / hp;
    }
    public void HpPlus(float _count)
    {
        if (curHp + _count <= hp)
        {
            curHp += _count;
        }
        else
        {
            curHp = hp;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("È÷Æ®");
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(PlayerDamage());
        }
    }

    IEnumerator PlayerDamage()
    {
        if(!isDead)
        {
            yield return new WaitForSeconds(0.5f);
            HpPlus(-6);
        }
    }
}
