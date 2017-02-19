using UnityEngine;

public class ActivateBossCameraMode : MonoBehaviour {

	GameObject player;
	mcCameraFollow _camera;


	void Awake(){
		player = GameObject.FindGameObjectWithTag("Player");
		_camera = GameObject.FindGameObjectWithTag("cameraFather").GetComponent<mcCameraFollow>();
		//yhjuf
	}

	void Update()
	{
		if(Vector3.Distance(player.transform.position, transform.position) <12)
			_camera.IsBossMode = true;
		else if(Vector3.Distance(player.transform.position, transform.position) >=12&& Vector3.Distance(player.transform.position, transform.position) <25f)
			_camera.IsBossMode = false;
	}


}
