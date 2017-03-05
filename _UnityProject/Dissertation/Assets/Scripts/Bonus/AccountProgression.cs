using UnityEngine;
using UnityEngine.UI;

public class AccountProgression : MonoBehaviour {

	Endowments _end;
	float totalAccountExperience = 20f;
	float currentAccountExperience = 0f;
	float storedKnowledge;
	float knowledgeToExperiecenTransferSpeed;
	[SerializeField] Image xpBarFill;
	[SerializeField] Text currentLevelText;
	[SerializeField] Text nextLevelText;


	public static int accountLevel;
	
	void Awake()
	{
		GetProgress();
		_end = GetComponent<Endowments>();
	}

	void Start()
	{
		storedKnowledge = mcStats.knowledge;
		knowledgeToExperiecenTransferSpeed = storedKnowledge ;
	}

	void Update()
	{
		Display();
		LevelUp();
		GainExperience();
	}

	void Display()
	{
		xpBarFill.transform.localScale = new Vector3(currentAccountExperience/totalAccountExperience, 1,1);
		currentLevelText.text = accountLevel.ToString("N0");
	
		if(accountLevel >=3)
			nextLevelText.text = (accountLevel+1).ToString("N0");
	}

	void LevelUp()
	{
		if(currentAccountExperience >=totalAccountExperience)
		{
			_end.ActivateBonuses();
			accountLevel ++;
			currentAccountExperience = 0f;
			totalAccountExperience = totalAccountExperience + (3.5f* accountLevel);
		}
	}

	void GainExperience()
	{
		if(storedKnowledge >0f)
		{
			currentAccountExperience += Time.fixedDeltaTime * knowledgeToExperiecenTransferSpeed;
			storedKnowledge -= Time.fixedDeltaTime * knowledgeToExperiecenTransferSpeed;
		}
		else if(storedKnowledge <= 0f)
		{
			storedKnowledge = 0f;
			SetProgress();
		}
	}

	void SetProgress()
	{
		PlayerPrefs.SetFloat("accountExperience", currentAccountExperience);
		PlayerPrefs.SetInt("accountLevel", accountLevel);
	}

	void GetProgress()
	{
		accountLevel = PlayerPrefs.GetInt("accountLevel");
		totalAccountExperience = totalAccountExperience + (totalAccountExperience* accountLevel);
		currentAccountExperience = PlayerPrefs.GetFloat("accountExperience");
	}











}
