using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour {

    public static int dungeonLevel=1;
    [SerializeField] Text floorLevelText;
    bool isFading;


    IEnumerator Start()
    {
        floorLevelText.text = "Floor " + (100-dungeonLevel).ToString("N0");
        yield return new WaitForSeconds(1f);
        isFading=true;
    }

    void Update()
    {
        if(floorLevelText.color.a > 0 && isFading)
            floorLevelText.color -= new Color(0,0,0,Time.deltaTime);
    }
    
}
