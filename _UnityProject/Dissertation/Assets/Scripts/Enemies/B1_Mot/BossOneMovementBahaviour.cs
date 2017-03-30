using UnityEngine;

public class BossOneMovementBahaviour : MonoBehaviour {


	GameObject player;
	Animator anim;
	
	float currentTimeBetweenStates;
	float endTimeBetweenStates;

	//Attack
	[SerializeField] string[] attackNames;
	int rollAttack;


	//Movement
	[HeaderAttribute("Movement")]
	[SerializeField] float ms;
	[SerializeField] float rs;
	float endTimeBetweenMovementChange = 2f;
	float currentTimeBetweenMovementChange = 0;
	int movementDirection;


	enum State
	{
		Idle, Move, Attack, Defend
	}

	void Awake()
	{
		anim = GetComponentInChildren<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update()
	{
		Movement();
		RotateTowardsPlayer();
	}

	void Movement()
	{
		currentTimeBetweenMovementChange += Time.deltaTime;
		if(currentTimeBetweenMovementChange >= endTimeBetweenMovementChange)
		{
			if(Vector3.Distance(transform.position, player.transform.position)<10)
				Attack();
				
			endTimeBetweenMovementChange = Random.Range(1f,3f);
			movementDirection = Random.Range(1,4);
			currentTimeBetweenMovementChange = 0f;
		}

		switch(movementDirection)
		{
			case 1:
				if(Vector3.Distance(transform.position, player.transform.position)>4)
					transform.position += Time.deltaTime * ms * transform.forward;
				else
					transform.position -= Time.deltaTime * ms/1.5f * transform.forward;
				break;
			case 2:
				transform.position += Time.deltaTime * ms * transform.right;
				break;
			case 3:
				transform.position -= Time.deltaTime * ms * transform.right;
				break;
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
		rollAttack = Random.Range(0,10);

		if(rollAttack<3)
		{
			rollAttack = Random.Range(0, attackNames.Length);
			anim.SetTrigger(attackNames[rollAttack]);
		}
		else if(rollAttack == 4)
		{
			Taunt();
		}
	}

	void Taunt()
	{
		anim.SetTrigger("taunt");
	}
}
