using UnityEngine;
public class consumablePotency : MonoBehaviour {

    private consumableEffect _ce;
    private mcStats _mcStats;


    //armour Level
    private float armourLevel = 0f;

    //critChance Level
    private float critChanceLevel = 0f;

    //spirit regen
    float spiritRegen = 0f;

    // AOE_DeadDmgPerSecondLevel
    float aoe_DeadDmgPerSecondLevel = 0f;

    // lifesteal
    float lifestealLevel;
    public float LifestealLevel{
        get{return lifestealLevel;}
        set{lifestealLevel = value;}
    }

    //Promise of life: when you go above a certain age you are brought back to 18 yeas old.
    float promiseOfLifeLevel = 0;
    public float PromiseOfLifeLevel{
        get{return promiseOfLifeLevel;}
        set{promiseOfLifeLevel = value;}
    }

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
                CritChanceLevel ++;
                break;

            case 10:
                LowerAge(_mcStats.Wisdom()*0.1f);
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
                _ce.AttackSpeed+= 1f;
                break;

            case 16:
                aoe_DeadDmgPerSecondLevel ++;
                break;
                
            case 17:
                spiritRegen += 1f;
                break;

            case 18:
                LifestealLevel++;
                break;

            case 19:
                PromiseOfLifeLevel++;
                break;
        }

        id=0;
    }


    void Update()
    {
//        Debug.Log(CritChanceLevel);
    }

    public float ArmourLevel
    {
        get{ return armourLevel; }
        set{ armourLevel = value; }
    }


    public float CritChanceLevel
    {
        get { return critChanceLevel; }
        set { critChanceLevel = value; }
    }


    private void LowerAge(float lowerAgeAmount)
    {
        _ce.LowerAge(lowerAgeAmount);
    }
    

    private void PayHpForKnowledge(float amount)
    {
        _ce.PayHpForKnowledge(amount);
    }


    public  float SpiritRegen()
    {
        return spiritRegen;
    }

    public float AOE_DeadDmgPerSecondLevel
    {
        get{return aoe_DeadDmgPerSecondLevel;}
        set{aoe_DeadDmgPerSecondLevel = value;}
    }


    

}
