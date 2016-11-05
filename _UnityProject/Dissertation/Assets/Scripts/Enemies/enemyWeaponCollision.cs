using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWeaponCollision : MonoBehaviour {

    [SerializeField] GameObject enemyMesh;
    private GameObject player;
    private debuff _debuff;
    private mainCharacterStats _mcStats;
    private Animator _camera;



    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _debuff = GameObject.FindGameObjectWithTag("Player").GetComponent<debuff>();
        _mcStats = GameObject.FindGameObjectWithTag("Player").GetComponent<mainCharacterStats>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            if (!player.GetComponent<characterController>().isRolling)
            {
                _camera.SetTrigger("shake");

                //damage
                _mcStats.mcCurrentHealth -= _debuff.DamageReceived(10f);
                //interrupt
                _debuff.currentInterruptTime = 1f;
                player.GetComponent<Rigidbody>().AddForce((player.transform.position- enemyMesh.transform.position) * 10200f);
            }
        }
    }
}
