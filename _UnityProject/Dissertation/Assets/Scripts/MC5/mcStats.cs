﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcStats : MonoBehaviour {

    private debuff mcDebuff;
    private consumablePotency _cp;
    private mcWeaponCollision _mcWeapon;

    [Header("Mc Dead Body ")]
    [SerializeField] GameObject deadBody;

    [Header("Stats text")]
    [SerializeField] TextMesh textKnowledge;
    [SerializeField] TextMesh textYouthfulness;
    [SerializeField] TextMesh textFortitude;
    [SerializeField] TextMesh textWisdom;
    [SerializeField] TextMesh textHealth;
    [SerializeField] TextMesh textSpirit;
    [SerializeField] TextMesh textDamage;
    [SerializeField] TextMesh textArmour;
    [SerializeField] TextMesh textCriticalChance;
    [SerializeField] TextMesh textLuck;


    //knowledge
    // [SerializeField] GameObject textKnowledge;
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

    //armour
    private float damageProcessedBasedOnArmour;


    //critChance
    private float damageIfCrited;
    
    



    void Awake()
    {
        guiHealth = GameObject.FindGameObjectWithTag("healthFill");
        guiSpirit = GameObject.FindGameObjectWithTag("spiritFill");
        mcDebuff = GetComponent<debuff>();
        _cp = GetComponent<consumablePotency>();
        _mcWeapon = GameObject.FindGameObjectWithTag("mcWeapon").GetComponent<mcWeaponCollision>();
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
           // Instantiate(textKnowledge, textKnowledge.transform.position = transform.position + new Vector3(0f, 3f, 0f), transform.rotation);
            

            knowledge += knowledgeGain;
            knowledgeGain = 0f;
        }
    }

    public float Youthfulness()
    {
        youthfulness = (knowledge+1) * (1 + (age / 2.5f) / (1 + age));
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
        wisdom = knowledge * (1+age * 0.03f);
        return wisdom;
    }

    public float Health(float damageReceived)
    {
        if (damageReceived > 0f)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("shake");
            currentHealth -= Armour(damageReceived);
            damageReceived = 0f;
        }

        maxHealth = 50 + Fortitude();
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        
        return currentHealth;
    }

    public void HealHp(float amountHealed)
    {
        if (amountHealed > 0f)
        {
            currentHealth += amountHealed;
            amountHealed = 0f; 
        }
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
        mcDamage = Fortitude() + weaponDamage;;
       // print(mcDamage);
        return mcDamage;
    }

    //keep an eye on wisdom multiplier
    public float Armour(float damageReceived)
    {
        damageProcessedBasedOnArmour = damageReceived - (damageReceived * (_cp.ArmourLevel / (100f+_cp.ArmourLevel))*100f)* Wisdom();
        return damageProcessedBasedOnArmour;
    }

    //keep an eye on wisdom multiplier
    public float CritChance(float damageDealt)
    {
        float chanceToCrit = Random.Range(1f, 100f);
        if (chanceToCrit <= _cp.CritChanceLevel * (Wisdom()/10f))
            damageDealt = damageDealt * Random.Range(1.4f,2f);
        return damageDealt;
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


        textKnowledge.text = "Knowledge: " + knowledge.ToString("N1");
        textYouthfulness.text = "Youthfulness: " + Youthfulness().ToString("N1");
        textFortitude.text = "Fortitude: " + Fortitude().ToString("N1");
        textWisdom.text = "Wisdom: " + Wisdom().ToString("N1");
        textHealth.text = "Health: " + Health(0).ToString("N1") + "/" + maxHealth.ToString("N1");
        textSpirit.text = "Spirit: " + Spirit(0).ToString("N1") + "/" + maxSpirit.ToString("N1");
        textDamage.text = "Damage: " + McDamage(_mcWeapon.DamageWeapon).ToString("N1");
        textArmour.text = "Damage Reduction: " + ((_cp.ArmourLevel / (100f + _cp.ArmourLevel)) * 100f*Wisdom()).ToString("N1");
        textCriticalChance.text = "Critical Chance: " + CritChance(0).ToString("N1");
        textLuck.text = "Luck: " + Luck();









    }







}
