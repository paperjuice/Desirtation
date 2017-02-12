using UnityEngine;

public class rotateOnY : MonoBehaviour {

	[SerializeField] float rotationSpeed = 50f;


	void Update()
	{
		transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
	}
}
