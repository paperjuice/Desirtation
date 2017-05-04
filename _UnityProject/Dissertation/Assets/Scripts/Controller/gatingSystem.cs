using System.Collections.Generic;
using UnityEngine;

public class GatingSystem : MonoBehaviour {

	[SerializeField] Animator[] gatesAnim;
	bool isGateOpen;
	List<GameObject> enemies = new List<GameObject>(0);


	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "enemy")
				enemies.Add(col.gameObject);
	
		if(col.gameObject.tag == "Player")
			foreach(Animator a in gatesAnim)
				a.SetBool("close", true);
	}

	void Update()
	{
		print(enemies.Count);
		foreach( GameObject enemy in enemies)
		{
			foreach(Animator a in gatesAnim)
			{
				if(!enemy.gameObject.activeInHierarchy)
					a.SetBool("close", false);
				else
					a.SetBool("close", true);
			}
		}


		// foreach(Animator a in gatesAnim)
		// {
		// 	if(enemies.Count == 0)
		// 		a.SetBool("close", false);
		// 	else
		// 		a.SetBool("close", true);
		// }
	}
}
