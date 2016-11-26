using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcMovementBehaviour : MonoBehaviour {

    //Rotation
    private RaycastHit _raycast;
    private float dist = 1000f;
    private int layerMask;
    [SerializeField] private float playerRotationSpeed;


    //Movement
    private Rigidbody rigid;
    private Vector3 pos;
    private float positiveSpeed;
    private float negativeSpeed;
    private float _x;
    private float _z;
    [SerializeField] Animator anim;
    [SerializeField] private float mcSpeed;

    //Attack
    public int attackQueue = 0;

    //Block
    private bool isBlocking;
    [SerializeField]private float deflect = 0f;
    private bool isDeflecting;

    //Roll
    public bool isRolling;
    public bool isInvincible;


    void Awake()
    {
        layerMask = LayerMask.GetMask("floor");
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (attackQueue == 0 )
            Roll();

        if (!isRolling)
        {
            if (attackQueue == 0)
            {
                RotateTowardsMouse();
                Block();
                Roll();
            }

            if (!isBlocking)
                Attack();
        }
    }

    void FixedUpdate()
    {
        if (attackQueue == 0 && !isRolling)
            Movement();
    }

    void RotateTowardsMouse()
    {
        var rayFromMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayFromMouse, out _raycast, dist, layerMask))
        {
            Vector3 rotate = _raycast.point - transform.position;
            rotate.y = 0f;

            Quaternion target_rotation = Quaternion.LookRotation(rotate);

            transform.rotation = Quaternion.Lerp(transform.rotation, target_rotation, playerRotationSpeed * Time.deltaTime);
        }
    }

    void Movement()
    {
        _x = Input.GetAxis("Horizontal");
        _z = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(_x, 0f, _z) * mcSpeed * Time.deltaTime;
        rigid.MovePosition(transform.position + direction);

        if (_z != 0 || _x != 0)
        {
            anim.SetBool("walkin", true);
        }
        else
        {
            anim.SetBool("walkin", false);
        }
    }


    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (attackQueue < 3)
            {
                attackQueue++;
            }
        }

        if (attackQueue != 0)
        {
            anim.SetBool("attack", true);
        }
    }

    void Block()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isBlocking = true;
            anim.SetBool("block", true);
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isBlocking = false;
            anim.SetBool("block", false);
        }

        if (isBlocking)
        {
            deflect += Time.deltaTime;
        }
        else
        {
            deflect = 0;
        }

        if (deflect <= 0.5f)
        {
            isDeflecting = true;
            //print("successfully deflected");
        }
        else
        {
            isDeflecting = false;
        }
    }


    void Roll()
    {
        if ((_x!=0||_z!=0)&&Input.GetKeyDown(KeyCode.Space)&& !isRolling)
        {
            isRolling = true;

            if (_x > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }

            if (_x < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 270f, 0f);
            }

            if (_z < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }

            if (_z > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if (_z > 0 && _x > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 45f, 0f);
            }

            if (_z > 0 && _x < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 315f, 0f);
            }

            if (_z < 0 && _x > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 135f, 0f);
            }

            if (_z < 0 && _x < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 225f, 0f);
            }
            anim.SetTrigger("roll");
        }

        if (isRolling)
        {
            rigid.MovePosition(transform.position + transform.forward * mcSpeed * Time.deltaTime);
        }
    }


}
