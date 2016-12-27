using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalEnemyStats : MonoBehaviour {

    consumableDrop _consumableDrop;

    [SerializeField] GameObject aliveBody;
    [SerializeField] GameObject deadBody;
    [SerializeField] ParticleSystem _bloodPart;

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
        }
    }

    void VisualizeHealth()
    {
        fillBar.transform.localScale = new Vector3(eCurrentHealth / eMaxHealth, 1f, 1f);
    }

    void Death()
    {
        if (eCurrentHealth <= 0)
        {
            deadBody.gameObject.SetActive(true);
            deadBody.transform.parent = null;
            aliveBody.gameObject.SetActive(false);
            _consumableDrop.ItemDrop();
        }
    }



}
