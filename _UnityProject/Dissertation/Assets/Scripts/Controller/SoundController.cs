using System.Collections;
using UnityEngine;

public class SoundController : MonoBehaviour {

	[SerializeField] AudioSource[] randomAudioNoises;
	[HeaderAttribute("EnemySound")]
	[SerializeField] AudioSource[] enemyHitSound;

	[HeaderAttribute("DestructibleSound")]
	[SerializeField] AudioSource[] destructibleWoodSound;
	[SerializeField] AudioSource[] destructibleStoneSound;

	[HeaderAttribute("MC Sound")]
	[SerializeField] AudioSource[] swordHitProp;




	IEnumerator Start()
	{
		var random = 0;
		while(true)
		{
			yield return new WaitForSeconds(7f);
			random = Random.Range(0,5);
			if(random == 1)
			{
				randomAudioNoises[Random.Range(0, randomAudioNoises.Length)].Play();
			}
		}
	}


	public void EnemyHitSound()
	{
			var rand = Random.Range(0, enemyHitSound.Length);
		if(enemyHitSound[rand].isPlaying)
		{
			enemyHitSound[rand].Stop();
			enemyHitSound[rand].Play();
		}
		else
		{
			enemyHitSound[rand].Play();
		}
	}


	public void DestructibleExplosionSound(int type)
	{
		switch(type)
		{
			case 1:
				foreach(AudioSource a in destructibleWoodSound)
				{
					if(!a.isPlaying)
					{
						a.Play();
						break;
					}
					else
					{
						a.Stop();
						a.Play();
						break;
					}
				}
			break;

			case 2:
				foreach(AudioSource a in destructibleStoneSound)
				{
					if(!a.isPlaying)
					{
						a.Play();
						break;
					}
					else
					{
						a.Stop();
						a.Play();
						break;
					}
				}
			break;
		}
	}
	public void EnemyDeathSound()
	{

	}

	public void SwordHitProp()
	{
		var rand = Random.Range(0, swordHitProp.Length);
		if(swordHitProp[rand].isPlaying)
		{
			swordHitProp[rand].Stop();
			swordHitProp[rand].Play();
		}
		else
		{
			swordHitProp[rand].Play();
		}
		// foreach(AudioSource a in swordHitProp)
		// {
		// 	if(!a.isPlaying)
		// 	{
		// 		a.Play();
		// 		break;
		// 	}
		// }
	}



}
