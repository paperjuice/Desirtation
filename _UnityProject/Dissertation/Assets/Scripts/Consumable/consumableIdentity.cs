using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumableIdentity : MonoBehaviour {

    public bool isActive;


    [SerializeField] private int id;
    [SerializeField] private int proficiency;
    GameObject[] consumables;
    TextMesh _text;



    private void Awake()
    {
        _text = GetComponentInChildren<TextMesh>();
    }

    private void OnMouseDown()
    {
     //   GetComponentInParent<inventoryControl>().consumableID = id;
       // GetComponentInParent<inventoryControl>().consumableProficiency = proficiency;
    }
}
