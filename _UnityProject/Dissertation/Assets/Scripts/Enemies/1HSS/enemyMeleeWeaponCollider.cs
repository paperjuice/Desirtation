using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMeleeWeaponCollider : MonoBehaviour {

    debuff mcDebuffs;
    mcMovementBehaviour mcMovement;
    [SerializeField] GameObject enemyPosition;
    [SerializeField] float eDamage;
    [SerializeField] float interruptTime;
    [SerializeField] float pushBackForce;

    //enemy amount of damage it deals
    private float enemyDamage=0f;

    
    void Awake()
    {
        mcDebuffs = GameObject.FindGameObjectWithTag("Player").GetComponent<debuff>();
        mcMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<mcMovementBehaviour>();
    }


    void Start()
    {
        enemyDamage = eDamage + controller.dungeonLevel * 2f;
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!mcMovement.isInvincible) //put it outside "if(col.gameObject==player)"
            {
                mcStats.age += enemyDamage;

                mcDebuffs.PlayerDamaged(enemyDamage); //Damage dealt
                mcDebuffs.secondsInterrupted = interruptTime; //Interrupt - this will be iterated based on enemy type
                mcDebuffs.PushBack(enemyPosition.transform.position, mcDebuffs.transform.position, pushBackForce); //PushBack - iterate force
                mcDebuffs.ChanceToDieOnHit();
            }
        }
    }



}
