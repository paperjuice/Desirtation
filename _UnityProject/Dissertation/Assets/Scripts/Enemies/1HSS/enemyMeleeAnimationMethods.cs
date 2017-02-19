using UnityEngine;

public class enemyMeleeAnimationMethods : MonoBehaviour {

    [SerializeField] private enemyMeleeBehaviour _enemyMeleeBehaviour;
    [SerializeField] Collider eWeapon;
    
    void AttackBehaviour()
    {
        //combo of 1, 2, 3 an so on attacks
        if (_enemyMeleeBehaviour.attackBehaviour != 0)
        {
            _enemyMeleeBehaviour.attackBehaviour=0;
        }
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
