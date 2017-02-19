using UnityEngine;


public class QuestGiver : MonoBehaviour {

	[SerializeField] Animator anim;
 	HoldTaskPanels _panel;
	GameObject questController;

	//information to pass to quest controller	
	int questId;
	int enemyId;
	int numberOfEnemies;

	void Awake()
	{
		questController = GameObject.FindGameObjectWithTag("questController");
		_panel = GameObject.FindGameObjectWithTag("questPanel").GetComponent<HoldTaskPanels>();
	}


	void Start()
	{
		questId = Random.Range(1,2);
		enemyId = Random.Range(1,2);
		numberOfEnemies = Random.Range(7,12);
	}

	void Update()
	{
		if(Vector3.Distance(transform.position, questController.transform.position) < 2)
		{
			anim.SetBool("talking", true);
			RotateTowardsPlayer();
			_panel.TaskPanels[questId-1].gameObject.SetActive(true);
			if(Input.GetKeyDown(KeyCode.E))
			{
				questController.GetComponent<QuestController>().QuestId = questId;
				questController.GetComponent<QuestController>().EnemyId = questId;
				questController.GetComponent<QuestController>().NumberOfEnemies = numberOfEnemies;
				_panel.TaskPanels[questId-1].gameObject.SetActive(false);
				anim.SetBool("talking", false);
				enabled = false;
			}
		}	
		else
		{
			_panel.TaskPanels[questId-1].gameObject.SetActive(false);
			anim.SetBool("talking", false);
		}

	}

	void RotateTowardsPlayer()
	{
		Vector3 direction = -transform.position + questController.transform.position;
		direction.y = 0;
		Quaternion target = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 2f);
	}

}
