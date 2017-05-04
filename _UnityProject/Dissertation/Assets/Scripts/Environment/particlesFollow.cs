using System.Collections;
using UnityEngine;

public class particlesFollow : MonoBehaviour {

	GameObject player;
	[SerializeField] float followSpeed;


	IEnumerator Start()
	{
		yield return new WaitForSeconds(0.1f);
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if(player!=null)
			transform.position = Vector3.Lerp(transform.position, player.transform.position - new Vector3(0,0,15f), Time.deltaTime*followSpeed/10);
	}
}
