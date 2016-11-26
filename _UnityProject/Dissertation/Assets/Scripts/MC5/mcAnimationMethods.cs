using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcAnimationMethods : MonoBehaviour {

    private Animator anim;
    private Collider mcWeapon;

    [SerializeField] private mcMovementBehaviour _mc;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void StepForward()
    {
        _mc.GetComponent<Rigidbody>().AddForce(transform.forward * 40000f);
    }


    void DecrementAttackQueue()
    {
        if (_mc.attackQueue > 0)
        {
            _mc.attackQueue--;
        }


        if (_mc.attackQueue <= 0)
        {
            anim.SetBool("attack", false);
        }
    }

    void SetInvincibility(int a)
    {
        if (a == 0)
            _mc.isInvincible = false;
        else if (a == 1)
            _mc.isInvincible = true;
    }

    void DisableRolling()
    {
        _mc.isRolling = false;
    }

    void ActivateWeaponCollider(int a)
    {
        mcWeapon = GameObject.FindGameObjectWithTag("mcWeapon").GetComponent<Collider>();

        if (a == 1)
            mcWeapon.enabled = true;
        else if (a == 0)
            mcWeapon.enabled = false;
    }






}
