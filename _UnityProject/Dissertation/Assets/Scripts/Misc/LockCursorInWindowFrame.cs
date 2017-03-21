using UnityEngine;

public class LockCursorInWindowFrame : MonoBehaviour {

	void Start()
	{
		Cursor.lockState = CursorLockMode.Confined;
	}



}
