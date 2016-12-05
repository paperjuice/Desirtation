using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMeleeAnimationMethods : MonoBehaviour {

    [SerializeField] private enemyMeleeBehaviour _enemyMeleeBehaviour;
    [SerializeField] Collider eWeapon;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void AttackBehaviour()
    {
        //combo of 1, 2, 3 an so on attacks
        if (_enemyMeleeBehaviour.attackBehaviour != 0)
        {
            _enemyMeleeBehaviour.attackBehaviour--;
        }

        if (_enemyMeleeBehaviour.attackBehaviour == 0)
            anim.SetBool("attack", false);
    }

    //the force that pushes the enemy forward when attacking
    void AttackMovement(float force)
    {
        _enemyMeleeBehaviour.GetComponent<Rigidbody>().AddForce(transform.forward * force*1000f);
    }

    void ActivateWeaponCollider(int a)
    {
        if (a == 1)
            eWeapon.enabled = true;
        else if (a == 0)
            eWeapon.enabled = false;
    }
}
