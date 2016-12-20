using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcQuestGiver : MonoBehaviour {

	[SerializeField] private bool isQuestAvailable;
	[SerializeField] private int questId;

    private unlockQuest _unlockQuest;
    private GameObject player;


    void Awake()
    {
        if(_unlockQuest!=null)
            _unlockQuest = GameObject.FindGameObjectWithTag("quest").GetComponent<unlockQuest>();
        player = GameObject.FindGameObjectWithTag("Player");
    }



    void Update()
	{
        if (isQuestAvailable)
            if (Vector3.Distance(transform.position, player.transform.position) < 3)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _unlockQuest._questId = questId;

                }
            }
    }



}
