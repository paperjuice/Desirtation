using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAttack : MonoBehaviour {

    
    [SerializeField] characterController charController;
	[SerializeField] Animator anim;
    Rigidbody rigid;

    
    [SerializeField]float endAttackTime;
    float savedEndAttackTime;
    public float currentAttackTime = 0f;
	public bool isAttacking =false;
    bool waitForAttackSequenceToFinish = false;
    [SerializeField]float bodyForceForwardOnAttack = 600f;
    float savedBodyForceForwardOnAttack;
    bool isBodyForceActivated = false;
    Vector3 savedTargetPosition;






    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        savedEndAttackTime = endAttackTime;
        savedBodyForceForwardOnAttack = bodyForceForwardOnAttack;
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isAttacking)
            {
               // anim.SetTrigger("attack_1");
                anim.SetBool("attack_1b", true);
                isAttacking = true;
                charController.enabled = false;
                isBodyForceActivated = true;
            }
        }

        if (isAttacking)
        {
            currentAttackTime += Time.deltaTime;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Armature|attack_1"))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (isAttacking)
                {
                    if (!waitForAttackSequenceToFinish)
                    {
                        anim.SetBool("chain_1", true);
                        anim.SetBool("attack_1b", false);
                        endAttackTime *=2f;
                        waitForAttackSequenceToFinish = true;
                        bodyForceForwardOnAttack = savedBodyForceForwardOnAttack;
                    }
                }
            }
        }

        print(endAttackTime);

        if (currentAttackTime > endAttackTime)
        {
            isAttacking = false;
            charController.enabled = true;
            currentAttackTime = 0f;
            endAttackTime = savedEndAttackTime;
            anim.SetBool("chain_1", false);
            anim.SetBool("attack_1b", false);
            waitForAttackSequenceToFinish = false;

            bodyForceForwardOnAttack = savedBodyForceForwardOnAttack;
            isBodyForceActivated = false;
        }

        if (isBodyForceActivated)
        {
            bodyForceForwardOnAttack += Time.deltaTime * 100;
            rigid.AddForce(bodyForceForwardOnAttack * transform.forward);
        }

    }
}
