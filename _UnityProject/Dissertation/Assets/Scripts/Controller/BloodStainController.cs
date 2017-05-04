using System.Collections;
using UnityEngine;

public class BloodStainController : MonoBehaviour {

		GameObject[] images;
		GameObject player;


		IEnumerator Start()
		{
			while(true)
			{
				images = GameObject.FindGameObjectsWithTag("fadeThis");
				yield return new WaitForSeconds(2);
			}
		}

		void Update()
		{
			if(player == null)
				player = GameObject.FindGameObjectWithTag("Player");


			DestroyPngBasedOnDistance();
			// print(images.Length);
			if(images.Length > 7)
			{
				if(images[0] != null)
				{
					images[0].GetComponent<SpriteRenderer>().color -= new Color(0,0,0,2) * Time.deltaTime;

					if(images[0].GetComponent<SpriteRenderer>().color.a <=0)
					{
						Destroy(images[0]);
					}
				}
			}
		}

		void DestroyPngBasedOnDistance()
		{
			foreach(GameObject go in images )
			{
				if(go!= null)
				{
					if(Vector3.Distance(go.transform.position, player.transform.position) > 20)
					{
						Destroy(go.gameObject);
					}
				}
			}
			
		}


}
