using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumablePotency : MonoBehaviour {


    private mcStats _mcStats;



    //armour Level
    private float armourLevel = 0f;

    //critChance Level
    private float critChanceLevel = 0f;




    private void Awake()
    {
        _mcStats = GetComponent<mcStats>();
    }

    public void IncrementPassivePotency(int id, int proficiency)
    {
        switch (id)
        {
            case 8:

                ArmourLevel+= proficiency;
                proficiency = 0;
                id = 0;
                break;

            case 9:
                CritChanceLevel += proficiency;
                proficiency = 0;
                id = 0;
                break;

            case 1:
                HealHp(proficiency);
                proficiency = 0;
                id = 0;
                break;
        }


    }




    public void HealHp(float amountHeald)
    {
        _mcStats.HealHp(amountHeald + _mcStats.Wisdom());

    }


    public float ArmourLevel
    {
        get{ return armourLevel; }
        set{ armourLevel = value; }
    }


    public float CritChanceLevel
    {
        get { return critChanceLevel; }
        set { critChanceLevel = (value/(30f+value))*100f; }
    }


    


}
