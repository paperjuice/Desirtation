﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraMCFollow : MonoBehaviour {

    private GameObject player;
    private Vector3 offset;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        offset = transform.position- player.transform.position;
    }

    void FixedUpdate()
    {
        transform.position =player.transform.position+ offset;
    }





}
