using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcWeaponCollision : MonoBehaviour {

    private Animator _mainCamera;
    private mcStats _mcStats;


    void Awake()
    {
        _mcStats = GameObject.FindGameObjectWithTag("Player").GetComponent<mcStats>();
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemy")
        {
            _mcStats.Knowledge(1+controller.dungeonLevel);  //this needs iteration
            _mainCamera.SetTrigger("shake");
            col.gameObject.GetComponent<generalEnemyStats>().eCurrentHealth -= _mcStats.McDamage(3);
        }
    }
}
