using UnityEngine;
using System.Collections;

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
            var generalEnemySts= col.gameObject.GetComponent<generalEnemyStats>();
            if(!generalEnemySts.IsHit)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("shake");
                _mcStats.Knowledge(0.1f+controller.dungeonLevel);  
                generalEnemySts.eCurrentHealth -=_mcStats.McDamage(WeaponDamage + Endowments.bonusRawDamage);
                InstantiateDmgNumbers(col.gameObject);
                StartCoroutine(HasBeenHit(col.gameObject));
            }
        }
    }

    IEnumerator HasBeenHit(GameObject obj)
    {
        yield return new WaitForSeconds(0.1f);
        obj.GetComponent<generalEnemyStats>().IsHit=false;
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
