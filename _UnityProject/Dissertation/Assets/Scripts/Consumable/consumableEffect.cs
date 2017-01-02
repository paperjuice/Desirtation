using UnityEngine;

public class consumableEffect : MonoBehaviour {

	private mcStats _mcStats;
	
	//AttackSpeed
	private float attackSpeed;

	//Health Regen
	private float healthRegen;

	[Header("AOE_DeadDmgPerSecond")]
	[SerializeField] GameObject aoe_particle;
	private int aoe_DeadDmgPerSecondLevel;
	public int AOE_DeadDmgPerSecondLevel
	{
		get{return aoe_DeadDmgPerSecondLevel;}
		set{aoe_DeadDmgPerSecondLevel=value;}
	}


	void Awake()
	{
		_mcStats = GetComponent<mcStats>();
	}


	public void HealHp(float amountHealed)
    {
        if (amountHealed > 0f)
        {
            _mcStats.CurrentHealth += amountHealed;
            amountHealed = 0f; 
        }
    }


	public void LowerAge(float lowerAgeAmount)
	{
		if(lowerAgeAmount >0)
		{
			if(mcStats.age - lowerAgeAmount<0)
				mcStats.age =0;
			else
				mcStats.age -= lowerAgeAmount;

			lowerAgeAmount = 0f;
		}
	}

	public void PayHpForKnowledge(float amountGained)
	{
		if(amountGained>0)
		{
			_mcStats.CurrentHealth -= amountGained;
			mcStats.knowledge += amountGained*10f* _mcStats.Wisdom();
			amountGained = 0f;
		}
	}

	public float AttackSpeed
	{
		get{return attackSpeed;}
		set{attackSpeed = value * _mcStats.Wisdom();}
	}

	//tre sa vad unde bag wisdom scale-ul
	public float HealthRegen
	{
		get{return healthRegen;}
		set{healthRegen=value/100;}
	}



	public float AOE_DeadDmgPerSecond()
	{
		float aoeDmg;
		if(AOE_DeadDmgPerSecondLevel>0)
		{
			aoe_particle.gameObject.SetActive(true);
		}

		aoeDmg = AOE_DeadDmgPerSecondLevel * _mcStats.Wisdom()/100f;
		return aoeDmg;
	}

}
