using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {


    [SerializeField] characterAttack charAttack;



    //MC to mouse
    private RaycastHit _raycast;
    private int layerMask;
    private float dist = 1000f;
    [SerializeField]private float playerRotationSpeed;

    //Movement
    private Rigidbody rigid;
    private Vector3 pos;
    private float positiveSpeed;
    private float negativeSpeed;
    [SerializeField] Animator anim;
    [SerializeField] private float mcSpeed;
    [SerializeField] private float maxVelocity;
    [SerializeField] private KeyCode W;
    [SerializeField] private KeyCode A;
    [SerializeField] private KeyCode S;
    [SerializeField] private KeyCode D;

    //Roll
    public bool isRolling = false;
    private int rollCase; //based on the direction you re moving, you roll towards that 
    


    void Awake()
    {
        layerMask = LayerMask.GetMask("floor");
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        pos = transform.position;
    }
    

    void FixedUpdate()
    {
        if (!isRolling)
        {
            Movement();
        }


        //the force which is used to roll forward
        if (isRolling)
        {
            rigid.AddForce(mcSpeed*0.7f * transform.forward);
            //if (rigid.velocity.magnitude > 5)
            //{
            //    rigid.velocity = rigid.velocity.normalized * maxVelocity * 0.5f;
            //}
        }

    }

    void Update()
    {
        if (!isRolling)
        {
            RotateTowardsMouse();
        }
        Roll();

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
        if (rigid.velocity.magnitude > 5)
        {
            rigid.velocity = rigid.velocity.normalized * maxVelocity;
        }

        if (Input.GetKey(W) || Input.GetKey(A) || Input.GetKey(S) || Input.GetKey(D))
        {
            anim.SetBool("move", true);
        }
        else
        {
            anim.SetBool("move", false);
        }


        if (Input.GetKey(W))
        {
            pos = Vector3.forward * mcSpeed;
            rigid.AddForce(pos);
        }

        if (Input.GetKey(A))
        {
            pos = Vector3.right * -mcSpeed;
            rigid.AddForce(pos);
        }

        if (Input.GetKey(S))
        {
            pos = Vector3.forward * -mcSpeed;
            rigid.AddForce(pos);
        }

        if (Input.GetKey(D))
        {
            pos = Vector3.right * mcSpeed;
            rigid.AddForce(pos);
        }
    }

    void Roll()
    {
        if (Input.GetKey(W))
        {
            if (Input.GetKey(A))
            {
                rollCase = 8;
            }
            else if (Input.GetKey(D))
            {
                rollCase = 5;
            }
            else
            {
                rollCase = 1;
            }
        }

        if (Input.GetKey(S))
        {
            if (Input.GetKey(D))
            {
                rollCase = 6;
            }
            else if (Input.GetKey(A))
            {
                rollCase = 7;
            }
            else
            {
                rollCase = 3;
            }
        }

        if (Input.GetKey(A))
        {
            if (Input.GetKey(S))
            {
                rollCase = 7;
            }
            else if (Input.GetKey(W))
            {
                rollCase = 8;
            }
            else
            {
                rollCase = 4;
            }
        }

        if (Input.GetKey(D))
        {
            if (Input.GetKey(W))
            {
                rollCase = 5;
            }
            else if (Input.GetKey(S))
            {
                rollCase = 6;
            }
            else
            {
                rollCase = 2;
            }

        }
        if (!isRolling)
        {
            if ((Input.GetKey(W) || Input.GetKey(A) || Input.GetKey(S) || Input.GetKey(D)) && Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("roll");
                isRolling = true;
                charAttack.enabled = false;

                switch (rollCase)
                {
                    case 1:
                        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        break;
                    case 2:
                        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                        break;
                    case 3:
                        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                        break;
                    case 4:
                        transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                        break;
                    case 5:
                        transform.rotation = Quaternion.Euler(0f, 45f, 0f);
                        break;
                    case 6:
                        transform.rotation = Quaternion.Euler(0f, 135f, 0f);
                        break;
                    case 7:
                        transform.rotation = Quaternion.Euler(0f, 225f, 0f);
                        break;
                    case 8:
                        transform.rotation = Quaternion.Euler(0f, 315f, 0f);
                        break;

                }
            }
        }
       // Debug.Log(rollCase.ToString());

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Armature|tumble") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >0.88f)
        {
            isRolling = false;
            charAttack.enabled = true;
        }

       
    }
    
}
