﻿using System.Collections;
using UnityEngine;

public class aoe_DealDmgPerSecond : MonoBehaviour {

	private consumableEffect _ce;
	private GameObject[] enemies;


	void Awake()
	{
		_ce = GameObject.FindGameObjectWithTag("Player").GetComponent<consumableEffect>();
	}

	IEnumerator Start()
	{
		while(true)
		{
			enemies=GameObject.FindGameObjectsWithTag("enemy");
			yield return new WaitForSeconds(0.5f);
		}

	}


	void Update()
	{
		foreach(GameObject e in enemies)
		{
			if(Vector3.Distance(transform.position,e.transform.position)<3)
			{
				e.GetComponent<generalEnemyStats>().eCurrentHealth -= _ce.AOE_DeadDmgPerSecond();
			}

		}

	}



}
