using UnityEngine;
using System.Collections;

public class B3Behaviour : MonoBehaviour {

	GameObject player;

	[SerializeField] float ms;
	[SerializeField] float rs;
	int random_movement;
	float time_between_random_movement;
	float end_time = 3f;

	//attack
	[SerializeField] Animator anim;
	[SerializeField] string[] attack_animation = new string[3]; 
	int number_of_attacks = 0;
	bool isPreparedToAttack = false;
	bool isAttacking = false;
	int random_attack = 0;


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Start()
	{
		time_between_random_movement = end_time;
	}

	void Update()
	{
		if(!isPreparedToAttack)
			Movement();
		else
			Attack();

		RotateTowardsPlayer();
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
			transform.position += transform.forward * Time.deltaTime * ms;
		if(random_movement == 1)
				transform.position += transform.right * Time.deltaTime * ms;
		if(random_movement == 2)
				transform.position -= transform.right * Time.deltaTime * ms;
		if(random_movement >=3)	
		{	
				number_of_attacks = Random.Range(3,6);
				isPreparedToAttack = true;
				random_movement = -1;
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
		if(number_of_attacks > 0 && !isAttacking)
		{
			isAttacking = true;
			random_attack = Random.Range(0,3);
		}
		else if(number_of_attacks <= 0)
		{
			isPreparedToAttack = false;
		}

		anim.SetTrigger(attack_animation[random_attack]);
		StartCoroutine(TimeUntilNextAttack(1.5f));
	}

	IEnumerator TimeUntilNextAttack(float time)
	{
		yield return new WaitForSeconds(time);
		isAttacking = false;
		number_of_attacks--;
	}



}
