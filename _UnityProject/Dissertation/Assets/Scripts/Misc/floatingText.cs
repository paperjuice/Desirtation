using UnityEngine;

public class floatingText : MonoBehaviour {

    [SerializeField] float textSpeed;
    [SerializeField] float fadeSpeed;
    //private bool isFading;
    private TextMesh text;
    private float alpha=1;
    Transform rememberFather;

    void Awake()
    {
        text = GetComponent<TextMesh>();
        rememberFather = transform.parent;
    }

    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * textSpeed;
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha -= Time.deltaTime* fadeSpeed);
        if (alpha <= 0)
        {
            //isFading = false;
            alpha = 1f;
            transform.parent = rememberFather;
            gameObject.SetActive(false);
        }
    }


}
