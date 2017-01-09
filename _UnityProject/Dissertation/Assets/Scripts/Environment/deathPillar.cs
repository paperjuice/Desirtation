using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathPillar : MonoBehaviour {

	mcStats _mcStats;
	mcMovementBehaviour _mcMovementBehaviour;


	void Awake()
	{
		_mcStats = GameObject.FindGameObjectWithTag("Player").GetComponent<mcStats>();
		_mcMovementBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<mcMovementBehaviour>();
	} 

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(!_mcMovementBehaviour.isInvincible)
				_mcStats.Health(_mcStats.MaxHealth*0.2f * Time.deltaTime);
		}
	}
}
