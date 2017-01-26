using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mcMovementBehaviour : MonoBehaviour {


    private mcStats _mcStats;
    private consumableEffect _ce;

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
    BoxCollider mcWeapon;

    //Block
    private bool isBlocking;
    [SerializeField]private GameObject gameObjectBlock;
    [SerializeField]private float deflect = 0f;
    private bool isDeflecting;

    //Roll
    public bool isRolling;
    public bool isInvincible;




    void Awake()
    {
        mcWeapon = GameObject.FindGameObjectWithTag("mcWeapon").GetComponent<BoxCollider>();
        _mcStats = GetComponent<mcStats>();
        layerMask = LayerMask.GetMask("floor");
        rigid = GetComponent<Rigidbody>();
        _ce = GetComponent<consumableEffect>();
    }
    
    void Update()
    {


        anim.SetFloat("attackSpeed", 1f + _ce.AttackSpeed);

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

            if (!isBlocking && !anim.GetBool("deflected"))
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
        

        if (_mcStats.Spirit(0) >= 5)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (attackQueue < 3)
                {
                    attackQueue++;
                    _mcStats.Spirit(5f);
                }
            }
        }

        if (attackQueue == 0f)
            mcWeapon.enabled = false;

        if (attackQueue != 0)
            anim.SetBool("attack", true);
    }

    void Block()
    {
        if (_mcStats.Spirit(0f) >= 10f)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                isBlocking = true;
                anim.SetTrigger("block");
                gameObjectBlock.gameObject.SetActive(true);
                _mcStats.Spirit(10f);
            }
        }

        if (isBlocking)
        {
            deflect += Time.deltaTime;
        }

        if (deflect >= 0.2f)
        {
            isBlocking = false;
        }
    }

    void Roll()
    {
        if(_mcStats.Spirit(0)>=15)
        {
            if ((_x != 0 || _z != 0) && Input.GetKeyDown(KeyCode.Space) && !isRolling)
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
                _mcStats.Spirit(15f);
            }

            

        }
        if (isRolling)
        {
            rigid.MovePosition(transform.position + transform.forward * mcSpeed * Time.deltaTime);
        }
    }


}
