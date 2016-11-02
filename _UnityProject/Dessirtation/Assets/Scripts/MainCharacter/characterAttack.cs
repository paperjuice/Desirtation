using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAttack : MonoBehaviour {

    [SerializeField] characterController charController;
	[SerializeField] Animator anim;
    Rigidbody rigid;

    bool isAttacking;



    void Awake()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isAttacking)
            {
                anim.SetTrigger("attack_1");
                isAttacking = true;
                charController.enabled = false;
            }
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Armature|attack_1") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime>0.89f)
        {
            isAttacking = false;
            charController.enabled = true;
        }
    }
}
