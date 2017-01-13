using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pressE_textBehaviour : MonoBehaviour {

	Text _text;
	[SerializeField] string theTextWhichWillShowOnTheScreen;

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
			_text.text = theTextWhichWillShowOnTheScreen;
	}
	void OnTriggerExit(Collider col)
	{
		if(col.gameObject == player)
			_text.text = string.Empty;
	}


	






}
