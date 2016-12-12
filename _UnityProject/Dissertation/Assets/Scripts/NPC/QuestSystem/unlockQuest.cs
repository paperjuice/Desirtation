using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockQuest : MonoBehaviour {

    [SerializeField] GameObject[] listOfQuests;
    public int _questId;


    private Vector3 i = new Vector3(0f,1.3f,0f);  //the position of the quest in the tab
    private bool isOpened=true;
    private mcMovementBehaviour _mcMovementBehaviour;


    void Awake()
    {
        _mcMovementBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<mcMovementBehaviour>();
    }

    void Update()
    {
        UnlockQuestsBasedOnId();
        Opened();
    }

    void Opened()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            if (isOpened)
            {
                isOpened = false;
                transform.localPosition = new Vector3(0f, 0f, 0f);
            }
            else
            {
                isOpened = true;
                transform.localPosition = new Vector3(-15f, 0f, 4f);
            }

    }

    void UnlockQuestsBasedOnId()
    {
        switch (_questId)
        {
            case 1:
                if (!listOfQuests[0].gameObject.activeInHierarchy)
                {
                    listOfQuests[0].gameObject.SetActive(true);
                    listOfQuests[0].transform.localPosition = i;
                    i -= new Vector3(0f, 0.2f, 0f);
                    _questId = 0;
                }
                break;
            case 2:
                if (!listOfQuests[1].gameObject.activeInHierarchy)
                {
                    listOfQuests[1].gameObject.SetActive(true);
                    listOfQuests[1].transform.localPosition = i;
                    i -= new Vector3(0f, 0.2f, 0f);
                    _questId = 0;
                }
                break;
            case 3:
                if (!listOfQuests[2].gameObject.activeInHierarchy)
                {
                    listOfQuests[2].gameObject.SetActive(true);
                    listOfQuests[2].transform.localPosition = i;
                    i -= new Vector3(0f, 0.2f, 0f);
                    _questId = 0;
                }
                break;
            case 4:
                if (!listOfQuests[3].gameObject.activeInHierarchy)
                {
                    listOfQuests[3].gameObject.SetActive(true);
                    listOfQuests[3].transform.localPosition = i;
                    i -= new Vector3(0f, 0.2f, 0f);
                    _questId = 0;
                }
                break;
        }
    }



}
