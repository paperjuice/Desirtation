using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumableDrop : MonoBehaviour {


    mcStats _mcStats;
    float dropChance;
    float dropQuality;
    [Header("Check If boss")]
    [SerializeField]bool isBoss;

    [Header("Item List")]
    [SerializeField] private GameObject[] levelOneConsumable;
    [SerializeField] private GameObject[] levelTwoConsumable;
    [SerializeField] private GameObject[] levelThreeConsumable;




    void Awake()
    {
        _mcStats = GameObject.FindGameObjectWithTag("Player").GetComponent<mcStats>();
    }



    public void ItemDrop()
    {
        if (!isBoss)
        {
            dropChance = Random.Range(1f, 100f);

            if (dropChance <= _mcStats.Luck())
            {
                dropQuality = Random.Range(1f, 100f);

                if (dropQuality <= 70f)
                    Instantiate(levelOneConsumable[Random.Range(0, levelOneConsumable.Length)], transform.position, transform.rotation);
                else if (dropQuality > 70 && dropQuality <= 95)
                    Instantiate(levelTwoConsumable[Random.Range(0, levelTwoConsumable.Length)], transform.position, transform.rotation);
                else if (dropQuality > 95 && dropQuality <= 100)
                    Instantiate(levelThreeConsumable[Random.Range(0, levelThreeConsumable.Length)], transform.position, transform.rotation);
            }
        }
        if(isBoss)
            Instantiate(levelThreeConsumable[Random.Range(0, levelThreeConsumable.Length)], transform.position, transform.rotation);

    }





}
