using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour
{
    public static IconManager inst;
	public Sprite[] Icons;

	void Awake()
	{
		inst = this;
	}

}
