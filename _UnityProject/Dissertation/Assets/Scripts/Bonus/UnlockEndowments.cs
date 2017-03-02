using UnityEngine;
using UnityEngine.UI;

public class UnlockEndowments : MonoBehaviour {

	
	[SerializeField] Image[] xpBarSymbols = new Image[3];
	[SerializeField] Image[] symbolsOnLock = new Image[3];

	int accountLVl;

	void Update()
	{
		accountLVl = AccountProgression.accountLevel;	
		Unlock();
	}

	void Unlock()
	{
		//images on the xp bar 
		if(accountLVl == 0)
			xpBarSymbols[0].gameObject.SetActive(true);
		else 
			xpBarSymbols[0].gameObject.SetActive(false);

		if(accountLVl==1)
			xpBarSymbols[1].gameObject.SetActive(true);
		else 
			xpBarSymbols[1].gameObject.SetActive(false);

		if(accountLVl==2)
			xpBarSymbols[2].gameObject.SetActive(true);
		else
			xpBarSymbols[2].gameObject.SetActive(false);

		//images of the locks with the symbols
			
		if(accountLVl==0)
			symbolsOnLock[0].gameObject.SetActive(true);
		else
			symbolsOnLock[0].gameObject.SetActive(false);

		
		if(accountLVl==1)
			symbolsOnLock[1].gameObject.SetActive(true);
		else
			symbolsOnLock[1].gameObject.SetActive(false);

		if(accountLVl==2)
			symbolsOnLock[2].gameObject.SetActive(true);
		else
			symbolsOnLock[2].gameObject.SetActive(false);

		if(accountLVl==3 )
			symbolsOnLock[3].gameObject.SetActive(true);
	}
}
