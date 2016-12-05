using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAnimationMethods : MonoBehaviour {

	
    [SerializeField] bossMeleeAttackBehaviour _bossMeleeAttackBehaviour;
    [SerializeField] Collider mcWeapon;

    public void DecrementNumberOfCombos()
    {
        _bossMeleeAttackBehaviour.numberOfCombos--;
    }

    void AttackMovement(float force)
    {
        _bossMeleeAttackBehaviour.GetComponent<Rigidbody>().AddForce(transform.forward * force * 1000f);
    }

    void ActivateWeaponCollider(int a)
    {
        if (a == 1)
            mcWeapon.enabled = true;
        else if (a == 0)
            mcWeapon.enabled = false;
    }

}
