using UnityEngine;
using UnityEngine.UI;

public class holdScore : MonoBehaviour {

	public static float score;
	mcStats player;

	void Update()
	{
		if(player == null)
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<mcStats>();		
		score = mcStats.knowledge;
	}


}
