using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeEnemyAttackBehaviour : MonoBehaviour {

    
    [SerializeField] Collider _collider;


    void ActivateCollider(int isColliderActivated)
    {
        if (isColliderActivated == 1)
        {
            _collider.enabled = true;
        }
        else if (isColliderActivated == 0)
        {
            _collider.enabled = false;
        }
    }
}
