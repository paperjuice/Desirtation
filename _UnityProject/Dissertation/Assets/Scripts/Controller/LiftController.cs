using UnityEngine;
using UnityEngine.UI;

public class LiftController : MonoBehaviour {

	fadeOutFadein _fadeIn;
	Text _pressE;
	bool isAscending = false;
	[SerializeField] string sceneName = "FloorProgression";
	[SerializeField] int amountOfDungeonIncrement;
	// [SerializeField] GameObject platform;


	void Awake()
	{
		_fadeIn = GameObject.FindGameObjectWithTag("fadeIn").GetComponent<fadeOutFadein>();
		_pressE = GameObject.FindGameObjectWithTag("pressE").GetComponent<Text>();
	}

	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				_fadeIn.enabled = true;
				_fadeIn.SceneName = sceneName;
				controller.dungeonLevel += amountOfDungeonIncrement;
				//col.gameObject.transform.parent = platform.transform;
				// platform.GetComponent<Animator>().SetBool("move", true);
				// enabled = false;
				GetComponent<BoxCollider>().enabled = false;
				isAscending = true;
				_pressE.enabled = false;
			}
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			_pressE.text = "Press E to Ascend";
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			_pressE.text = string.Empty;
		}
	}

	void Update()
	{
		if(isAscending)
		{
			transform.position += Vector3.up * Time.deltaTime * 3f;
		}
	}



}
