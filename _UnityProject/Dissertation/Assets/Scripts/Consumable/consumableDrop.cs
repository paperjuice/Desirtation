using System.Collections.Generic;
using UnityEngine;

public class consumableDrop : MonoBehaviour {


    // consumablePotency _cp;
    float dropChance;
    [SerializeField] float chanceToGetAConsumable;
    float dropQuality;
    [Header("Check If boss")]
    [SerializeField]bool isBoss;
    
	private static List<GameObject> listOfLevelThreeConsumables;
	int randomItem;




    [Header("Item List")]
    [SerializeField] private GameObject[] levelOneConsumable;
    [SerializeField] private GameObject[] levelTwoConsumable;
    [SerializeField] private List<GameObject> levelThreeConsumable;




    // void Awake()
    // {
    //     _cp = GameObject.FindGameObjectWithTag("Player").GetComponent<consumablePotency>();
    // }

    void Start()
	{
		if(listOfLevelThreeConsumables == null)
			listOfLevelThreeConsumables = levelThreeConsumable;
	}


    public void ItemDrop()
    {
        if (!isBoss)
        {
            dropChance = Random.Range(1f, 100f);

            if (dropChance <= chanceToGetAConsumable)
            {
                dropQuality = Random.Range(1f, 100f);

                if (dropQuality <= 70f)
                    Instantiate(levelOneConsumable[Random.Range(0, levelOneConsumable.Length)], transform.position, transform.rotation);
                else if (dropQuality > 70 && dropQuality <= 95)
                    Instantiate(levelTwoConsumable[Random.Range(0, levelTwoConsumable.Length)], transform.position, transform.rotation);
            }
        }else if(isBoss && controller.dungeonLevel != 10)
        {
            BossDrop();
        }
    }
        

    public void BossDrop()
	{
		randomItem = Random.Range(0, listOfLevelThreeConsumables.Count);
		Instantiate(listOfLevelThreeConsumables[randomItem], transform.position, listOfLevelThreeConsumables[randomItem].transform.rotation);
		listOfLevelThreeConsumables.Remove(listOfLevelThreeConsumables[randomItem]);
	}


}
