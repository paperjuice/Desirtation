using UnityEngine;

public class B3StunBehaviour : MonoBehaviour {

	
	[SerializeField] SpriteRenderer circle; 
	[SerializeField] ParticleSystem particle; 
	bool isActive;
	debuff _debuff;


	void Awake()
	{
		_debuff = GameObject.FindGameObjectWithTag("Player").GetComponent<debuff>();
		Destroy(gameObject, 20f);
	}

	void Update()
	{
		if(circle.color.a<1)
		{
			circle.color += new Color(0,0,0,1) * Time.deltaTime;
		}
		else if(circle.color.a>=1)
		{
			particle.gameObject.SetActive(true);
			isActive = true;
		}
	}

	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.tag == "Player" && isActive)
		{
			_debuff.SecondsInterrupted = 3f;
			Destroy(gameObject);
		}
	}



}
