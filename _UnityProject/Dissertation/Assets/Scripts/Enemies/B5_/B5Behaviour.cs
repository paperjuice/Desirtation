using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B5Behaviour : MonoBehaviour {

	
	GameObject player;
	[SerializeField] float rs;
	Rigidbody _rigid;


	//movement
	[SerializeField] float ms;
	float time_between_random_movement;
	float end_time = 2;
	int random_movement = 0;

	//dash
	[HeaderAttribute("Dash Power")] 
	[SerializeField] float power;
	int rollDash;
	Vector3 dashRandomPosition;

	//Attack
	[SerializeField] Animator anim;
	[SerializeField] List<string> listOfAttacks;
	int chooseAttack;
	int chanceToAttack = 0;
	float current_chooseAttack;
	float end_chooseAttack = 3;
	bool isAttacking = false;


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		_rigid = GetComponent<Rigidbody>();
	}

	void Update()
	{
		RotateTowardsPlayer();
		// if(!isAttacking)
			Movement();

		SetAttackingToFalse();
	}

	void Movement()
	{
		if(Vector3.Distance(transform.position, player.transform.position) < 10 )
		{
			time_between_random_movement +=Time.deltaTime;
			if(time_between_random_movement > end_time)
			{
				random_movement = Random.Range(0,10);
				time_between_random_movement = 0f;
			//	RollDash();
			}
		}
		else if(Vector3.Distance(transform.position, player.transform.position) >= 10)
		{
			transform.position += transform.forward * Time.deltaTime * ms;
		}

		if(random_movement == 0)
		{
			transform.position += transform.forward * Time.deltaTime * ms;
		}
		if(random_movement == 1)
		{
				transform.position += transform.right * Time.deltaTime * ms * 2;
		}
		if(random_movement == 2)
		{
				transform.position -= transform.right * Time.deltaTime * ms * 2;
		}
		if(random_movement >=3 && !isAttacking)	
		{	
				Attack();
				isAttacking=true;
		}
	}


	void RotateTowardsPlayer()
	{
		Vector3 direction = player.transform.position - transform.position;
		direction.y = 0;
		Quaternion target = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * rs);
	}


	void Attack()
	{
		chooseAttack  = Random.Range(0, listOfAttacks.Count);
		if(chooseAttack==0 || chooseAttack==3 )
			StartCoroutine(WaitForCombo1());

		anim.SetTrigger(listOfAttacks[chooseAttack]);
	}

	IEnumerator WaitForCombo1()
	{
		yield return new WaitForSeconds(1);
		anim.SetTrigger("combo1.1");
		transform.position = player.transform.position - transform.forward* 3f;
	}

	void SetAttackingToFalse()
	{
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Armature|idle") && isAttacking)
		{
			isAttacking = false;
		}
	}

	void RollDash()
	{
		print("dash");
		rollDash = Random.Range(0,10);
		dashRandomPosition = new Vector3(transform.position.x + Random.Range(-3,3), transform.position.y , transform.position.z + Random.Range(-3,3));
		if(rollDash <6)
			_rigid.AddForce(((transform.position - dashRandomPosition).normalized) * Time.fixedDeltaTime * power * 60000); 

	}



}
