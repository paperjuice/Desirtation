using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMapGenController : MonoBehaviour {



    [SerializeField] private GameObject[] tile;
    [SerializeField] private GameObject endTile;
    [SerializeField] private int numberOfTiles;

    private GameObject[] mapSpawnPoints;
    private GameObject[] mapSpawnTiles;


    void Start()
    {
        while (numberOfTiles > 0)
        {
            mapSpawnPoints = GameObject.FindGameObjectsWithTag("mapSpawnPoint");
            mapSpawnTiles = GameObject.FindGameObjectsWithTag("tile");

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
                Instantiate(endTile, mapSpawnPoints[Random.Range(0, mapSpawnPoints.Length)].transform.position, transform.rotation = Quaternion.Euler(0f, ((int)Random.Range(0, 4) * 90), 0f));
                numberOfTiles--;
            }
        }
    }





}
