using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableObjects : MonoBehaviour {

	
    [SerializeField] private GameObject[] parts;
    private Animator _camera;


    void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mcWeapon")
        {
            foreach (GameObject a in parts)
            {
                _camera.SetTrigger("shake");
                a.GetComponent<Rigidbody>().isKinematic = false;
                a.GetComponent<Rigidbody>().AddForce((transform.position - other.gameObject.transform.position) * Random.Range(800f,1000f)+ new Vector3(0f,520f,0f));
                GetComponent<Collider>().enabled = false;
                this.enabled = false;
            }
        }

        
    }





}
