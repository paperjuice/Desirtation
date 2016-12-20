using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryControl : MonoBehaviour {


    public int consumableID;
    public string consumableDescription;

    [SerializeField] GameObject[] inventorySlots;
    private GameObject _player;
    private GameObject[] _consumables;


    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private IEnumerator Start()
    {
        while (true)
        {
            _consumables = GameObject.FindGameObjectsWithTag("consumable");
            yield return new WaitForSeconds(1f);
        }
    }
    
    private void Update()
    {
        Range();
        ActivatePotion();
    }

    void Range()
    {
        foreach (GameObject c in _consumables)
        {
            if (c != null)
            {
                if (Vector3.Distance(_player.transform.position, c.transform.position) < 3)
                {
                    print("e in range");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        ChooseInventorySlot(c);
                    }
                }
            }
        }
    }

    void ChooseInventorySlot(GameObject consumable)
    {
        foreach (GameObject s in inventorySlots)
        {
            if (s.gameObject.activeInHierarchy && s.transform.childCount == 0)
            {
                consumable.transform.SetParent(s.transform, worldPositionStays: false);
                consumable.transform.localScale = new Vector3(1f, 1f, 1f);
                consumable.transform.localPosition = Vector3.zero;
                consumable.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                consumable.GetComponent<bilboard>().enabled = false;
                consumable.transform.GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
        }
    }

    void ActivatePotion()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (GameObject c in _consumables)
            {
                if (c.GetComponent<consumableIdentity>().isActive)
                {
                    Destroy(c.gameObject);
                }
            }
        }
    }






}
