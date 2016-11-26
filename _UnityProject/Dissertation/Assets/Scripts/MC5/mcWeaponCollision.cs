using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcWeaponCollision : MonoBehaviour {

    private Animator _mainCamera;


    void Awake()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemy")
        {
            _mainCamera.SetTrigger("shake");
        }
    }
}
