using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debuff : MonoBehaviour {

    private Animator _mainCamera;
    [SerializeField]private Animator anim;
    private mcMovementBehaviour _mainChar;


    //is interrupting
    public float secondsInterrupted;



    void Awake()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        anim = GameObject.FindGameObjectWithTag("PlayerMesh").GetComponent<Animator>();
        _mainChar = GameObject.FindGameObjectWithTag("Player").GetComponent<mcMovementBehaviour>();
    }

    private void Update()
    {
        Interrupting();
    }

    public void PlayerDamaged(float enemyDamage)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("shake");
        print("DAMAGED!:  " + enemyDamage);
    }

    void Interrupting()
    {
        if (secondsInterrupted > 0)
        {
            secondsInterrupted -= Time.deltaTime;
            anim.SetBool("deflected", true);
            anim.SetBool("attack", false);
            anim.SetBool("walkin", false);
            _mainChar.attackQueue = 0;
            _mainChar.isRolling = false;
            _mainChar.enabled = false;
        }
        else if (secondsInterrupted <= 0)
        {
            anim.SetBool("deflected", false);
            _mainChar.enabled = true;
        }
    }

    public void PushBack(Vector3 fromPos, Vector3 toPos, float force)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().AddForce((toPos-fromPos) * force*1000f);
    }


    public float ChanceToDieOnHit()
    {
        float ageChanceToDieOnHit;

        ageChanceToDieOnHit = Mathf.Floor(((18 + mcStats.age) / (1000/ (mcStats.age+1)))*10f);
        mcStats.statisticsChanceToDieOnHit = ageChanceToDieOnHit;

        if (Random.Range(1f, 100f) <= ageChanceToDieOnHit)
            mcStats.isDead = true;
        print(mcStats.age+18f + "   |   " + ageChanceToDieOnHit);

        return ageChanceToDieOnHit;
    }





}
