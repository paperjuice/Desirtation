using System.Collections;
using UnityEngine;

public class generalEnemyStats : MonoBehaviour {

    consumableDrop _consumableDrop;
    QuestController questController;
    mcStats _mcStats;
    SoundController soundController;

    bool isHit = false;
    public bool IsHit{
        get{return isHit;}
        set{isHit = value;}
    }
    //check for dual hit
    float savedHealth;
    float time;
    int countNumberOfBloodSpashes = 0;

    bool areEffectsTooOften = false; //this wont allow the enemy to play effects until a counter is set

    [SerializeField]private int id;
    public int Id{
        get{return id;}
        set{id=value;}
    }
    [HeaderAttribute("For when it dies")]
    [SerializeField] float amountOfKnowledgeGained;
    [SerializeField] GameObject aliveBody;
    [SerializeField] GameObject[] deadBody;
    [SerializeField] ParticleSystem _bloodPart;
    [SerializeField] GameObject _bloodSplatter;
    mcCameraFollow _camera;

    [Header("VisualizeHealth")]
    [SerializeField] GameObject fillBar;

    [SerializeField]private float eMaxHealth = 10f;
    [SerializeField]private float eMultiplierHealth = 10f;

    //when boss is defeated, the enemies power grows exponentially
    [HeaderAttribute("Check if it is a boss")]
    [SerializeField] bool isBoss;
    public static float eGlobalMultiplier = 1f;
    [HideInInspector]public float eCurrentHealth;

    private void Awake()
    {
        _consumableDrop = GetComponent<consumableDrop>();
        _camera = GameObject.FindGameObjectWithTag("cameraFather").GetComponent<mcCameraFollow>();
        _mcStats = GameObject.FindGameObjectWithTag("Player").GetComponent<mcStats>();
        soundController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
    }

    void Start()
    {
        eMaxHealth += (controller.dungeonLevel * eMultiplierHealth * eGlobalMultiplier) ;
        eCurrentHealth = eMaxHealth;
    }

    void Update()
    {
        // if(questController==null)
        //     questController = GameObject.FindGameObjectWithTag("questController").GetComponent<QuestController>();
        
        Death();
        VisualizeHealth();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "water")
            eCurrentHealth = 0;
    }

    void VisualizeHealth()
    {
        fillBar.transform.localScale = new Vector3(eCurrentHealth / eMaxHealth, 1f, 1f);
    }

   

    public void ReceiveDamage(float damage)
    {
        if(damage >0) //&& !isHit
        {
            // print("damaged");
            isHit = true;
            eCurrentHealth -= damage;
            damage = 0;
            
            if(!areEffectsTooOften)
            {
                if(countNumberOfBloodSpashes < 2)
                {
                    InstantiateBloodSplatter();
                    countNumberOfBloodSpashes ++;
                }
                areEffectsTooOften = true;
                _bloodPart.Play();
                soundController.EnemyHitSound();
                
                StartCoroutine(CounterForEffect());
            }
            // StartCoroutine(DoubleHitPrevention());
        }
    }

    IEnumerator CounterForEffect()
    {
        yield return new WaitForSeconds(1f);
        areEffectsTooOften = false;
    }

    IEnumerator DoubleHitPrevention()
    {
        yield return new WaitForSeconds(0.1f);
        isHit = false;
    }

    void Death()
    {
        if (eCurrentHealth <= 0)
        {
            _mcStats.Knowledge(amountOfKnowledgeGained *(controller.dungeonLevel * 0.4f));
            if(isBoss)
                eGlobalMultiplier += 1.1f;
//            questController.IncrementQuest(id);
            _camera.IsBossMode = false;
            foreach(GameObject a in deadBody)
            {
                a.transform.parent = null;
                a.gameObject.SetActive(true);
                if (CheckIfBodyHasRigidbody(a))
                {
                    a.transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
                    a.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-0.7f, 0.7f), 1000f, Random.Range(-0.7f, 0.7f) * Time.deltaTime * 8f * 10000f));
                    Destroy(a.gameObject, 4f);
                }
            }
            GameObject bloodPng;
            float bloodScale = Random.Range(0.09f, 0.3f);
            bloodPng = Instantiate(_bloodSplatter, new Vector3(transform.position.x, transform.position.y+0.05f, transform.position.z), Quaternion.Euler(90f, Random.Range(0f,360f), transform.rotation.z));             
            bloodPng = Instantiate(_bloodSplatter, new Vector3(transform.position.x, transform.position.y+0.05f, transform.position.z), Quaternion.Euler(90f, Random.Range(0f,360f), transform.rotation.z));
            bloodPng.transform.localScale = new Vector3(bloodScale, bloodScale, 0.3f);
             _consumableDrop.ItemDrop();
            aliveBody.gameObject.SetActive(false);
        }
    }

    bool CheckIfBodyHasRigidbody(GameObject a)
    {
        if (a.GetComponent<Rigidbody>() != null)
            return true;
        else
            return false;
    }

    void InstantiateBloodSplatter()
    {
        GameObject bloodPng;
        float bloodScale = Random.Range(0.09f, 0.3f);
        // yield return new WaitForSeconds(0.15f);        
        bloodPng = Instantiate(_bloodSplatter, new Vector3(transform.position.x, transform.position.y+0.05f, transform.position.z), Quaternion.Euler(90f, Random.Range(0f,360f), transform.rotation.z));             
        // yield return new WaitForSeconds(0.2f);
        // bloodPng = Instantiate(_bloodSplatter, new Vector3(transform.position.x, transform.position.y+0.05f, transform.position.z), Quaternion.Euler(90f, Random.Range(0f,360f), transform.rotation.z));
        bloodPng.transform.localScale = new Vector3(bloodScale, bloodScale, 0.3f);
    }


}
