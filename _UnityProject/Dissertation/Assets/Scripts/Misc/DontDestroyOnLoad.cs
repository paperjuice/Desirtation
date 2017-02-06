using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {

	public static DontDestroyOnLoad instance;
	void Awake() 
	{
		if(instance != null && instance != this) 
		{
			DestroyImmediate(gameObject);
			return;
		}
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
}
