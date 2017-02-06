using UnityEngine;
using UnityEngine.UI;

public class pressE_textBehaviour : MonoBehaviour {

	Text _text;
	[SerializeField] string theTextWhichWillShowOnTheScreen;
	[SerializeField] GameObject panelName;

	GameObject[] objectToFind;
	GameObject player;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		_text = GameObject.FindGameObjectWithTag("pressE").GetComponent<Text>();
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject ==player)
		{
			_text.text = theTextWhichWillShowOnTheScreen;
			if(panelName != null)
				panelName.gameObject.SetActive(true);
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(col.gameObject == player)
		{
			_text.text = string.Empty;
			if(panelName != null)
				panelName.gameObject.SetActive(false);
		}
	}


	






}
