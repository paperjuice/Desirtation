using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour {

	Scene _scene ;

	void Awake()
	{
		_scene = SceneManager.GetActiveScene();
	}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			SceneManager.LoadScene(_scene.name);
	}




}
