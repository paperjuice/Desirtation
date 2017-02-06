using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McSpawnController : MonoBehaviour {

	[SerializeField] GameObject mc;
	GameObject player;
	GameObject mcContainer;
	MonoBehaviour[] behaviours;
	GameObject[] mcSpawnPoints;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		mcSpawnPoints = GameObject.FindGameObjectsWithTag("mcSpawnPoint");

		if(player != null)
			this.enabled = false;

		if(player==null){
			mcContainer = Instantiate(mc, mcSpawnPoints[Random.Range(0,mcSpawnPoints.Length)].transform.position, mc.transform.rotation);
			DontDestroyOnLoad(mcContainer.gameObject);
		}
		else{
			//DontDestroyOnLoad(player.gameObject);
			behaviours = player.GetComponents<MonoBehaviour>();
			foreach(MonoBehaviour mb in behaviours)
				mb.enabled = true;
			player.transform.position = mcSpawnPoints[Random.Range(0,mcSpawnPoints.Length)].transform.position;
		}
	}


}
