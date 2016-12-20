using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatingSystem : MonoBehaviour {


    [Header("Condition")]
    [SerializeField] GameObject[] condition;

    [Header("Gates")]
	[SerializeField] GameObject[] fromGroundGates;
    private Vector3[] startingPos;
    [SerializeField] private bool isActivated;


    void Start()
    {
        startingPos = new Vector3[fromGroundGates.Length];

        for (int i = 0; i < fromGroundGates.Length; i++)
        {
            startingPos[i] = fromGroundGates[i].transform.localPosition;
        }
    }

    void Update()
    {
        if (isActivated)
        {
            foreach (GameObject c in condition)
            {
                if (!c.gameObject.activeInHierarchy)
                {
                    isActivated = false;
                }
            }


            foreach (GameObject g in fromGroundGates)
            {
                g.transform.localPosition = Vector3.Lerp(g.transform.localPosition, new Vector3(0f, 0f, 0f), Time.deltaTime * 1f);
            }
        }
        else
        {
            for(int i = 0;i< fromGroundGates.Length; i++)
            {
                fromGroundGates[i].transform.localPosition = Vector3.Lerp(fromGroundGates[i].transform.localPosition, startingPos[i], Time.deltaTime * 2.5f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isActivated = true;

            foreach (GameObject c in condition)
            {
                c.gameObject.SetActive(true);
            }
        }
    }



}
