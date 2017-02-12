using UnityEngine;

public class questGiverSpawnController : MonoBehaviour {

	[SerializeField] GameObject[] questGivers;
	GameObject[] questGiverSpawnPoints;
	GameObject player;
	QuestController questController;
	float chanceToGetQuestGiver;


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		
	}

	void Update()
	{
		if(questGiverSpawnPoints==null)
			questGiverSpawnPoints = GameObject.FindGameObjectsWithTag("questGiverSpawnPoint");
		if(questController==null)
			questController = GameObject.FindGameObjectWithTag("questController").GetComponent<QuestController>();

		SpawnQuestGiver();
	}


	void SpawnQuestGiver()
	{
		if(questGiverSpawnPoints != null && player != null)
		{
			foreach(GameObject a in questGiverSpawnPoints)
			{
				if(Vector3.Distance(a.transform.position, player.transform.position) <40 && questController.QuestId==0 && controller.dungeonLevel>2)
				{
					chanceToGetQuestGiver = Random.Range(1f,100f);
					if(chanceToGetQuestGiver<=15f)
					{
						Instantiate(questGivers[Random.Range(0,questGivers.Length)], a.transform.position, transform.rotation);
						a.gameObject.SetActive(false);
						foreach(GameObject b in questGiverSpawnPoints)
							Destroy(b.gameObject);
						this.enabled = false;

					}
					else
					{
						a.gameObject.SetActive(false);
					}
				}
			}
		}
	}
}
