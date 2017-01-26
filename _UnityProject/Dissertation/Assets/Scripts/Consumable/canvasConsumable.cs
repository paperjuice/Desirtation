using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasConsumable : MonoBehaviour {


	useConsumable useConsumable;
	[SerializeField]int id;
	public int Id{
		get{return id;}
		set{id = value;}
	}

	void Awake()
	{
		useConsumable = GameObject.FindGameObjectWithTag("useConsumable").GetComponent<useConsumable>();
	}

	public void SelectConsumable()
	{
		useConsumable.Id = Id;
		useConsumable.SlotPosition = transform.parent.gameObject;
	}

	void OnMouseEnter()
	{
		print("sadasdasdas");
	}




}
