using UnityEngine;

public class mcWeaponCollision : MonoBehaviour {

    [SerializeField]GameObject[] dmgNumbers;

    private Animator _mainCamera;
//    bool isCameraFound =false;
    private mcStats _mcStats;
    private float weaponDamage = 3;
    public float WeaponDamage
    {
        get { return weaponDamage; }
        set { weaponDamage = value; }
    }



    void Awake()
    {
        _mcStats = GameObject.FindGameObjectWithTag("Player").GetComponent<mcStats>();
        //_mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    void Update()
    {
        if(_mainCamera==null)
             _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemy")
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
            _mcStats.Knowledge(0.1f+controller.dungeonLevel);  
            _mainCamera.SetTrigger("shake");
            col.gameObject.GetComponent<generalEnemyStats>().eCurrentHealth -=_mcStats.McDamage(WeaponDamage);
            InstantiateDmgNumbers(col.gameObject);
        }
    }

    void InstantiateDmgNumbers(GameObject enemyPos)
    {
        foreach(GameObject a in dmgNumbers)
        {
            if(!a.gameObject.activeInHierarchy)
            {
                a.gameObject.SetActive(true);
                if(a.transform.parent != null)
                    a.transform.parent =null;
                a.transform.position = enemyPos.transform.position + new Vector3(0f,3f,0f);
                a.GetComponent<TextMesh>().text = _mcStats.McDamage(WeaponDamage).ToString("N1");
                a.transform.rotation = Quaternion.Euler(50f,0f,0f);
                break;
            }
        }
    }
}
