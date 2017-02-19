using UnityEngine;
using UnityEngine.UI;

public class holdScore : MonoBehaviour {


	[SerializeField]leaderboard _leaderboard;
	[SerializeField] Text titleText;
	private fadeOutFadein fadeIn;



	string _name;
	int score;

	void Awake()
	{
		titleText.text = string.Format("You reached FLOOR {0}\nYour name shall be remembered", controller.dungeonLevel);
		_leaderboard = GetComponent<leaderboard>();
	}

	void Start()
	{
		score = controller.dungeonLevel;
	}

	public void RegisterScore()
	{
		fadeIn = GameObject.FindGameObjectWithTag("fadeIn").GetComponent<fadeOutFadein>();         
		_name = GetComponent<InputField>().text;
		_leaderboard.GetScore(_name, score);
		fadeIn.enabled = true;
		controller.dungeonLevel = 1;

	}


}
