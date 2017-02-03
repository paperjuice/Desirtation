using UnityEngine;

public class bilboard : MonoBehaviour {

    private GameObject _camera;
    [SerializeField] float x;

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
    	//transform.rotation = Quaternion.Euler(transform.rotation.x, 0,0);
    	transform.rotation = Quaternion.Euler(-45, 180f, 0);
       // transform.LookAt(_camera.transform.position);
        //transform.rotation = Quaternion.LookRotation((_camera.transform.position-transform.position), Vector3.up);
    }
}
