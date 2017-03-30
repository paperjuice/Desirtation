using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3SpearBehaviour : MonoBehaviour {

	GameObject player;
	bool isActive;
	[SerializeField] float power;
	[SerializeField] float damage;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Start()
	{
		transform.LookAt(player.transform.position + new Vector3(0,1,0));
		StartCoroutine(TimeUntilToss());
		Destroy(gameObject, 4f);
		damage += controller.dungeonLevel *1.2f;
	}

	IEnumerator TimeUntilToss()
	{
		yield return new WaitForSeconds(1f);
		isActive = true;
	}

	void Update(){
		if(isActive)
			transform.position += Time.deltaTime * power * transform.forward;
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			col.gameObject.GetComponent<mcStats>().IncrementAgeOnDamageReceived(damage);
			Camera.main.GetComponent<Animator>().SetTrigger("shakePlayer");
			col.gameObject.GetComponent<Rigidbody>().AddForce(-transform.position + col.gameObject.transform.position* Time.fixedDeltaTime *600000f);
			Destroy(gameObject, 0.2f);
		}

		if(col.gameObject.tag == "shield")
		{
			Camera.main.GetComponent<Animator>().SetTrigger("shake");
			col.gameObject.GetComponent<Rigidbody>().AddForce(-transform.position + col.gameObject.transform.position* Time.fixedDeltaTime *500000f);
			Destroy(gameObject);
		}
	}

}
