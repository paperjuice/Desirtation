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

    public void IncrementPassivePotency(int id, int proficiency)
    {
        switch (id)
        {
            case 8:

                ArmourLevel+= proficiency;
                break;

            case 9:
                CritChanceLevel += proficiency;
                break;

            case 1:
                HealHp(proficiency);
                break;
                 
            case 10:
                LowerAge(proficiency);
                break;

            case 13:
                PayHpForKnowledge(proficiency);
                break;

            case 6:
                _mcStats.BonusWisdom+=proficiency;
                break;
            
            case 5:
                _mcStats.BonusFortitude += proficiency;
                break;

            case 4:
                _mcStats.BonusYouthfulness+= proficiency;
                break;

            case 15:
                _ce.AttackSpeed+= proficiency/100f;
                break;

            case 14:
                _ce.HealthRegen+= proficiency;
                break;

            case 16:
                _ce.AOE_DeadDmgPerSecondLevel += proficiency;
                break;
        }

        proficiency=0;
        id=0;

    }




    public void HealHp(float amountHeald)
    {
        _ce.HealHp(amountHeald * _mcStats.Wisdom());
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
