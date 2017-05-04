using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
public class firstStartGameBahaviour : MonoBehaviour {

	
	[SerializeField] SpriteRenderer drawing;
	GameObject _canvas;
	MonoBehaviour[] _player;
	Image[] _img;
	Text[] _text;
	mcCameraFollow _camera;




	void Awake()
	{
		_canvas = GameObject.FindGameObjectWithTag("canvas");
		_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<mcCameraFollow>();
		_player = GameObject.FindGameObjectWithTag("Player").GetComponents<MonoBehaviour>();
	}

	IEnumerator Start()
	{
		_img = _canvas.GetComponentsInChildren<Image>();
		_text = _canvas.GetComponentsInChildren<Text>();
		foreach(Image i in _img)
			i.enabled = false;

		foreach(Text t in _text)
			t.enabled = false;

		yield return new WaitForSeconds(2);

		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<VignetteAndChromaticAberration>().enabled = true;
		_camera.IsBiginning=false;

		yield return new WaitForSeconds(1);

		foreach(Image i in _img)
			i.enabled = true;

		foreach(Text t in _text)
			t.enabled = true;

		foreach(MonoBehaviour m in _player)
			m.enabled = true;
	}
	void Update()
	{
		drawing.color -=new Color(0,0,0,Time.deltaTime*0.7f);

	}





}
