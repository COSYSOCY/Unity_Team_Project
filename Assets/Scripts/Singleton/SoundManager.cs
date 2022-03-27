using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager inst;
	public AudioClip[] audios;

	void Awake()
	{
		inst = this;
	}

	public void SoundPlay(int i)
    {
       
        if (!GameInfo.inst.PlayerSE)
        {
            GameInfo.inst.audioSo.PlayOneShot(audios[i]);
        }
    }
}
