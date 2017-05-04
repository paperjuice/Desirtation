using UnityEngine;

public class randomMapGenController : MonoBehaviour {



    [SerializeField] private GameObject[] tile;
    [SerializeField] private GameObject lift;
    [SerializeField] private int numberOfTiles;
    Quaternion lastTileSavedPos;

    private GameObject[] mapSpawnPoints;
    private GameObject[] mapSpawnTiles;
    private GameObject[] liftSpawnPoint;
    int randomLiftPoint;


    void Start()
    {
        if(controller.dungeonLevel > 2)
            numberOfTiles += Random.Range(-1, 3);

        while (numberOfTiles > 0)
        {
            mapSpawnPoints = GameObject.FindGameObjectsWithTag("mapSpawnPoint");
            mapSpawnTiles = GameObject.FindGameObjectsWithTag("tile");
            liftSpawnPoint = GameObject.FindGameObjectsWithTag("liftSpawnPoint");

            foreach (GameObject a in mapSpawnTiles)
            {
                foreach (GameObject b in mapSpawnPoints)
                {
                    if (Vector3.Distance(a.transform.position, b.transform.position) < 10)
                    {
                        b.gameObject.SetActive(false);
                    }
                }
            }

            mapSpawnPoints = GameObject.FindGameObjectsWithTag("mapSpawnPoint");

            if (numberOfTiles != 1)
            {
                Instantiate(tile[Random.Range(0, tile.Length)], mapSpawnPoints[Random.Range(0, mapSpawnPoints.Length)].transform.position, transform.rotation = Quaternion.Euler(0f, ((int)Random.Range(0, 4) * 90), 0f));
                numberOfTiles--;
            }
            else
            {
                randomLiftPoint = Random.Range(0, liftSpawnPoint.Length);
                Instantiate(lift, liftSpawnPoint[randomLiftPoint].transform.position, lift.transform.rotation = liftSpawnPoint[randomLiftPoint].transform.rotation);
                numberOfTiles--;
            }
        }
    }





}
