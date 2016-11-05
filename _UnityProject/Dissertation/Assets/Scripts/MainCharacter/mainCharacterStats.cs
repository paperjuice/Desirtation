using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacterStats : MonoBehaviour {


    float mcMaxHealth=100f;
    public float mcCurrentHealth;

    float mcMaxEnergy=100f;
    public float mcCurrentEnrgy;




    void Start()
    {
        mcCurrentEnrgy = mcMaxEnergy;
        mcCurrentHealth = mcMaxHealth;
    }

    void Update()
    {
        Death();
    }

    void Death()
    {
        if (mcCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }



}
