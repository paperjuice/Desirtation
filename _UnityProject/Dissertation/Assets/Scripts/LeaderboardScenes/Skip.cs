using UnityEngine;

public class Skip : MonoBehaviour {

	fadeOutFadein _fade;

	void Awake()
	{
		_fade = GameObject.FindGameObjectWithTag("fadeIn").GetComponent<fadeOutFadein>();		
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			_fade.enabled = true;
			//controller.dungeonLevel = 1;
		}
	}
}
