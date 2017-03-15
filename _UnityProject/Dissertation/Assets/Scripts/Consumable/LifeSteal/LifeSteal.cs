using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSteal : MonoBehaviour {

	consumablePotency _cp;
	mcStats _mcStats;
	float chanceToStealLife;


	void Awake()
	{
		_cp = GameObject.FindGameObjectWithTag("Player").GetComponent<consumablePotency>();
		_mcStats = GameObject.FindGameObjectWithTag("Player").GetComponent<mcStats>();
	}

	void OnTriggerEnter(Collider col)
	{
		if(_cp.LifestealLevel>0)
		{
			if(col.gameObject.tag=="enemy")
			{
				if(col.gameObject.GetComponent<generalEnemyStats>().eCurrentHealth <=0)
				{
					StealLife();
				}
			}
		}
	}

	void StealLife()
	{
		chanceToStealLife = Random.Range(10f, 100f);
		if(chanceToStealLife<=_mcStats.Wisdom()/0.7f)
			_mcStats.CurrentHealth-= 7;
	}

}
