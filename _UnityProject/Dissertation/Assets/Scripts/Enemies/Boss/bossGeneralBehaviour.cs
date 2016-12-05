using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossGeneralBehaviour : MonoBehaviour {


    private GameObject player;
    private bossMeleeAttackBehaviour _bossMeleeAttack;
    private int enemyState = 0;
    [SerializeField]private Animator _anim;

    //time between movement
    [SerializeField] float enemyMSSpeed = 80f;
    private float mvCurrentTime = 0f;
    private float mvEndTime = 1f;
    private int movementBehaviour = 0; //roll number to determine movement behaviour

    //check movement
    private Vector3 currentPos;
    private Vector3 pastPos;




    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _bossMeleeAttack = GetComponent<bossMeleeAttackBehaviour>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            currentPos = transform.position;
            yield return new WaitForSeconds(0.2f);
            pastPos = transform.position;

            if (currentPos != pastPos)
                _anim.SetBool("move", true);
            else
                _anim.SetBool("move", false);
        }        
    }


    void Update()
    {
        EnablePatrolling();

        if (enemyState != 3)
        {
            Distance();

            if (enemyState == 1)
            {
                MoveTowardsPlayer();
            }
            else if (enemyState == 2)
            {
                //print("acum bagam atac special");
                StartCoroutine(_bossMeleeAttack.MeleeAttack());
               
            }
        }
    }


    void Distance()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 10 && Vector3.Distance(transform.position, player.transform.position) > 2.5f)
            {
                enemyState = 1;
            }

            if (Vector3.Distance(transform.position, player.transform.position) < 3f)
            {
                enemyState = 2;
            }
        }
    }


    void RotateTowardsPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0;

        Quaternion target = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 3f);
    }

    void MoveTowardsPlayer()
    {
        Vector3 targetPosition = player.transform.position;
        targetPosition.y = 0f;
        RotateTowardsPlayer();


        mvCurrentTime += Time.deltaTime;

        if (mvCurrentTime >= mvEndTime)
        {
            movementBehaviour = Random.Range(1, 11);
            mvCurrentTime = 0f;
            mvEndTime = Random.Range(1f, 3f);
        }

        if (movementBehaviour <= 2)
        {
            transform.position += (Time.deltaTime * enemyMSSpeed / 100) * transform.right;
        }
        else if (movementBehaviour <= 4 && movementBehaviour > 2)
        {
            transform.position -= (Time.deltaTime * enemyMSSpeed / 100) * transform.right;
        }
        else if (movementBehaviour > 4)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * enemyMSSpeed / 100);
        }
    }


    void EnablePatrolling()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 15f)
            {
                enemyState = 0;
            }
        }
    }








}
