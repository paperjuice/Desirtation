using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShieldCharge : MonoBehaviour {

	
	GameObject player;
	[SerializeField] mcMovementBehaviour mcMB;
	[SerializeField] mcStats _mcStats;
	[SerializeField] debuff _debuff;
	[SerializeField] Rigidbody rigid;
	[SerializeField] float speed;
	[SerializeField] GameObject playerMesh;
	[SerializeField] BoxCollider _collider;
	[SerializeField] float damage = 0.5f;
	Vector3 chargeTarget;
	float chargeCost = 0.3f;
	bool isCharging = false;
	bool disableDoubleCharge;

void Awake(){
	player = GameObject.FindGameObjectWithTag("Player");
}


	void Update()
	{
		
		Charge();

		if(Input.GetKeyDown(KeyCode.Mouse1) && _mcStats.Spirit(0) > _mcStats.MaxSpirit*chargeCost && !disableDoubleCharge && _debuff.SecondsInterrupted <= 0)
		{
			mcMB.enabled =false;
			_debuff.enabled = false;
			isCharging = true;
			StartCoroutine(StopCharge());
			_mcStats.Spirit(_mcStats.MaxSpirit*chargeCost);
			disableDoubleCharge=true;
		}
	}

	void Charge()
	{
		mcMB.CanBlock=false;
		if(isCharging)
		{
			rigid.MovePosition(player.transform.position + player.transform.forward * Time.fixedDeltaTime * speed);
			playerMesh.transform.localRotation = Quaternion.Euler(35f,0,0);
			_collider.enabled = true;
		}
	}

	IEnumerator StopCharge()
	{
		yield return new WaitForSeconds(0.30f);
		isCharging=false;
		mcMB.enabled =true;
		_debuff.enabled = true;
		playerMesh.transform.localRotation = Quaternion.Euler(0f,0f,0f);
		_collider.enabled = false;
		disableDoubleCharge=false;
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "enemy")
		{
			var generalEnemySts= col.gameObject.GetComponent<generalEnemyStats>();
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("shake");
			generalEnemySts.ReceiveDamage(_mcStats.Wisdom()*damage);
			generalEnemySts.IsHit = true;
		}
	}
}
