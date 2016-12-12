using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingTextController : MonoBehaviour {


    GameObject[] floatingText;
    private GameObject _camera;


    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }


    IEnumerator Start()
    {
        while (true)
        {
            floatingText = GameObject.FindGameObjectsWithTag("floatingText");
            yield return new WaitForSeconds(0.1f);
        }

    }

    void Update()
    {
        foreach (GameObject a in floatingText)
        {
            if (a != null)
            {
                a.transform.position += Vector3.up * Time.deltaTime * 1f;
                a.transform.LookAt(_camera.transform.position);
                a.GetComponent<TextMesh>().color -= new Color(0, 0, 0, 1) * Time.deltaTime;



                a.GetComponent<MeshRenderer>().enabled = true;


                if (a.GetComponent<TextMesh>().color.a <= 0)
                    Destroy(a);
            }
        }


    }
}
