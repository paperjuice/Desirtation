using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalEnemyStats : MonoBehaviour {


    private float eMaxHealth = 100f;
    public float eCurrentHealth;

    void Start()
    {
        eCurrentHealth = eMaxHealth;
    }

    void Update()
    {
        Death();
    }

    void Death()
    {
        if (eCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }



}
