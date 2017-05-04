using UnityEngine;

public class MCWeaponPropHit : MonoBehaviour {

	[SerializeField] ParticleSystem sparkles;
	SoundController soundController;
	Animator _camera;
	debuff _debuff;
	RaycastHit raycast;
	Ray ray;
	float dist = 1f;

	void Awake()
	{
		_debuff = GameObject.FindGameObjectWithTag("Player").GetComponent<debuff>();
		soundController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
	}

	void Update()
	{
		if(_camera == null)
			_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
		if(soundController == null)
			soundController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
	}


	void FixedUpdate()
	{
		ray.origin = transform.position;
		ray.direction = transform.forward;
		if(Physics.Raycast(ray, out raycast, dist))
		{
			if(raycast.collider.tag == "prop")
			{
				_debuff.SecondsInterrupted = 0.5f;
				_camera.SetTrigger("shake");
				sparkles.Play();
				soundController.SwordHitProp();
			}
		}

	}





}
