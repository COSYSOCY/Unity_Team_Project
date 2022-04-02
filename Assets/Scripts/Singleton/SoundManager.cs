using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager inst;
    [SerializeField]
    AudioClip[] audios;
    [SerializeField]
    AudioClip[] BGM;
    //public AudioSource audioSoure;

	void Awake()
	{
		inst = this;
	}
    public void BGMPlay(int i)
    {
        GameInfo.inst.audioSo.clip= BGM[i];
        GameInfo.inst.audioSo.Play();
    }
	public void SoundPlay(int i)
    {
       
        if (!GameInfo.inst.PlayerSE)
        {
            GameInfo.inst.audioSo2.PlayOneShot(audios[i]);
        }
    }
}
