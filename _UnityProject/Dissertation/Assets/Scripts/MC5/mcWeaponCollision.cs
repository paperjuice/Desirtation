using UnityEngine;
using System.Collections;

public class mcWeaponCollision : MonoBehaviour {

    [SerializeField]GameObject[] dmgNumbers;
    [SerializeField] ParticleSystem[] slashs;

    GameObject[] enemies;
    ParticleSystem slash = new ParticleSystem();
    Transform father;
    bool isRepeting; //shit that should fucking prevent that shitassbug where attack is called twice fml

    private Animator _mainCamera;
//    bool isCameraFound =false;
    private mcStats _mcStats;
    private float weaponDamage = 3;
    public float WeaponDamage
    {
        get { return weaponDamage; }
        set { weaponDamage = value; }
    }
    float damageHistory = 0f;

    float totalDamage;



    void Awake()
    {
        _mcStats = GameObject.FindGameObjectWithTag("Player").GetComponent<mcStats>();
        father = slashs[0].transform.parent;
        //_mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    IEnumerator Start()
    {
        damageHistory = 3+(0.4f *(mcStats.knowledge+ _mcStats.BonusFortitude));

        while(true)
        {
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            yield return new WaitForSeconds(2f);
        }
    }

    void Update()
    {
        weaponDamage =3 + (0.1f *(mcStats.knowledge + _mcStats.Fortitude()));
        if(_mainCamera==null)
             _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        totalDamage = _mcStats.McDamage(weaponDamage);
        foreach(GameObject enemy in enemies)
        {
            if(col.gameObject == enemy)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("shake");
                enemy.GetComponent<generalEnemyStats>().ReceiveDamage(totalDamage);
                // Debug.Log(totalDamage);
                InstantiateDmgNumbers(col.gameObject, totalDamage);
            }
        }
    }

    IEnumerator HasBeenHit()
    {
        yield return new WaitForSeconds(0.1f);
        isRepeting = false;
    }
    

    void InstantiateDmgNumbers(GameObject enemyPos, float damage )
    {
        foreach(GameObject a in dmgNumbers)
        {
            if(!a.gameObject.activeInHierarchy)
            {
                a.gameObject.SetActive(true);
                if(a.transform.parent != null)
                    a.transform.parent =null;
                a.transform.position = enemyPos.transform.position + new Vector3(0f,3f,0f);
                a.GetComponent<TextMesh>().text = damage.ToString("N1");
                a.transform.rotation = Quaternion.Euler(50f,0f,0f);
                break;
            }
        }
    }

    bool CheckForCrit( float damage)
    {
        if(damageHistory * 1.6f <= damage)
        {
            return false;
        }
        else
        {
            
            return true;
        }
       
    }
}
