using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour {


    private float currentTimeDuration;
    [SerializeField]private float endTimeDuration;




    private void Update()
    {
        currentTimeDuration += Time.deltaTime;

        if (currentTimeDuration >= endTimeDuration)
        {
            gameObject.SetActive(false);
            currentTimeDuration = 0f;
        }
    }
    
}
