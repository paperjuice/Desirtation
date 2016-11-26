using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcCameraFollow : MonoBehaviour {


    private GameObject player;
    private Vector3 offset;
    private Vector3 savedPos;
    [SerializeField] float cameraFollowSpeed;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void FixedUpdate()
    {
        savedPos = player.transform.position + offset;


        transform.position = Vector3.Lerp(transform.position, savedPos, Time.deltaTime * cameraFollowSpeed);
    }




}
