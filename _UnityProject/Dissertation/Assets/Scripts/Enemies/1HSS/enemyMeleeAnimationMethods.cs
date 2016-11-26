using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMeleeAnimationMethods : MonoBehaviour {

    [SerializeField] private enemyMeleeBehaviour _enemyMeleeBehaviour;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void AttackBehaviour()
    {
        if (_enemyMeleeBehaviour.attackBehaviour != 0)
        {
            _enemyMeleeBehaviour.attackBehaviour--;
            print("asda");
        }

        if (_enemyMeleeBehaviour.attackBehaviour == 0)
            anim.SetBool("attack", false);
    }

    void AttackMovement()
    {
        _enemyMeleeBehaviour.GetComponent<Rigidbody>().AddForce(transform.forward * 45000f);
    }
}
