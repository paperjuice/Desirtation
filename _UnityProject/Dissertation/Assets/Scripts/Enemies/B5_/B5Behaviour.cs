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
	float distance;

	//dash
	[HeaderAttribute("Dash Power")] 
	[SerializeField] float power;
	int rollDash;
	Vector3 dashRandomPosition;

	//Attack
	[SerializeField] Animator anim;
	[SerializeField] List<string> closeRangeAttack;
	[SerializeField] List<string> farRangeAttack;
	bool isRushinTowardsPlayer;
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
		RushingThePlayer();
	}

	void Movement()
	{
		distance = Vector3.Distance(transform.position, player.transform.position);

		if(distance < 10 )
		{
			time_between_random_movement +=Time.deltaTime;
			if(time_between_random_movement > end_time)
			{
				random_movement = Random.Range(0,10);
				time_between_random_movement = 0f;
				RollDash();
			}
		}
		else if(distance >= 10)
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
			if(distance>6)
				AttackFarRange();
			else
				AttackCloseRange();
			StartCoroutine(SetAttackingToFalse());
			isAttacking = true;
		}
	}


	void RotateTowardsPlayer()
	{
		Vector3 direction = player.transform.position - transform.position;
		direction.y = 0;
		Quaternion target = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * rs);
	}


	void AttackCloseRange()
	{
		chooseAttack  = Random.Range(0, closeRangeAttack.Count);
		anim.SetTrigger(closeRangeAttack[chooseAttack]);
	}

	void AttackFarRange()
	{
		chooseAttack  = Random.Range(0, farRangeAttack.Count);
		StartCoroutine(WaitForCombo());
		anim.SetTrigger(farRangeAttack[chooseAttack]);
	}

	IEnumerator WaitForCombo()
	{
		var randomTime = Random.Range(0.75f, 1.5f);
		yield return new WaitForSeconds(randomTime);
		isRushinTowardsPlayer = true;
		
		// transform.position = player.transform.position - transform.forward* 3f;
	}

	void RushingThePlayer()
	{
		distance = Vector3.Distance(transform.position, player.transform.position);

		if(isRushinTowardsPlayer)
		{
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 20f * Time.deltaTime);
		}

		if(distance < 3)
		{
			anim.SetTrigger("combo1.1");
			isRushinTowardsPlayer = false;
		}
	}

	// void SetAttackingToFalse()
	// {
	// 	if(anim.GetCurrentAnimatorStateInfo(0).IsName("Armature|idle") && isAttacking)
	// 	{
	// 		isAttacking = false;
	// 	}
	// }

	IEnumerator SetAttackingToFalse()
	{
		yield return new WaitForSeconds(5f);
		isAttacking = false;
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
