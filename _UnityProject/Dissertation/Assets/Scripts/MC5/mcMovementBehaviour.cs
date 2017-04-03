using UnityEngine;

public class mcMovementBehaviour : MonoBehaviour {


    private mcStats _mcStats;
    private consumableEffect _ce;

    //Rotation
    private RaycastHit _raycast;
    private float dist = 1000f;
    private int layerMask;
    [SerializeField] private float playerRotationSpeed;
    float savedPlayerRotationSpeed;


    //Movement
    private Rigidbody rigid;
    private Vector3 pos;
    private float positiveSpeed;
    private float negativeSpeed;
    private float _x;
    private float _z;
    [SerializeField] Animator anim;
    [SerializeField] private float mcSpeed;
    public float McSpeed{
        get{return mcSpeed;}
        set{mcSpeed = value;}
    }
    
    //Attack
    public int attackQueue = 0;
    BoxCollider mcWeapon;

    //Block
    private bool isBlocking;
    [SerializeField]private BoxCollider gameObjectBlock;
//    [SerializeField]private float deflect = 0f;
    private bool isDeflecting;
    bool isAbleToBlock=true;

    //Roll
    public bool isRolling;
    public bool isInvincible;




    void Awake()
    {
        savedPlayerRotationSpeed = playerRotationSpeed;

        mcWeapon = GameObject.FindGameObjectWithTag("mcWeapon").GetComponent<BoxCollider>();
        _mcStats = GetComponent<mcStats>();
        layerMask = LayerMask.GetMask("floor");
        rigid = GetComponent<Rigidbody>();
        _ce = GetComponent<consumableEffect>();
    }
    
    void Update()
    {
        //attack speed
        anim.SetFloat("attackSpeed", 1f + _ce.AttackSpeed*0.03f + _mcStats.Youthfulness()*0.0005f + Endowments.bonusAttackSpeed);

        if (!isRolling)
        {
            if (attackQueue == 0)
            {
                RotateTowardsMouse();
                Block();
                //Roll();
            }

            if (!isBlocking /*&& !anim.GetBool("deflected")*/)
                AttackV2();
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
                if (attackQueue < 1)
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

    void AttackV2()
    {
        var randomSwingAttack = 0;
        if(_mcStats.Spirit(0) >= 5f)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                randomSwingAttack = Random.Range(1,3);
                _mcStats.Spirit(5f);
            }
        }

        if(randomSwingAttack == 1)
        {
            anim.SetTrigger("attack1");
            randomSwingAttack = 0;
        }
        else if(randomSwingAttack == 2)
        {
            anim.SetTrigger("attack2");
            randomSwingAttack = 0;
        }

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Armature|attack_1") || anim.GetCurrentAnimatorStateInfo(0).IsName("Armature|attack_2"))
        {
            playerRotationSpeed = 0.5f;
        }
        else
        {
            playerRotationSpeed = savedPlayerRotationSpeed;
        }
    }

    void Block()
    {
        if (_mcStats.Spirit(0f) >= 10f)
            isAbleToBlock = true;

        if(isAbleToBlock)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                anim.SetBool("block", true);
                if(anim.GetCurrentAnimatorStateInfo(0).IsName("Armature|block"))
                {
                    isBlocking = true;
                    gameObjectBlock.enabled = true;
                    _mcStats.Spirit(0.4f);
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) || _mcStats.Spirit(0f) <= 1f)
        {
            isAbleToBlock = false;
            isBlocking = false;
            anim.SetBool("block", false);
            gameObjectBlock.enabled = false;
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
