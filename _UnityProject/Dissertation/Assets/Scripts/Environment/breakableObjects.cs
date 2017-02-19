using System.Collections;
using UnityEngine;

public class breakableObjects : MonoBehaviour {

	
    [SerializeField] private GameObject[] parts;
    [SerializeField] float force;
    private Animator _camera;
    private GameObject player;
    bool isExploding;

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
            isExploding = true;

        
    }

    void Update()
    {
        if (isExploding)
        {
            foreach (GameObject p in parts)
            {
                _camera.SetTrigger("shake");
                p.GetComponent<Rigidbody>().isKinematic = false;
                p.GetComponent<BoxCollider>().enabled = true;
                p.GetComponent<Rigidbody>().AddExplosionForce(force * Random.Range(0.6f, 1.1f), player.transform.position, 25f, 2f, ForceMode.Force);
                GetComponent<Collider>().enabled = false;
                p.transform.parent = null;
            }
            isExploding = false;
            gameObject.SetActive(false);
        }
    }

}
