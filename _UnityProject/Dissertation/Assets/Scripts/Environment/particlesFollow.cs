using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesFollow : MonoBehaviour {

	GameObject player;
	[SerializeField] float followSpeed;


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, player.transform.position - new Vector3(0,0,15f), Time.deltaTime*followSpeed/10);
	}
}
