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


	void Start()
	{
		ActivateBonuses();
	}

	public void ActivateBonuses()
	{
		accountLvl = AccountProgression.accountLevel;

		if(PlayerPrefs.GetInt("accountLevel") != accountLvl || !isActive)
		{
			BonusesBasedOnLevel();
			isActive = true;
		}
		DisplayBonuses();
	}

	void BonusesBasedOnLevel()
	{
		if(accountLvl >= 3)
			bonusCritChance += 0.5f;

		if(accountLvl >=4)
			bonusWisdom += 2f;

		if(accountLvl >=5)
			bonusAttackSpeed += 0.01f;

		if(accountLvl >=6)
			bonusFortitude += 2f;

		if(accountLvl >=7)
			bonusYouthfulness += 2f;

		if(accountLvl >=8)
			bonusArmour += 0.2f;

		if(accountLvl >=9)
			bonusSpirit += 0.5f;

		if(accountLvl >=11)
			bonusSpiritRegen += 0.1f;
	}

	void DisplayBonuses()
	{
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
			bonusesText.text += "*Armour: +" + bonusArmour.ToString("N1") + "\n";

		if(bonusSpirit != 0)
			bonusesText.text += "*Spirit: +" + bonusSpirit.ToString("N1") + "\n";

		if(bonusSpiritRegen != 0)
			bonusesText.text += "*Spirit Regeneration: +" + bonusSpiritRegen.ToString("N1") + "\n";
	}
}
