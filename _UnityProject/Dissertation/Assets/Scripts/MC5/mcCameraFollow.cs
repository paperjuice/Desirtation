using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mcCameraFollow : MonoBehaviour {


    private GameObject player;
    private Vector3 offset;
    private Vector3 savedPos;
    [SerializeField] bool isBeginning;
    public bool IsBiginning
    {
        get{return isBeginning;}
        set{isBeginning=value;}
    }
    [SerializeField] float cameraFollowSpeed;
    float cameraSpeed=1f; //this value is the value used in the beginning of the game 
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        //offset = transform.position - player.transform.position;
        
    }

    void FixedUpdate()
    {
        //savedPos = player.transform.position + offset;
        //transform.position = Vector3.Lerp(transform.position, savedPos, Time.deltaTime * cameraFollowSpeed);




        if(!isBeginning)
        {
            CameraFollow2();
            if(cameraSpeed<cameraFollowSpeed)
                cameraSpeed += Time.deltaTime;
        }
    }




    void CameraFollow2()
    {
        Vector3 direction = new Vector3(player.transform.position.x + x, player.transform.position.y + y, player.transform.position.z + z);
        transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * cameraSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(69,0,0), Time.deltaTime * 1.5f );
    }


    





}
