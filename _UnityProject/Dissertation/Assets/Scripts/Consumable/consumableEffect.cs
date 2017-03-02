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

	void Update()
	{
		AOE_DeadDmgPerSecond();
	}

	public void LowerAge(float lowerAgeAmount)
	{
		lowerAgeAmount = Mathf.Clamp(lowerAgeAmount, 0f,30f);
		if(lowerAgeAmount >0)
		{
			if(_mcStats.Age - lowerAgeAmount<0)
				_mcStats.Age =0;
			else
				_mcStats.Age -= lowerAgeAmount;

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
		set{attackSpeed = value;}
	}

	public float AOE_DeadDmgPerSecond()
	{
		float aoeDmg;
		if(AOE_DeadDmgPerSecondLevel>0)
		{
			aoe_particle.gameObject.SetActive(true);
		}

		aoeDmg = (AOE_DeadDmgPerSecondLevel * _mcStats.Wisdom()/(400f+_mcStats.Wisdom()) * Time.fixedDeltaTime);
		return aoeDmg;
	}

}
