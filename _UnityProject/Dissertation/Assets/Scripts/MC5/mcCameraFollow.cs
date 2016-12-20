using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcCameraFollow : MonoBehaviour {


    private GameObject player;
    private Vector3 offset;
    private Vector3 savedPos;
    [SerializeField] float cameraFollowSpeed;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;

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
        //savedPos = player.transform.position + offset;


        //transform.position = Vector3.Lerp(transform.position, savedPos, Time.deltaTime * cameraFollowSpeed);
        CameraFollow2();
    }




    void CameraFollow2()
    {
        Vector3 direction = new Vector3(player.transform.position.x + x, player.transform.position.y + y, player.transform.position.z + z);
        transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * cameraFollowSpeed);
    }







}
