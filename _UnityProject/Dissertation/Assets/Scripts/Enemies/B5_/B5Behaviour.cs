using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B5Behaviour : MonoBehaviour {

	
	GameObject player;
	[SerializeField] float rs;


	//movement
	[SerializeField] float ms;
	float time_between_random_movement;
	float end_time = 2;
	int random_movement = 0;

	//Attack
	[SerializeField] Animator anim;
	int chanceToAttack = 0;
	float current_chooseAttack;
	float end_chooseAttack = 3;
	bool isAttacking = false;


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		RotateTowardsPlayer();
		if(!isAttacking)
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
		if(random_movement >=3)	
		{	
				//aici attaca
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

	}

	void SetAttackingToFalse()
	{
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Armature|idle") && isAttacking)
		{
			isAttacking = true;
		}
	}


}
