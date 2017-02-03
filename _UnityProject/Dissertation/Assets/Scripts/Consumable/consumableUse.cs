using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumableUse : MonoBehaviour {

    [SerializeField] GameObject parent;
	[SerializeField] int id;

    consumablePotency player;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<consumablePotency>();        
    }
    void OnMouseUpAsButton()
    {
       player.IncrementPassivePotency(id);
       Destroy(parent.gameObject);
    }
}
