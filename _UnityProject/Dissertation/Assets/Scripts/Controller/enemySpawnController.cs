using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnController : MonoBehaviour {


    [SerializeField] GameObject[] enemyList;
    [SerializeField] GameObject[] bossList;
    private int i=1;




    void Start()
    {
        if (controller.dungeonLevel % 5 == 0)
            i++;
    }

    void SpawnFoes()
    {

    }




}
