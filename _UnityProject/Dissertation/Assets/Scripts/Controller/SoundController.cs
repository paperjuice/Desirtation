using System.Collections;
using UnityEngine;

public class SoundController : MonoBehaviour {

	[SerializeField] AudioSource[] randomAudioNoises;


	IEnumerator Start()
	{
		var random = 0;
		while(true)
		{
			yield return new WaitForSeconds(4f);
			random = Random.Range(0,10);
			if(random == 1)
			{
				randomAudioNoises[Random.Range(0, randomAudioNoises.Length)].Play();
			}
		}
		
	}
}
