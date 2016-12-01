using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue : MonoBehaviour {

    [SerializeField]private GameObject[] dialoguesGO;
    [SerializeField] private GameObject speakToText;      //the text shown when you are close enough to an NPC and you can talk

    private GameObject player;
    private GameObject dialogueParent;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogueParent = GameObject.FindGameObjectWithTag("dialogueFather");
    }

    void Update()
    {
        ActivateDialogue();
    }

    void ActivateDialogue()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3)
        {
            speakToText.gameObject.SetActive(true);

            

        }
        else 
        {
            speakToText.gameObject.SetActive(false);
        }
    }
}
