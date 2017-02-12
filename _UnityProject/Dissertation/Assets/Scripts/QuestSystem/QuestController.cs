using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestController : MonoBehaviour {

	GameObject _text;
	float alpha;
	bool isFading = false;
	
	public int QuestId{get;set;}
	public int EnemyId{get;set;}
	public int NumberOfEnemies{get;set;}

	//kill enemies
	float time=0f; //check enemies every n seconds
	GameObject[] enemies;
	public int Target{get;set;}

	void Update()
	{
		if(_text == null)
			_text = GameObject.FindGameObjectWithTag("questText");

		KillEnemies();
		TextIsFading();
	}

	IEnumerator QuestCompleted()
	{
		Text temp = _text.GetComponent<Text>();
		temp.text = "<size=50>Quest Complete</size>";
		yield return new WaitForSeconds(1f);
		isFading = true;
	}

	void TextIsFading()
	{
		Text temp = _text.GetComponent<Text>();
		if(isFading)
		{
			//alpha = -0.3f*Time.deltaTime;
			temp.color = new Color(temp.color.r,temp.color.g,temp.color.b, temp.color.a-0.4f*Time.deltaTime);
			if(temp.color.a <=0)
			{
				temp.color = Color.white;
				temp.text = string.Empty;
				isFading = false;
			}
		}
	}


	//Quest ID1
	void ShowTaskText(int enemiesKilled)
	{
		_text.GetComponentInChildren<Text>().text = "<color=whilte>Task: </color>\n" + "<size=20><color=#FFAE00FF>"+enemiesKilled + "/" + NumberOfEnemies + " Wanderers slain</color></size>";
	}
	void KillEnemies() //quest id 1
	{
		if(QuestId == 1)
		{
			if(Target >= NumberOfEnemies)
			{
				QuestId = 0;
				Debug.Log("quest completed");
				StartCoroutine(QuestCompleted());
			}
			else
			{
				ShowTaskText(Target);
			}
		}
	}
	public void IncrementQuest(int id)
	{
		if(id == EnemyId)
		{
			Target++;
		}
	}


	




}
