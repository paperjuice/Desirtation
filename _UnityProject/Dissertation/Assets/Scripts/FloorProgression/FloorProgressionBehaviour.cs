using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloorProgressionBehaviour : MonoBehaviour {

	
	[SerializeField] fadeOutFadein _fade;
	[SerializeField] Image fillBar;
	[SerializeField] Text[] floorText; 
	MonoBehaviour[] mono; //the player is silently staying in the background so i make sure all inputs are down for him
	int floorLevel;
	float fillBarScale;
	float num;  //this is the number i increment for the fill bar
	bool isReady;

	void Awake()
	{
		mono = GameObject.FindGameObjectWithTag("Player").GetComponents<MonoBehaviour>();
	}
	void Start()
	{
		foreach(MonoBehaviour m in mono)
			m.enabled = false;

		floorLevel = controller.dungeonLevel;
		fillBarScale = controller.dungeonLevel;
		ColourFloorText();
		fillBar.transform.localScale = new Vector3(1f, (fillBarScale-1f)/16f, 1f);
	}

	void Update()
	{
		ContinueGame();
		FillBarBehaviour();

		
	}


	void FillBarBehaviour()
	{
		fillBar.transform.localScale = Vector3.Lerp(fillBar.transform.localScale, new Vector3(1,fillBarScale/16,1), Time.deltaTime);
		Debug.Log(fillBarScale/16);

		if(fillBar.transform.localScale.y>=fillBarScale/16)
			floorText[floorLevel].color= new Color32(167, 45,47, 255);

	}

	void ColourFloorText()
	{
		for(int i = 0; i < floorLevel;i++)
			floorText[i].color = new Color32(167, 45,47, 255);
	}

	void ContinueGame()
	{
		if(Input.anyKeyDown)
			_fade.enabled = true;
	}
}
