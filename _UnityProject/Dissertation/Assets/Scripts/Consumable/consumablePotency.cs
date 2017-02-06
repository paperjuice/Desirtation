using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumablePotency : MonoBehaviour {


    private consumableEffect _ce;
    private mcStats _mcStats;



    //armour Level
    private float armourLevel = 0f;

    //critChance Level
    private float critChanceLevel = 0f;




    private void Awake()
    {
        _ce = GetComponent<consumableEffect>();
        _mcStats = GetComponent<mcStats>();
    }

    public void IncrementPassivePotency(int id)
    {
        switch (id)
        {
            case 8:
                ArmourLevel++;
                break;

            case 9:
                CritChanceLevel += 1;
                break;

            case 10:
                LowerAge(1+_mcStats.Wisdom()*0.3f);
                break;

            case 13:
                PayHpForKnowledge(1);
                break;

            case 6:
                _mcStats.BonusWisdom++;
                break;
            
            case 5:
                _mcStats.BonusFortitude ++;
                break;

            case 4:
                _mcStats.BonusYouthfulness++;
                break;

            case 15:
                _ce.AttackSpeed+= 1/100f;
                break;

            case 16:
                _ce.AOE_DeadDmgPerSecondLevel ++;
                break;
        }

        id=0;
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


    private void LowerAge(float lowerAgeAmount)
    {
        _ce.LowerAge(lowerAgeAmount);
    }
    

    private void PayHpForKnowledge(float amount)
    {
        _ce.PayHpForKnowledge(amount);
    }

    

}
