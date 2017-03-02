
using System.Collections;
using UnityEngine;

public class enemySpawnController : MonoBehaviour {

    [SerializeField] int numberOfEnemies;
    [SerializeField] GameObject[] enemyList;
    [SerializeField] GameObject[] bossList;
    private GameObject[] enemySpawnPoints;
    private GameObject[] bossSpawnPoints;
    private GameObject player;
    private int i=1;

    private float chanceToGetEnemy;
    private float enemyRollChance;
    private float bossRollChance;

    private bool isReady; //we set this true after we made sure all the tiles are instantiated

    // IEnumerator FindPlayer()
    // {
    //     yield return new WaitForSeconds(0.1f);
    //     player = GameObject.FindGameObjectWithTag("Player");
    // }

    void Start()
    {
      //  StartCoroutine(FindPlayer());
       // StartCoroutine(GetSpawnPoints());
        i = controller.dungeonLevel;
    }

    // IEnumerator GetSpawnPoints()
    // {
    //     yield return new WaitForSeconds(0.1f);
    //     enemySpawnPoints = GameObject.FindGameObjectsWithTag("enemySpawnPoint");
    //     bossSpawnPoints = GameObject.FindGameObjectsWithTag("bossSpawnPoint");
    //     isReady=true;
    // }

    void Update()
     {
        GetPlayer();
        GetSpawnPoints();
        if(isReady)
        {
            SpawnFoes();
            SpawnBosses();
        }
    }

    void GetSpawnPoints()
    {
        if(enemySpawnPoints == null)
            enemySpawnPoints = GameObject.FindGameObjectsWithTag("enemySpawnPoint");

        if(bossSpawnPoints == null)
            bossSpawnPoints = GameObject.FindGameObjectsWithTag("bossSpawnPoint");

        if(enemySpawnPoints != null && bossSpawnPoints != null)
            isReady = true;
    }

    void GetPlayer()
    {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    void SpawnFoes()
    {
        foreach(GameObject esp in enemySpawnPoints)
        {
            if(Vector3.Distance(esp.transform.position, player.transform.position)<40f)
            {
                if(esp.gameObject.activeInHierarchy)
                {
                    chanceToGetEnemy = Random.Range(0f,100f);
                    if(chanceToGetEnemy <= 10f+(i*4f))
                    {
                        enemyRollChance = Random.Range(1f,100f);
                        if(enemyRollChance<=110-i*10)
                        {
                            Instantiate(enemyList[0], esp.transform.position, transform.rotation);
                        }
                        else
                        {
                            Instantiate(enemyList[Random.Range(1,enemyList.Length)], esp.transform.position, transform.rotation);  
                        }
                    }
                    esp.gameObject.SetActive(false);
                }
            }
        }
    }

    void SpawnBosses()
    {
        foreach(GameObject bsp in bossSpawnPoints)
        {
            if(Vector3.Distance(bsp.transform.position, player.transform.position)<40f)
            {
                if(bsp.gameObject.activeInHierarchy)
                {
                    bossRollChance = Random.Range(1f,100f);
                    if(bossRollChance<i/(10f+i)*100f)
                        Instantiate(bossList[Random.Range(0,bossList.Length)], bsp.transform.position, transform.rotation );
                    bsp.gameObject.SetActive(false);
                }
            }
        }

    }




}
