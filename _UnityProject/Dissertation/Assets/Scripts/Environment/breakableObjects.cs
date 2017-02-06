using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableObjects : MonoBehaviour {

	
    [SerializeField] private GameObject[] parts;
    [SerializeField] float force;
    private Animator _camera;
    private GameObject player;

    void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        StartCoroutine(FindPlayer());
    }

    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mcWeapon")
        {
            foreach(GameObject p in parts)
            {
                _camera.SetTrigger("shake");
                p.GetComponent<Rigidbody>().isKinematic = false;
                p.GetComponent<BoxCollider>().enabled = true;
                p.GetComponent<Rigidbody>().AddForce((transform.position - player.gameObject.transform.position) * force + new Vector3(0f,520f,0f));
                GetComponent<Collider>().enabled = false;
                p.transform.parent = null;
                gameObject.SetActive(false);
            // this.enabled = false;
            }
        }

        
    }





}
