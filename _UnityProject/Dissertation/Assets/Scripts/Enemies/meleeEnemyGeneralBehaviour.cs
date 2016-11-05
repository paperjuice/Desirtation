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
    float aCurrentTime;
    float aEndTime = 2f;
    int attackBehaviour;

    //block variable
    float bCurrentTime;
    float bEndTime = 2.20f;
    [SerializeField]float chanceToBlock;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void PrintFloat(string asd)
    {
        Debug.Log(asd);
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
       // print(bCurrentTime);
    }
    
    void Distance()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 6 && Vector3.Distance(transform.position, player.transform.position) > 1.3f)
        {
            enemyState = 1;
        }
        else
        {
            enemyState = 0;
        }

        if (Vector3.Distance(transform.position, player.transform.position) < 1.3f)
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

        transform.rotation = Quaternion.LookRotation(direction);
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
            attackBehaviour = Random.Range(1, 11);

            
            if(attackBehaviour >=3)
            {
                anim.SetTrigger("attack");
            }

            aCurrentTime = 0f;
        }
    }

    void Block()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
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

            if (bCurrentTime >= bEndTime)
            {
                anim.SetBool("block", false);
                bCurrentTime = 0;
                enemyState = 0;
            }
        }
    }
    

}
