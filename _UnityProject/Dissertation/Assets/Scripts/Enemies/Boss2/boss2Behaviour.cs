using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2Behaviour : MonoBehaviour {


    [SerializeField] Animator _anim;
    Collider _collider;


    //time between attacks
    bool isActive;
    float currentTime=3f;
    float endTime;
    int attackType;







    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(6.5f);
        _collider.enabled = true;
        isActive=true;
    }


    void Update()
    {
        if (isActive)
            AttackBehaviour();
    }

    void AttackBehaviour()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= endTime)
        {
            currentTime = 0f;
            attackType = Random.Range(1, 7);
            
        }


        switch(attackType)
        {
            case 1:
                _anim.SetTrigger("attackLH1");
                endTime = Random.Range(4f, 7f);
                attackType = 0;
                break;
            case 2:
                _anim.SetTrigger("attackRH1");
                endTime = Random.Range(4f, 7f);
                attackType = 0;
                break;
            case 3:
                _anim.SetTrigger("attackRH2");
                endTime = Random.Range(4f, 7f);
                attackType = 0;
                break;
            case 4:
                _anim.SetTrigger("combo1");
                endTime = Random.Range(7f, 8f);
                attackType = 0;
                break;
            case 5:
                _anim.SetTrigger("combo2");
                endTime = Random.Range(10f, 12f);
                attackType = 0;
                break;
            case 6:
                _anim.SetTrigger("combo3");
                endTime = Random.Range(10f, 12f);
                attackType = 0;
                break;



        }

    }









}
