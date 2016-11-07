using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeEnemyGeneralBehaviour : MonoBehaviour {


    GameObject player;

    [SerializeField]Animator anim;
    [SerializeField]int enemyState; //0-idle|1-move|2-attack|3-block
    [SerializeField]float enemyMSSpeed;

    //movement variation
    float mvCurrentTime=0f;
    float mvEndTime=2f;
    int movementBehaviour=3;

    //rember position in order to activate movement animation
    Vector3 rememberPosition;

    //attack variables
    float aCurrentTime=2;
    float aEndTime = 1f;
    int attackBehaviour;

    //block variable
    float bCurrentTime;
    float bEndTime = 2.20f;
    [SerializeField]float chanceToBlock;


    //isPatrolling
    bool isPatrolling = true;
    float pCurrentTime = 0f;
    float pEndTime=1.5f;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator Start()
    {
        //activate move animation when moving
        while (true)
        {
            rememberPosition = transform.position;
            yield return new WaitForSeconds(0.1f);
            if (rememberPosition != transform.position)
            {
                anim.SetBool("move", true);
            }
            else
            {
                anim.SetBool("move", false);
            }
        }
    }

    void Update()
    {
        EnablePatrolling();
        Block();

        if (enemyState != 3)
        {
            Distance();

            if (enemyState == 1)
            {
                MoveTowardsPlayer();
            }
            else if (enemyState == 2)
            {
                AttackPlayer();
            }
        }
    }
    
    void Distance()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 10 && Vector3.Distance(transform.position, player.transform.position) > 2.5f)
        {
            enemyState = 1;
        }

        if (Vector3.Distance(transform.position, player.transform.position) < 2.5f)
        {
            enemyState = 2;
        }
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
        else if(movementBehaviour >4)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * enemyMSSpeed / 100);
        }
    }

    void RotateTowardsPlayer()
    {

        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0;

       Quaternion target = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 3f);
    }

    void AttackPlayer()
    {
        RotateTowardsPlayer();
        aCurrentTime += Time.deltaTime;

        if (attackBehaviour == 1)
        {
            transform.position += (Time.deltaTime * enemyMSSpeed / 100) * transform.right;
        }
        else if (attackBehaviour == 2)
        {
            transform.position -= (Time.deltaTime * enemyMSSpeed / 100) * transform.right;
        }
        
        //attack when chance is higher/equal than 3
        if (aCurrentTime >= aEndTime)
        {
            attackBehaviour = Random.Range(1, 20);

            
            if(attackBehaviour >=3)
            {
                anim.SetTrigger("attack");
            }

            aCurrentTime = 0f;
        }
    }

    void Block()
    {
        //chance to roll a block value when player plesses mouse 0
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
        {
            float blockRoll = Random.Range(0f, 100f);

            if (blockRoll <= chanceToBlock)
            {
                enemyState = 3;
            }
            bEndTime = Random.Range(1.7f, 2.20f);
        }

        if (enemyState == 3)
        {
            anim.SetBool("block", true);
            bCurrentTime += Time.deltaTime;

            if (bCurrentTime >= bEndTime )
            {
                anim.SetBool("block", false);
                bCurrentTime = 0;
                enemyState = 0;
            }
        }
    }

    void EnablePatrolling()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 15f)
        {
            enemyState = 0;
        }
    }


    void OnTriggerEnter(Collider col)
    {
        if (enemyState == 3)
        {
            if (col.gameObject.tag == "mainCharacterWeapon")
            {
                player.GetComponent<debuff>().currentInterruptTime = 1f;
            }
        }
    }
    

}
