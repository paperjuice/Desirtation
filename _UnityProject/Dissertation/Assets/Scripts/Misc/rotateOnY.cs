using UnityEngine;

public class rotateOnY : MonoBehaviour {

	[SerializeField] float rotationSpeed = 50f;


	void Update()
	{
		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
	}
}
