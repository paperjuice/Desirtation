using UnityEngine;

public class PromiseOfLife : MonoBehaviour {

	
	// Vector3 initialPosOfTheWingsParticles;
	[SerializeField] mcStats _ms;
	[SerializeField] consumablePotency _cp;
	[SerializeField] GameObject wingsMesh;
	[SerializeField] ParticleSystem wingsDisolve;


	// void Start()
	// {
	// 	initialPosOfTheWingsParticles = transform.position;
	// }

	void Update()
	{
		if(_cp.PromiseOfLifeLevel!=0)
		{
			wingsMesh.gameObject.SetActive(true);
			if(_ms.Age>=62)
			{
				_ms.Age = 0;
				wingsDisolve.Play();
				_cp.PromiseOfLifeLevel = 0;
			}
		}
		else
		{
			wingsMesh.gameObject.SetActive(false);
		}
	}
}
