using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debuff : MonoBehaviour {

    Collider mcWeaponCol;
    [SerializeField] Animator _anim;
    [SerializeField] characterController _charController;
    [SerializeField] characterAttack _charAttack;
    [SerializeField] mainCharacterStats _charStats;

    //interrupt
    public bool isInterrupt;
    [SerializeField] float endInterruptTime;
    public float currentInterruptTime;

    void Awake()
    {
        mcWeaponCol = GameObject.FindGameObjectWithTag("mainCharacterWeapon").GetComponent<Collider>();
    }

    void Update()
    {
        Interrupt();
    }

    void Interrupt()
    {
        if (currentInterruptTime>0)
        {
            _charController.enabled = false;
            _charAttack.enabled = false;
            currentInterruptTime -= Time.deltaTime;
            _anim.SetBool("interrupt", true);
            mcWeaponCol.enabled = false;


            if (currentInterruptTime <= 0 && currentInterruptTime > -1)
            {
                currentInterruptTime = -2f;   //amount of interrupted time
                _charController.enabled = true;
                _charAttack.enabled = true;
                _anim.SetBool("interrupt", false);
                _charAttack.currentAttackTime = 3f; //something way higher than what it can be
            }
        }
    }


    public float DamageReceived(float enemyDamage)
    {
        return enemyDamage;
    }






}
