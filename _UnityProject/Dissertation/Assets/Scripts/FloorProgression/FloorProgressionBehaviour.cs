using UnityEngine;
using UnityEngine.UI;

public class FloorProgressionBehaviour : MonoBehaviour {

	
	[SerializeField] fadeOutFadein _fade;
	[SerializeField] Image[] fills;
	[SerializeField] Text[] floorText;
	[SerializeField] Image[] skulls;
	MonoBehaviour[] mono;


	[SerializeField]int floorLevel;

	void Awake()
	{
		mono = GameObject.FindGameObjectWithTag("Player").GetComponents<MonoBehaviour>();
	}

	void Start()
	{
		// floorLevel = 3;
		//floorLevel = 3;

		DisableMcComponents();
		if(floorLevel >2)
		{
			FillBar();	
		}
		ColourText();
		ColourSkullsAfterProgress();
	}

	void Update()
	{
		LerpScaleOfLastFiller();
		AnyKeyToNextScene();
	}

	void FillBar()
	{
		for(int i = 0; i<floorLevel-2;i++)
		{
			fills[i].transform.localScale = new Vector3(1,1,1);
		}
	}

	void ColourText()
	{
		for(int i = 0; i < floorLevel-1;i++)
			floorText[i].color = new Color32(147, 45, 47, 255);
	}

	void ColourSkullsAfterProgress()
	{
		if(floorLevel>4)
		{
			skulls[0].color= new Color32(147, 45, 47, 255);
		}

		if(floorLevel>8)
		{
			skulls[1].color= new Color32(147, 45, 47, 255);
		}
		if(floorLevel>12)
		{
			skulls[2].color= new Color32(147, 45, 47, 255);
		}
	}

	void ColourSkullsWhenProgress()
	{
		switch(floorLevel)
		{
			case 4:
				skulls[0].color= new Color32(147, 45, 47, 255);
				break;
			case 8:
				skulls[1].color= new Color32(147, 45, 47, 255);
				break;
			case 12:
				skulls[2].color= new Color32(147, 45, 47, 255);
				break;
			case 16:
				skulls[3].color= new Color32(147, 45, 47, 255);
				break;
		}
	}

	void LerpScaleOfLastFiller()
	{
		fills[floorLevel-2].transform.localScale = Vector3.Lerp(fills[floorLevel-2].transform.localScale, new Vector3(1f,1f,1f), Time.deltaTime*2f);
		if(fills[floorLevel-2].transform.localScale.y >=0.9f )
		{
			ColourSkullsWhenProgress();
			if(floorLevel != 4 && floorLevel != 8 && floorLevel != 12)
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
	}

}
