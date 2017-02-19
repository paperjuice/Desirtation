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
    float cameraSpeed=1f; //this value is the value used in the beginning of the game when the camera zooms out
    [HeaderAttribute("Normal Mode")]
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;

    [HeaderAttribute("Boss Mode")]
    [SerializeField] float xB;
    [SerializeField] float yB;
    [SerializeField] float zB;
    bool isBossMode;
    public bool IsBossMode{
        get{return isBossMode;}
        set{isBossMode = value;}
    }

    void FixedUpdate()
    {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if(!isBeginning)
        {
            if(!isBossMode)
                CameraFollow();
            else
                CameraFollowBossMode();

            if(cameraSpeed<cameraFollowSpeed)
                cameraSpeed += Time.deltaTime;
        }
    }

    void CameraFollow()
    {
        Vector3 direction;

        if(player != null)
        {
            direction = new Vector3(player.transform.position.x + x, player.transform.position.y + y, player.transform.position.z + z);
            transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * cameraSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(60,0,0), Time.deltaTime * 1.5f );
        }
    }

    void CameraFollowBossMode()
    {
        Vector3 direction;
        if(player != null)
        {
            direction = new Vector3(player.transform.position.x + xB, player.transform.position.y + yB, player.transform.position.z + zB);
            transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * cameraSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(69,0,0), Time.deltaTime * 1.5f );
        }
    }


}
