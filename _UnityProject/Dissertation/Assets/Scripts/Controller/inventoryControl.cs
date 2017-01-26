using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inventoryControl : MonoBehaviour {

    [SerializeField] GameObject[] listOfSlots;
    GameObject[] consumables;
    GameObject player;
    bool isPicked;

    [HeaderAttribute("Consumables")]
    [SerializeField] GameObject c_LowerAge;
    
    
    //the id of the consumable
    int id; 


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator Start()
    {
        while(true)
        {
            consumables = GameObject.FindGameObjectsWithTag("consumable");
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Update()
    {
        Pick();
    }
    void Pick()
    {
        foreach(GameObject consumable in consumables)
        {
            if(Vector3.Distance(consumable.transform.position, player.transform.position) < 2 && Input.GetKeyDown(KeyCode.E))
            {
                id = consumable.GetComponent<consumableCollect>().Id;
                isPicked = true;
                PopulateInventory(consumable);
            }
        }
    }


    void PopulateInventory(GameObject consumable)
    {
        foreach(GameObject slot in listOfSlots)  
        {
            if(slot.transform.childCount ==0 && isPicked)
            {
                InstantiateConsumableBasedOnId(id, slot);
                consumable.gameObject.SetActive(false);
                isPicked = false;
            }
        }

    }

    void InstantiateConsumableBasedOnId(int id, GameObject slot)
    {
        switch(id)
        {
            case 10:
                GameObject temp = Instantiate(c_LowerAge, transform.position, transform.rotation);
                temp.transform.SetParent(slot.transform);
                temp.transform.localPosition = new Vector3(0f,2f,0f);
                temp.transform.localScale = new Vector3(1f,1f,1f);
                temp.GetComponent<canvasConsumable>().Id = id;
            break;

        }
    }



}
