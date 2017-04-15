using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutSound : MonoBehaviour {

		[SerializeField] float fadeSpeed;
		GameObject[] sounds;
		public bool IsFading{get; set;}


		void Awake()
		{
			sounds = GameObject.FindGameObjectsWithTag("audio");
		}

		void Update()
		{
			FadeOutAllSounds();
		}

		public void FadeOutAllSounds( )
		{
			if(IsFading)
			{
				foreach(GameObject a in sounds)
				{
					a.GetComponent<AudioSource>().volume -= fadeSpeed * Time.deltaTime;
				}
			}
		}
}
