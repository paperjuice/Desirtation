using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloorProgressionBehaviour : MonoBehaviour {

	
	[SerializeField] fadeOutFadein _fade;
	[SerializeField] Image[] fills;
	[SerializeField] Text[] floorText;
	[SerializeField] Image[] skulls;
	MonoBehaviour[] mono;
	bool isReady = false;


	[SerializeField]int floorLevel;

	void Awake()
	{
		mono = GameObject.FindGameObjectWithTag("Player").GetComponents<MonoBehaviour>();
	}

	IEnumerator Start()
	{
		 floorLevel = controller.dungeonLevel;
		//floorLevel = 3;

		DisableMcComponents();
		if(floorLevel >2)
		{
			FillBar();	
		}
		ColourText();
		ColourSkullsAfterProgress();

		yield return new WaitForSeconds(1f);
		isReady = true;
	}

	void Update()
	{
		LerpScaleOfLastFiller();

		if(isReady)
			AnyKeyToNextScene();
	}

	void FillBar()
	{
		for(int i = 0; i<floorLevel-2;i++)
		{
			fills[i].transform.localScale = new Vector3(4.8f,1,1);
		}
	}

	void ColourText()
	{
		for(int i = 0; i < floorLevel-1;i++)
			floorText[i].color = new Color32(147, 45, 47, 255);
	}

	void ColourSkullsAfterProgress()
	{
		if(floorLevel>3)
		{
			skulls[0].color= new Color32(147, 45, 47, 255);
		}

		if(floorLevel>6)
		{
			skulls[1].color= new Color32(147, 45, 47, 255);
		}
		if(floorLevel>8)
		{
			skulls[2].color= new Color32(147, 45, 47, 255);
		}
	}

	void ColourSkullsWhenProgress()
	{
		switch(floorLevel)
		{
			case 3:
				skulls[0].color= new Color32(147, 45, 47, 255);
				break;
			case 6:
				skulls[1].color= new Color32(147, 45, 47, 255);
				break;
			case 8:
				skulls[2].color= new Color32(147, 45, 47, 255);
				break;
			case 10:
				skulls[3].color= new Color32(147, 45, 47, 255);
				break;
		}
	}

	void LerpScaleOfLastFiller()
	{
		fills[floorLevel-2].transform.localScale = Vector3.Lerp(fills[floorLevel-2].transform.localScale, new Vector3(4.8f,1f,1f), Time.deltaTime*2f);
		if(fills[floorLevel-2].transform.localScale.y >=0.9f )
		{
			ColourSkullsWhenProgress();
			if(floorLevel != 3 && floorLevel != 5 && floorLevel != 8)
				floorText[floorLevel-1].color = new Color32(147, 45, 47, 255);
		}
	}

	void DisableMcComponents()
	{
		foreach(MonoBehaviour m in mono)
		{
			m.enabled = false;
		}
	}

	void AnyKeyToNextScene()
	{
		if(Input.anyKeyDown)
			_fade.enabled  = true;
			
			if(controller.dungeonLevel == 3 || controller.dungeonLevel == 6 || controller.dungeonLevel == 8)
				_fade.SceneName = "BossScene1";
			else
				_fade.SceneName = "game2_randomMapGen";


	}

}
