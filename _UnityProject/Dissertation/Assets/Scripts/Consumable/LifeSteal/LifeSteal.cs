using UnityEngine;

public class LifeSteal : MonoBehaviour {

	consumablePotency _cp;
	mcStats _mcStats;
	float chanceToStealLife;
	[SerializeField] GameObject mc_lifeStealMesh;

	[SerializeField] ParticleSystem particle;


	void Awake()
	{
		_cp = GameObject.FindGameObjectWithTag("Player").GetComponent<consumablePotency>();
		_mcStats = GameObject.FindGameObjectWithTag("Player").GetComponent<mcStats>();
	}
	

	void Update()
	{
		if(_cp.LifestealLevel>0)
			mc_lifeStealMesh.gameObject.SetActive(true);
		else
			mc_lifeStealMesh.gameObject.SetActive(false);
	}
	void OnTriggerEnter(Collider col)
	{
		if(_cp.LifestealLevel>0)
		{
			if(col.gameObject.tag=="enemy")
			{
				StealLife();
			}
		}
	}

	void StealLife()
	{
		chanceToStealLife = Random.Range(0f, 100f);
		if(chanceToStealLife<= _mcStats.Age/5f)
		{
			_mcStats.Age-= 1 + _mcStats.Wisdom()*0.08f;
			particle.Play();
		}
	}
}
