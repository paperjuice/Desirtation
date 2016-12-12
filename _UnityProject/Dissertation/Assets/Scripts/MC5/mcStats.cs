using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcStats : MonoBehaviour {

    private debuff mcDebuff;


    [SerializeField] GameObject deadBody;

    
    //knowledge
    [SerializeField] GameObject textKnowledge;
    public static float knowledge = 0f;

    //age
    public static float age=0;
    private float agingPerSecond;

    //health
    private GameObject guiHealth; 
    private float currentHealth=50f;
    private float maxHealth;

    //Spirit
    private GameObject guiSpirit;
    private float currentSpirit=20f;
    private float maxSpirit;

    
    //youthfulness
    private float youthfulness;

    //fortitude
    private float fortitude;

    //wisdom
    private float wisdom;

    //luck
    private float luck;

    //damage
    private float mcDamage;

    
    



    void Awake()
    {
        guiHealth = GameObject.FindGameObjectWithTag("healthFill");
        guiSpirit = GameObject.FindGameObjectWithTag("spiritFill");
        mcDebuff = GetComponent<debuff>();
    }

    
    void Update()
    {
        Death();
        GUI();
    }

    public void Knowledge(float knowledgeGain)
    {
        if (knowledgeGain > 0f)
        {
            Instantiate(textKnowledge, textKnowledge.transform.position = transform.position + new Vector3(0f, 3f, 0f), transform.rotation);
            

            knowledge += knowledgeGain;
            knowledgeGain = 0f;
        }
    }

    public float Youthfulness()
    {
        youthfulness = knowledge * (1 + (age / 2.5f) / (1 + age));
        return youthfulness;
    }

    public float Fortitude()
    {
        if (age <= 17)
            fortitude = knowledge * ((age+1) / 17)*0.1f;
        else
            fortitude = knowledge * (17 / age) * 0.1f;
        
        return fortitude;
    }

    public float Wisdom()
    {
        wisdom = knowledge * (age * 0.03f);
        return wisdom;
    }

    public float Health(float damageDealt)
    {
        if (damageDealt > 0f)
        {
            currentHealth -= damageDealt;
            damageDealt = 0f;
        }

        maxHealth = 50 + Fortitude();
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        
        return currentHealth;
    }


    public float Spirit(float decreasAmount)
    {
        if (decreasAmount > 0)
        {
            currentSpirit -= decreasAmount;
            decreasAmount = 0f;
        }

        maxSpirit = 20 + Youthfulness()*0.1f;
        currentSpirit = Mathf.Clamp(currentSpirit, 0f, maxSpirit);

        if (currentSpirit < maxSpirit)
            currentSpirit += Time.deltaTime*1.4f;
        
        return currentSpirit;
    }

    public float Luck()
    {
        luck = (Youthfulness() / Youthfulness() + 10f) * 10f;
        return luck;
    }

    public float McDamage(float weaponDamage)
    {
        mcDamage = Fortitude() + weaponDamage;
        print(mcDamage);
        return mcDamage;
    }

    
    void Death()
    {
        if (Health(0)<=0)
        {
            deadBody.transform.parent = null;
            deadBody.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }


    void GUI()
    {
        guiHealth.transform.localScale = new Vector3(Health(0) / maxHealth, 1f, 1f);
        guiSpirit.transform.localScale = new Vector3(Spirit(0) / maxSpirit, 1f, 1f);
    }







}
