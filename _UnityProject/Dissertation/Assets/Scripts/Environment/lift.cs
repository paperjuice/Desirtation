using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class lift : MonoBehaviour {

	
	GameObject player;
	float progress;
	bool isDescending;
	bool isLocked;
	Text pressE;
	[SerializeField] int amountOfDungeonIncrement;
	[SerializeField] string sceneName;
	[SerializeField] float speed;
	[SerializeField] GameObject wheel;
	[SerializeField] GameObject chord;
	[SerializeField] GameObject platform;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		pressE = GameObject.FindGameObjectWithTag("pressE").GetComponent<Text>();
	}

	void Update()
	{
		Distance();
		DescendingPlatform();
	}


	void Distance()
	{
		if(Vector3.Distance(transform.position, player.transform.position)<2f)
		{
			if(Input.GetKey(KeyCode.E))
			{
				isDescending = true;
			}
			else{
				isDescending = false;
			}
		}else{
			isDescending =false;
		}
		
	}

	void DescendingPlatform()
	{
		progress = platform.transform.localPosition.y;

		if(isDescending && !isLocked)
		{
			wheel.transform.Rotate(transform.up * Time.deltaTime* speed*10f);
			chord.transform.position += Time.deltaTime * Vector3.up ; 
			platform.transform.position -= Time.deltaTime * Vector3.up * speed;
		}else if (!isDescending && !isLocked && progress >=0 && platform.transform.localPosition.y >13f)
		{
			wheel.transform.Rotate(-transform.up * Time.deltaTime *speed * 10f);
			chord.transform.position -= Time.deltaTime * Vector3.up ; 
			platform.transform.position += Time.deltaTime * Vector3.up * speed;
		}

		if(progress <= 0)
		{
			isLocked = true;
			GetComponent<BoxCollider>().enabled = true;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			progress = 0;
			isLocked = false;
			foreach ( MonoBehaviour b in other.gameObject.GetComponents<MonoBehaviour>())
			{
				b.enabled = false;
			}

			GameObject.FindGameObjectWithTag("PlayerMesh").GetComponent<Animator>().SetBool("walkin", false);
			//other.gameObject.transform.parent = platform.transform;
			controller.dungeonLevel += amountOfDungeonIncrement;
			StartCoroutine(Ascend());
		}
	}

	IEnumerator Ascend()
	{
		fadeOutFadein fadeIn = GameObject.FindGameObjectWithTag("fadeIn").GetComponent<fadeOutFadein>();

		while(true)
		{
			wheel.transform.Rotate(-transform.up * Time.deltaTime *speed * 10f);
			chord.transform.position -= Time.deltaTime * Vector3.up ; 
			platform.transform.position += Time.deltaTime * Vector3.up * speed;
			fadeIn.enabled = true;
			fadeIn.SceneName = "game2_randomMapGen";
			yield return new WaitForEndOfFrame();
		}

		
	}


}
