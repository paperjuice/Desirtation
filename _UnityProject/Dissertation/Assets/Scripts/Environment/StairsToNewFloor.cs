using UnityEngine;

public class StairsToNewFloor : MonoBehaviour {

	fadeOutFadein _fadeIn;
	[SerializeField] string sceneName = "FloorProgression";
	[SerializeField] int amountOfDungeonIncrement;
	[SerializeField] GameObject platform;


	void Awake()
	{
		_fadeIn = GameObject.FindGameObjectWithTag("fadeIn").GetComponent<fadeOutFadein>();
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			_fadeIn.enabled = true;
			_fadeIn.SceneName = sceneName;
			controller.dungeonLevel += amountOfDungeonIncrement;
			//col.gameObject.transform.parent = platform.transform;
			platform.GetComponent<Animator>().SetBool("move", true);
			enabled = false;
		}
	}
}
