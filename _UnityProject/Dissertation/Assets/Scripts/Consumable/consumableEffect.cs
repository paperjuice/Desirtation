using UnityEngine;

public class consumableEffect : MonoBehaviour {

	private mcStats _mcStats;
	private consumablePotency _cp;
	
	//AttackSpeed
	private float attackSpeed;

	//Health Regen
	private float healthRegen;

	[Header("AOE_DeadDmgPerSecond")]
	[SerializeField] GameObject aoe_particle;


	void Awake()
	{
		_mcStats = GetComponent<mcStats>();
		_cp = GetComponent<consumablePotency>();
	}

	void Update()
	{
		AOE_DeadDmgPerSecond();
	}

	public void LowerAge(float lowerAgeAmount)
	{
		lowerAgeAmount = Mathf.Clamp(lowerAgeAmount, 7f,35f);
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
		if(_cp.AOE_DeadDmgPerSecondLevel>0)
		{
			aoe_particle.gameObject.SetActive(true);
		}

		aoeDmg = (_cp.AOE_DeadDmgPerSecondLevel*0.5f + _mcStats.Wisdom()*0.07f) * Time.fixedDeltaTime;
		return aoeDmg;
	}

}
