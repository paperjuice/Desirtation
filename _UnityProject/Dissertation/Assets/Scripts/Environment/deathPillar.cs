using UnityEngine;
using System.Collections;

public class deathPillar : MonoBehaviour {

	mcStats _mcStats;
	mcMovementBehaviour _mcMovementBehaviour;
	bool controlDamage;


	void Awake()
	{
		_mcStats = GameObject.FindGameObjectWithTag("Player").GetComponent<mcStats>();
		_mcMovementBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<mcMovementBehaviour>();
	} 


	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(!controlDamage && !_mcMovementBehaviour.isInvincible)
			{
				_mcStats.IncrementAgeOnDamageReceived(0.5f* Time.deltaTime);
				controlDamage = true;
				StartCoroutine(ControlDamage());
			}
		}
	}

	IEnumerator ControlDamage()
	{
		yield return new WaitForSeconds(0.1f);
		controlDamage = false;
	}
}
