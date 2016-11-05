using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventState_ActivateCollisionOnWeapon : MonoBehaviour {

	[SerializeField] Collider _collider;

    void ActivateCollision(int isCollisionActivated)
    {
        if (isCollisionActivated == 0)
        {
            _collider.enabled = false;
        }
        else if (isCollisionActivated == 1)
        {
            _collider.enabled = true;
        }
    }

}
