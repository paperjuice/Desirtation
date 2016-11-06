using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcSwordCollision : buff {


    private Animator _cameraAnimator;
    private debuff _debuff;


    void Awake()
    {
        _cameraAnimator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        _debuff = GameObject.FindGameObjectWithTag("Player").GetComponent<debuff>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemy")
        {
            _cameraAnimator.SetTrigger("shake");
            col.GetComponent<generalEnemyStats>().eCurrentHealth -= Damage(5f);
            print("hit");
        }

        if (col.gameObject.tag == "prop")
        {
            _debuff.currentInterruptTime = 1f;
        }
    }

}
