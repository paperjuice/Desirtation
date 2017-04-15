using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prologueBehaviour : MonoBehaviour {


	[SerializeField] fadeOutFadein fadeOutImg;
	[SerializeField] Animator _elder;
	[SerializeField] float timeUnilStartingCamera;
	[SerializeField] float timeUntilElderMoves;
	GameObject _camera;
	int checkpoint=0;
	Vector3 targetPos;
	Quaternion targetRot;
	float cameraSpeed;
	[SerializeField]FadeOutSound fadeSound;

	void Awake()
	{
		_camera = GameObject.FindGameObjectWithTag("MainCamera");
	}

	IEnumerator Start()
	{

		cameraSpeed = 0f;
		yield return new WaitForSeconds(timeUnilStartingCamera);
		fadeOutImg.enabled=true;

		cameraSpeed = 0.4f;
		yield return new WaitForSeconds(timeUntilElderMoves);

		_elder.SetTrigger("show");

		yield return new WaitForSeconds(1.5f);
		checkpoint = 1;
		cameraSpeed = 1.5f;
		
		yield return new WaitForSeconds(4.5f);
		fadeSound.IsFading = true;
		SceneManager.LoadScene("tutorial");
	}

	void Update()
	{
		Course();
		_camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPos, Time.deltaTime *cameraSpeed);
		_camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, targetRot, Time.deltaTime * 1f);
	}

	void Course()
	{
		switch(checkpoint)
		{
			case 0:
				targetPos = new Vector3(3.5f,7.5f, -7.3f);
				break;
			case 1:
				targetPos = new Vector3(2.949f, 3.005f, 1.707f);
				targetRot = Quaternion.Euler(0f,0f,0f);
				break;
		}

	}
}
