using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcWeaponCollision : MonoBehaviour {

    private Animator _mainCamera;
    private buff _buff;


    void Awake()
    {
        _buff = GameObject.FindGameObjectWithTag("Player").GetComponent<buff>();
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemy")
        {
            _mainCamera.SetTrigger("shake");
            col.gameObject.GetComponent<generalEnemyStats>().eCurrentHealth -= _buff.Damage(3f);//Damage done to enemy - iterate
        }
    }
}
