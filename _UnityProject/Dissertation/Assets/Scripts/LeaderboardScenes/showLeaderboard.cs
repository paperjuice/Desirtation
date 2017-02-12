using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showLeaderboard : MonoBehaviour {

	leaderboard _l;
	[SerializeField] TextMesh text;
	bool isDoneShowingScores;


	void Awake()
	{
		_l = GetComponent<leaderboard>();
	}

	void Update()
	{
		if(!isDoneShowingScores && _l.ShowLeaderboard().Count != 0)
		{
			for(int i = 0; i< _l.ShowLeaderboard().Count;i++)
			{
				text.text += i+1 + ". " + _l.ShowLeaderboard()[i] + "\n";
			}
			isDoneShowingScores = true;
		}
	}
}
