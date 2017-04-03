using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour {

    public static int dungeonLevel=1;
    [SerializeField] Text floorLevelText;
    bool isFading;


    IEnumerator Start()
    {
        //farget frame rate
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        floorLevelText.text = "Floor -" + (11-dungeonLevel).ToString("N0");
        yield return new WaitForSeconds(1f);
        isFading=true;

        // dungeonLevel = 3;
    }

    void Update()
    {
        if(floorLevelText.color.a > 0 && isFading)
            floorLevelText.color -= new Color(0,0,0,Time.deltaTime);
    }
    
}
