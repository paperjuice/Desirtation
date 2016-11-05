using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcSwordCollision : MonoBehaviour {


    private Animator _cameraAnimator;


    void Awake()
    {
        _cameraAnimator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemy")
        {
            _cameraAnimator.SetTrigger("shake");
        }
    }

}
