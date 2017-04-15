using System.Collections;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class EndSceneController : MonoBehaviour {

	GameObject playerTag;
	[SerializeField] fadeOutFadein _fade;
	[SerializeField] GameObject player;
	[SerializeField] float mc_ms;
	[SerializeField] float timeBrightnessUp;
	[SerializeField] float brightness_ms;
	bool isBrightening;
	GameObject _camera;


	void Awake()
	{
		_camera = GameObject.FindGameObjectWithTag("MainCamera");
		playerTag = GameObject.FindGameObjectWithTag("Player");
		Destroy(playerTag);
	}

	void Update()
	{
		player.transform.position += Time.deltaTime * mc_ms * transform.forward;

		BrightenUpTheScreen();
	}

	IEnumerator Start()
	{
		yield return new WaitForSeconds(timeBrightnessUp);
		isBrightening = true;
		yield return new WaitForSeconds(3);
		_fade.enabled = true;

	}

	void BrightenUpTheScreen()
	{
		if(isBrightening)
		{
			_camera.GetComponent<SunShafts>().sunShaftBlurRadius += Time.deltaTime*brightness_ms;
			_camera.GetComponent<SunShafts>().sunShaftIntensity += Time.deltaTime*brightness_ms * 3f;
		}
	}






}
