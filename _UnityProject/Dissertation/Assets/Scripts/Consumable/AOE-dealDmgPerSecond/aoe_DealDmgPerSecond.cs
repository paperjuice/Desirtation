using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoe_DealDmgPerSecond : MonoBehaviour {

	private consumableEffect _ce;
	private GameObject[] enemies;
	float time;
	float endTime=1;
	


	void Awake()
	{
		_ce = GameObject.FindGameObjectWithTag("Player").GetComponent<consumableEffect>();
	}

	IEnumerator Start()
	{
		while(true)
		{
			enemies=GameObject.FindGameObjectsWithTag("enemy");
			yield return new WaitForSeconds(2f);
		}

	}


	void Update()
	{
		foreach(GameObject e in enemies)
		{
			if(e != null)
				if(Vector3.Distance(transform.position,e.transform.position)<3)
				{
					if(time >= endTime)
					{
						 	;
						e.GetComponent<generalEnemyStats>().ReceiveDamage(_ce.AOE_DeadDmgPerSecond());
						time = 0;
					}
					
				}
		}

		if(time <= endTime)
		{
			time += Time.deltaTime;
		}

	}



}
