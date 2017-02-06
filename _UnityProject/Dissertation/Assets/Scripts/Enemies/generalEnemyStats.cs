using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalEnemyStats : MonoBehaviour {

    consumableDrop _consumableDrop;

    [SerializeField] GameObject aliveBody;
    [SerializeField] GameObject[] deadBody;
    [SerializeField] ParticleSystem _bloodPart;
    [SerializeField] GameObject _bloodSplatter;

    [Header("VisualizeHealth")]
    [SerializeField] GameObject fillBar;

    [SerializeField]private float eMaxHealth = 10f;
    public float eCurrentHealth;

    private void Awake()
    {
        _consumableDrop = GetComponent<consumableDrop>();
    }

    void Start()
    {
        eMaxHealth = 1 + (controller.dungeonLevel * 5f);
        eCurrentHealth = eMaxHealth;
    }

    void Update()
    {
        Death();
        VisualizeHealth();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "mcWeapon")
        {
            _bloodPart.Play();
            StartCoroutine(InstantiateBloodSplatter());
        }

        if(col.gameObject.tag == "water")
            eCurrentHealth = 0;
    }

    void VisualizeHealth()
    {
        fillBar.transform.localScale = new Vector3(eCurrentHealth / eMaxHealth, 1f, 1f);
    }

    void Death()
    {
        if (eCurrentHealth <= 0)
        {
            foreach(GameObject a in deadBody)
            {
                a.transform.parent = null;
                a.gameObject.SetActive(true);
                a.transform.rotation = Quaternion.Euler(Random.Range(0f,360f), Random.Range(0f,360f), Random.Range(0f,360f));
                a.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-0.7f,0.7f), 1000f, Random.Range(-0.7f,0.7f)* Time.deltaTime * 8f *10000f));
                Destroy(a.gameObject, 4f);
            }
            GameObject bloodPng;
            float bloodScale = Random.Range(0.09f, 0.3f);
            bloodPng = Instantiate(_bloodSplatter, new Vector3(transform.position.x, transform.position.y+0.05f, transform.position.z), Quaternion.Euler(90f, Random.Range(0f,360f), transform.rotation.z));             
            bloodPng = Instantiate(_bloodSplatter, new Vector3(transform.position.x, transform.position.y+0.05f, transform.position.z), Quaternion.Euler(90f, Random.Range(0f,360f), transform.rotation.z));
            bloodPng.transform.localScale = new Vector3(bloodScale, bloodScale, 0.3f);
            aliveBody.gameObject.SetActive(false);
            _consumableDrop.ItemDrop();
        }
    }

    IEnumerator InstantiateBloodSplatter()
    {
        GameObject bloodPng;
        float bloodScale = Random.Range(0.09f, 0.3f);
        yield return new WaitForSeconds(0.15f);        
        bloodPng = Instantiate(_bloodSplatter, new Vector3(transform.position.x, transform.position.y+0.05f, transform.position.z), Quaternion.Euler(90f, Random.Range(0f,360f), transform.rotation.z));             
        yield return new WaitForSeconds(0.2f);
        bloodPng = Instantiate(_bloodSplatter, new Vector3(transform.position.x, transform.position.y+0.05f, transform.position.z), Quaternion.Euler(90f, Random.Range(0f,360f), transform.rotation.z));
        bloodPng.transform.localScale = new Vector3(bloodScale, bloodScale, 0.3f);
    }


}
