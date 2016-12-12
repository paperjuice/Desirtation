using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingText : MonoBehaviour {

    [SerializeField] float textSpeed;
    [SerializeField] float fadeSpeed;
    private bool isFading;
    private TextMesh text;
    private float alpha=1;

    void Awake()
    {
        
        text = GetComponent<TextMesh>();
    }

    //IEnumerator Start()
    //{
    //    alpha = 1;
    //    yield return new WaitForSeconds(1f);
    //    print("asdasdasdasda");
    //    isFading = true;
    //}

    //private IEnumerator OnEnable()
    //{
    //    alpha = text.color.a;
    //    yield return new WaitForSeconds(1f);
    //    isFading = true;
    //}


    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * textSpeed;

        //if (isFading)
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha -= Time.deltaTime* fadeSpeed);

        if (alpha <= 0)
        {
            isFading = false;
            alpha = 1f;
            gameObject.SetActive(false);
        }
    }


}
