using UnityEngine;
using System.Collections;

public class ShieldCharge : MonoBehaviour {

	
	GameObject player;
	[SerializeField] mcMovementBehaviour mcStats;
	[SerializeField] debuff _debuff;
	[SerializeField] Rigidbody rigid;
	[SerializeField] float speed;
	Vector3 chargeTarget;

	bool isCharging = false;

void Awake(){
	player = GameObject.FindGameObjectWithTag("Player");
}


	void Update()
	{
		Charge();
		if(Input.GetKeyDown(KeyCode.Mouse1))
		{
			mcStats.enabled =false;
			_debuff.enabled = false;
			isCharging = true;
			StartCoroutine(StopCharge());
		}
	}

	void Charge()
	{
		if(isCharging)
		{
			rigid.MovePosition(player.transform.position + player.transform.forward * Time.fixedDeltaTime * speed);
		}
	}

	IEnumerator StopCharge()
	{
		yield return new WaitForSeconds(0.15f);
		isCharging=false;
		mcStats.enabled =true;
		_debuff.enabled = true;
	}
}
