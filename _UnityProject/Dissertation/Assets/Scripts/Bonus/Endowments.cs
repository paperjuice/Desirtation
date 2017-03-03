using UnityEngine;
using UnityEngine.UI;

public class Endowments : MonoBehaviour {

	[SerializeField] Text bonusesText;
	int accountLvl;
	static private bool isActive;   //checks if the game was run at least once in order to display text

	public static float bonusWisdom;
	public static float bonusYouthfulness;
	public static float bonusFortitude;
	public static float bonusSpiritRegen;
	public static float bonusSpirit;
	public static float bonusCritChance;
	public static float bonusAttackSpeed;
	public static float bonusArmour;
	public static float bonusRawDamage;


	void Start()
	{
		ActivateBonuses();
	}

	public void ActivateBonuses()
	{
		accountLvl = AccountProgression.accountLevel;

		if(PlayerPrefs.GetInt("accountLevel") != accountLvl || !isActive)
		{
			for(int i = 0;i<accountLvl;i++)
				BonusesBasedOnLevel(i);

			bonusesText.text = string.Empty;
			isActive = true;
			
		}
		DisplayBonuses();
		
	}

	void BonusesBasedOnLevel(int i)
	{
		switch(i+1)
		{
			case 3:
				bonusRawDamage += 0.5f;
				break;
			case 4:
				bonusWisdom += 50f;
				break;
			case 5:
				bonusAttackSpeed += 0.05f;
				break;
			case 6:
				bonusFortitude += 50f;
				break;
			case 7:
				bonusRawDamage += 0.5f;
				break;
			case 8:
				bonusArmour += 1f;
				break;
			case 9:
				bonusSpirit += 2f;
				break;
			case 11:
				bonusSpiritRegen += 0.1f;
				break;
			case 12:
				bonusCritChance += 5f;
				break;
			case 13:
				bonusYouthfulness += 50f;
				break;
			case 14:
				bonusAttackSpeed += 0.05f;
				break;
			case 15:
				bonusWisdom += 50f;
				break;
			case 16:
				bonusArmour += 1f;
				break;
			case 17:
				bonusFortitude += 50f;
				break;
		}
	}

	void DisplayBonuses()
	{
		if(bonusRawDamage != 0)
			bonusesText.text +="*Raw Damage: +" + bonusRawDamage.ToString("N1") + "\n";

		if(bonusCritChance !=0)
			bonusesText.text += "*Critical hit chance: +" +bonusCritChance.ToString("N1") +"%" + "\n";

		if(bonusWisdom != 0)
			bonusesText.text += "*Wisdom: +" + bonusWisdom.ToString("N1") + "\n";

		if(bonusAttackSpeed != 0)
			bonusesText.text += "*Attack speed: +" + (bonusAttackSpeed*100f).ToString("N1") + "%\n";

		if(bonusFortitude != 0)
			bonusesText.text += "*Fortitude: +" + bonusFortitude.ToString("N1") + "\n";

		if(bonusYouthfulness != 0)
			bonusesText.text += "*Youthfulness: +" + bonusYouthfulness.ToString("N1") + "\n";

		if(bonusArmour != 0)
			bonusesText.text += "*Raw damage reduction: +" + bonusArmour.ToString("N1") + "\n";

		if(bonusSpirit != 0)
			bonusesText.text += "*Spirit: +" + bonusSpirit.ToString("N1") + "\n";

		if(bonusSpiritRegen != 0)
			bonusesText.text += "*Spirit Regeneration: +" + bonusSpiritRegen.ToString("N1") + "\n";
	}
}
