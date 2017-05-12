using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndreiCameraControl : MonoBehaviour {

	

	bool isBehaviourActive = false;



	void Update()
	{
		CameraBehaviour();
	}

	void CameraBehaviour()
	{
		float mouse_x = Input.GetAxis("Mouse X");
		float mouse_y = Input.GetAxis("Mouse Y") ;

		Quaternion target = Quaternion.Euler(-mouse_x,mouse_y,0) * transform.rotation;

		transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 2);


	}



}
