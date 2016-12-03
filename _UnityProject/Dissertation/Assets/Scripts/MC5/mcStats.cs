using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcStats : MonoBehaviour {

    private debuff mcDebuff;


    [SerializeField] GameObject deadBody;





    public static float age=0;
    public static bool isDead = false;
    public static float statisticsChanceToDieOnHit;

    private float agingPerSecond;
    private float ageSuddenDeath;

    private float knowledge;

    //perception
    private float perception;
    private float currentPerception;

    //fortitude
    private float fortitude;
    private float currentFortitude;

    //wisdom
    private float wisdom;
    private float currentWisdom;

    private float luck;
    private float passivePotency;


    //GUI
    private GameObject ageChanceToDieOnHitPanel;



    void Awake()
    {
        ageChanceToDieOnHitPanel = GameObject.FindGameObjectWithTag("mcAgeFill");
        mcDebuff = GetComponent<debuff>();
    }

    
    void Update()
    {
        Death();
        GUI();
    }


    void Death()
    {
        if (isDead)
        {
            deadBody.transform.parent = null;
            deadBody.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }


    void GUI()
    {
        ageChanceToDieOnHitPanel.transform.localScale = new Vector3(statisticsChanceToDieOnHit / 100f, 1f, 1f);
    }







}
