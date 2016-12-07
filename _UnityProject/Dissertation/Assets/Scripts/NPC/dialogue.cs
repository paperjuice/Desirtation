using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue : MonoBehaviour {

    [SerializeField]private Animator _anim;
    [SerializeField]private GameObject[] dialoguesGO;
    [SerializeField] private GameObject speakToText;      //the text shown when you are close enough to an NPC and you can talk

    
    private GameObject player;
    private GameObject dialogueFather;
    private int i = 0;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogueFather = GameObject.FindGameObjectWithTag("dialogueFather");

    }
    
    void Update()
    {
        ActivateDialogue();
    }

    void ActivateDialogue()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3)
        {
            if (i % 2 == 0 && i != 0)
                _anim.SetBool("talking", true);
            else
                _anim.SetBool("talking", false);


            RotateTowards();
            speakToText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                


                if (i >= dialoguesGO.Length)
                {
                    dialoguesGO[i - 1].gameObject.SetActive(false);
                    _anim.SetBool("talking", false);
                    foreach (GameObject a in dialoguesGO)
                        a.transform.parent = null;
                    i = 0;
                }
                else
                {
                    dialoguesGO[i].gameObject.SetActive(true);
                    dialoguesGO[i].transform.parent = dialogueFather.transform;
                    dialoguesGO[i].transform.localPosition = Vector3.zero;
                    dialoguesGO[i].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

                    if (i >= 1)
                        dialoguesGO[i - 1].gameObject.SetActive(false);
                    i++;
                }
            }
        }
        else 
        {
            speakToText.gameObject.SetActive(false);
            foreach (GameObject a in dialoguesGO)
            {
                a.transform.parent = null;
                a.gameObject.SetActive(false);
                i = 0;
                _anim.SetBool("talking", false);
            }
        }
    }

    void RotateTowards()
    {

        Vector3 direction = player.transform.position - transform.position;

        Quaternion lerp = Quaternion.LookRotation(direction, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, lerp, Time.deltaTime * 5f);

    }
}
