using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumableIdentity : MonoBehaviour {

    public bool isActive;


    [SerializeField] private int id;
	[SerializeField] private string description;
    [SerializeField] Color _col;
    GameObject[] consumables;
    TextMesh _text;



    private void Awake()
    {
        _text = GetComponentInChildren<TextMesh>();
    }

    private void OnMouseDown()
    {
        consumables = GameObject.FindGameObjectsWithTag("consumable");
        foreach (GameObject c in consumables)
        {
            c.GetComponent<consumableIdentity>().isActive=false;
            c.GetComponentInChildren<TextMesh>().color= Color.white;
        }
        isActive = true;

        _text.color = _col;
        GetComponentInParent<inventoryControl>().consumableID = id;
        GetComponentInParent<inventoryControl>().consumableDescription = description;
    }
}
