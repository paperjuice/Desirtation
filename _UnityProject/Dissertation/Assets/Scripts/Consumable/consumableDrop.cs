using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumableDrop : MonoBehaviour {


    consumablePotency _cp;
    float dropChance;
    [SerializeField] float chanceToGetAConsumable;
    float dropQuality;
    [Header("Check If boss")]
    [SerializeField]bool isBoss;

    [Header("Item List")]
    [SerializeField] private GameObject[] levelOneConsumable;
    [SerializeField] private GameObject[] levelTwoConsumable;
    [SerializeField] private GameObject[] levelThreeConsumable;




    void Awake()
    {
        _cp = GameObject.FindGameObjectWithTag("Player").GetComponent<consumablePotency>();
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
                else if (dropQuality > 95 && dropQuality <= 100)
                    DontDuplicateLevelThreeConsumables();
            }
        }
        if(isBoss)
            DontDuplicateLevelThreeConsumables();
    }

    public void DontDuplicateLevelThreeConsumables()
    {
        //Sort
        //-AOE_DeadDmgPerSecondLevel : 0
        //

        var randomDrop = Random.Range(0,levelThreeConsumable.Length);
        switch(randomDrop)
        {
            case 0:
                if(_cp.AOE_DeadDmgPerSecondLevel<=0)
                    Instantiate(levelThreeConsumable[0], transform.position, transform.rotation);
                break;
            case 1:
                if(_cp.LifestealLevel<=0)
                    Instantiate(levelThreeConsumable[1], transform.position, transform.rotation);
                break;
        }
        
    }





}
