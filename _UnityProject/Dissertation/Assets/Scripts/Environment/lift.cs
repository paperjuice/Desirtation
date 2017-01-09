using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class lift : MonoBehaviour {

	
	GameObject player;
	float progress;
	bool isDescending;
	bool isLocked;
	[SerializeField] string sceneName;
	[SerializeField] float speed;
	[SerializeField] GameObject wheel;
	[SerializeField] GameObject chord;
	[SerializeField] GameObject platform;
	[SerializeField] Image fadeInImage;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		Distance();
		DescendingPlatform();
	}


	void Distance()
	{
		if(Vector3.Distance(transform.position, player.transform.position)<3f)
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
		if(isDescending && !isLocked)
		{
			wheel.transform.Rotate(transform.up * Time.deltaTime* speed*10f);
			chord.transform.position += Time.deltaTime * Vector3.up ; 
			platform.transform.position -= Time.deltaTime * Vector3.up * speed;
			progress += Time.deltaTime;
		}else if (!isDescending && !isLocked && progress >=0)
		{
			wheel.transform.Rotate(-transform.up * Time.deltaTime *speed * 10f);
			chord.transform.position -= Time.deltaTime * Vector3.up ; 
			platform.transform.position += Time.deltaTime * Vector3.up * speed;
			progress -= Time.deltaTime;
		}




		if(progress >= 3)
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
			other.gameObject.transform.parent = platform.transform;
			StartCoroutine(Ascend());
		}
	}

	IEnumerator Ascend()
	{
		while(true)
		{
			wheel.transform.Rotate(-transform.up * Time.deltaTime *speed * 10f);
			chord.transform.position -= Time.deltaTime * Vector3.up ; 
			platform.transform.position += Time.deltaTime * Vector3.up * speed;
			fadeInImage.color += new Color(0,0,0,Time.deltaTime * 0.5f);
			if(fadeInImage.color.a>=1)
				SceneManager.LoadScene(sceneName);
			yield return new WaitForEndOfFrame();
		}

		
	}


}
