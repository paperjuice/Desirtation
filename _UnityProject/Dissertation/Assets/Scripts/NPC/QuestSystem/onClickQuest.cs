using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickQuest : MonoBehaviour {

	
	[SerializeField] GameObject description;

	GameObject[] questDescriptions;
	SpriteRenderer _sprite;


	void Awake()
	{
		_sprite = GetComponent<SpriteRenderer>();
	}



	private void Update()
	{
		if (description.gameObject.activeInHierarchy)
			_sprite.color = new Color32(214, 214, 214, 255);
		else
			_sprite.color = new Color32(156, 156, 156, 156);
	}

	private void OnMouseDown()
	{
		questDescriptions = GameObject.FindGameObjectsWithTag("questDescription");
		foreach (GameObject a in questDescriptions)
			a.gameObject.SetActive(false);
		description.gameObject.SetActive(true);


	}

}
