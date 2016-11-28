using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMeleeWeaponCollider : MonoBehaviour {

    GameObject player;
    [SerializeField] GameObject enemyPosition;

    //enemy amount of damage it deals
    private float enemyDamage = 10f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            if (!player.GetComponent<mcMovementBehaviour>().isInvincible) //put it outside "if(col.gameObject==player)"
            {
                player.GetComponent<debuff>().PlayerDamaged(enemyDamage); //Damage dealt
                player.GetComponent<debuff>().secondsInterrupted = 0.75f; //Interrupt - this will be iterated based on enemy type
                player.GetComponent<debuff>().PushBack(enemyPosition.transform.position, player.transform.position, 50f); //PushBack - iterate force
            }
        }
    }



}
