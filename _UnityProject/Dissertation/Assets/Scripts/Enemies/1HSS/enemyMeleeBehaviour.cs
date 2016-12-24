using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMeleeBehaviour : MonoBehaviour {


    private GameObject player;
    private int enemyState=0;

    [SerializeField] Animator anim;

    //time between movement
    [SerializeField] float enemyMSSpeed = 80f;
    private float mvCurrentTime=0f;
    private float mvEndTime = 1f;
    private int movementBehaviour = 0; //roll number to determine movement behaviour

    //Attack behaviour
    public int attackBehaviour; //roll a number between 1 and 4 which will dictate enemy behaviour
    float timeBeforeNextAttack= 0.7f;

    private Vector3 currentPosition;
    private Vector3 newPosition;


    [Header("Animation Strings")]
    public string[] animationString;



    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    IEnumerator Start()
    {
        while (true)
        {
            currentPosition = transform.position;
            yield return new WaitForSeconds(0.1f);
            newPosition = transform.position;

            if (newPosition == currentPosition)
                anim.SetBool("move", false);
            else
                anim.SetBool("move", true);

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
                AttackPlayer();
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

    void AttackPlayer()
    {
        //print(attackBehaviour);
        if (attackBehaviour == 0)
        {
            attackBehaviour = Random.Range(1, animationString.Length+ (int)Mathf.Ceil(animationString.Length/2)+1);
            movementBehaviour = Random.Range(1, 3);  //in case "attackBehaviour" rolls 4, a number between 1 and 2 is rolled to move left or right
        }
        
        if (attackBehaviour > animationString.Length)
        {
            RotateTowardsPlayer();
            mvCurrentTime += Time.deltaTime; //amount of time that the enemie move when in player range
            if (movementBehaviour == 1)
            {
                transform.position += (Time.deltaTime * enemyMSSpeed / 100) * transform.right;
            }
            else if (movementBehaviour == 2)
            {
                transform.position -= (Time.deltaTime * enemyMSSpeed / 100) * transform.right;
            }
            
            if (mvCurrentTime >= mvEndTime)
            {
                mvCurrentTime = 0f;
                attackBehaviour = 0;
            }
        }

        if (attackBehaviour >= 1 && attackBehaviour <= animationString.Length)
        {
            anim.SetTrigger(animationString[attackBehaviour - 1]);

            timeBeforeNextAttack -= Time.deltaTime;

            if (timeBeforeNextAttack <= 0)
            {
                timeBeforeNextAttack = 0.7f;
                attackBehaviour = 0;
            }
        }




    }

}
