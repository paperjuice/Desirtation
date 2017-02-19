using System.Collections;
using UnityEngine;

public class enemyRangeMovementBehaviour : MonoBehaviour {

    [SerializeField] Animator anim;
    enemyRangeAttackBehaviour _enemyRangeAttackBehaviour;
    
    GameObject player;

    //move towards variables
    [SerializeField] float ms;
    float currentTimeBetweenChangingMovement;

    //activate movement animation
    Vector3 currentPosition;
    Vector3 newPosition;


    RaycastHit _raycast;
    Ray _ray;
    Vector3 playerPos;




    //backstep
    [SerializeField] float backstepPower;

    //behaviour
    int actionId;


    void Awake()
    {
        _enemyRangeAttackBehaviour = GetComponent<enemyRangeAttackBehaviour>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator Start()
    {
        playerPos = transform.position;

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
        RotateTowardsPlayer();

        if (Vector3.Distance(transform.position, player.transform.position) > 3f && Vector3.Distance(transform.position, player.transform.position) < 14f)
            MoveTowardPlayer();
        else if (Vector3.Distance(transform.position, player.transform.position) <= 3f)
            MoveAwayFromPlayer();
        else if(Vector3.Distance(transform.position, player.transform.position) >= 14f)
            _enemyRangeAttackBehaviour.IsInRange(false);
    }

    void RotateTowardsPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0;
        Quaternion target = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 3f);
    }

    void MoveTowardPlayer()
    {
        _enemyRangeAttackBehaviour.IsInRange(true);

        _ray.origin = transform.position + new Vector3(0f, 1f, 0f);
        _ray.direction = transform.forward;


        if (Physics.Raycast(_ray, out _raycast, 10f))
        {
            Debug.DrawRay(transform.position + new Vector3(0f, 1f, 0f), transform.forward * 10f, Color.green);

            if (_raycast.collider.tag == "Player")
            {
                print("ating player");
                playerPos = _raycast.collider.transform.position;
            }
            else if (playerPos != transform.position)
                transform.position = Vector3.MoveTowards(transform.position, playerPos, Time.deltaTime * ms);
        }
        else
        {
            if (playerPos != transform.position)
                transform.position = Vector3.MoveTowards(transform.position, playerPos, Time.deltaTime * ms);
        }
    }

    void MoveAwayFromPlayer()
    {
        _enemyRangeAttackBehaviour.IsInRange(true);
        transform.position -= Time.deltaTime * transform.forward * ms / 2;
    }


}
