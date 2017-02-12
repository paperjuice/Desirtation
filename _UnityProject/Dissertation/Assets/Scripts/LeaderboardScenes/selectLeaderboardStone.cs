using UnityEngine;

public class selectLeaderboardStone : MonoBehaviour {

	[SerializeField] GameObject glow;
	GameObject _camera;
	bool isMoving;
	Vector3 startingCameraPos;
	Quaternion startingCameraRot;
	Vector3 targetCameraPos = new Vector3(2.93f,5.68f,-1.52f);

	void Awake()
	{
		_camera = GameObject.FindGameObjectWithTag("MainCamera");
	}

	void Start()
	{
		startingCameraPos = _camera.transform.position;
		startingCameraRot =  _camera.transform.rotation;
	}

	void OnMouseUpAsButton()
	{
		if(isMoving)
			isMoving = false;
		else
			isMoving = true;
	}

	void OnMouseEnter()
	{
		glow.gameObject.SetActive(true);
	}
	
	void OnMouseExit()
	{
		glow.gameObject.SetActive(false);
	}


	void Update()
	{
		if(Input.GetKeyUp(KeyCode.Escape))
			isMoving = false;

		if(isMoving)
		{
			_camera.transform.position = Vector3.Lerp(_camera.transform.position, targetCameraPos, Time.deltaTime * 5f);
			_camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, Quaternion.Euler(0f,0f,0f), Time.deltaTime*10f);
		}
		else{
			_camera.transform.position = Vector3.Lerp(_camera.transform.position, startingCameraPos, Time.deltaTime * 5f);
			_camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, startingCameraRot, Time.deltaTime*10f);
		}
	}
}
