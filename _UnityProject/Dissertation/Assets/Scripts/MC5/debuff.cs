using UnityEngine;

public class debuff : MonoBehaviour {

//    private Animator _mainCamera;
    [SerializeField]private Animator anim;
    private mcMovementBehaviour _mainChar;
    Rigidbody rigid;

    //slow
    float savedMsSpeed;
    float current_slow = 0f;
    // float end_slow;

    //is interrupting
    [HideInInspector]private float secondsInterrupted;
    public float SecondsInterrupted
    {
        get{return secondsInterrupted;}
        set{secondsInterrupted = value;}
    }



    void Awake()
    {
        rigid =  GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
       // _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        anim = GameObject.FindGameObjectWithTag("PlayerMesh").GetComponent<Animator>();
        _mainChar = GameObject.FindGameObjectWithTag("Player").GetComponent<mcMovementBehaviour>();
    }

    void Start()
    {
        savedMsSpeed = _mainChar.McSpeed;
    }

    private void Update()
    {
        Interrupting();
        Slow();
    }
    
    void Interrupting()
    {
        if (secondsInterrupted > 0)
        {
            secondsInterrupted -= Time.deltaTime;
            anim.SetBool("walkin", false);
            anim.SetBool("block", false);
            _mainChar.attackQueue = 0;
            _mainChar.isRolling = false;
            _mainChar.enabled = false;
        }
        else if (secondsInterrupted <= 0)
        {
            _mainChar.enabled = true;
        }
    }

    public void PushBack(Vector3 fromPos, Vector3 toPos, float force)
    {
        if(rigid!= null)
            rigid.AddForce((toPos-fromPos) * force*1000f*60f * Time.deltaTime);
    }

    public void Slow(float amountOfTimeSlowed = 0)
    {
        _mainChar.McSpeed = savedMsSpeed * 0.2f;

        if(current_slow < amountOfTimeSlowed)
        {
            current_slow += Time.deltaTime;
        }
        else if(current_slow >=amountOfTimeSlowed)
        {
            current_slow = 0;
            _mainChar.McSpeed = savedMsSpeed;
        }
        
    }

   





}
