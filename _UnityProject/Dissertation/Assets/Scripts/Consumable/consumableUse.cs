using UnityEngine;

public class consumableUse : MonoBehaviour {

    Transform parent;
	[SerializeField] int id;
    [SerializeField] GameObject floatingText;

    consumablePotency player;


    void Awake()
    {
        parent = gameObject.transform.parent;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<consumablePotency>();        
    }
    void OnMouseUpAsButton()
    {
       player.IncrementPassivePotency(id);
       Destroy(parent.gameObject);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E))
        {
            player.IncrementPassivePotency(id);
            floatingText.transform.parent = null;
            floatingText.gameObject.SetActive(true);
            floatingText.transform.rotation = Quaternion.Euler(65f,0f,0f);
            Destroy(parent.gameObject);
        }
    }
}
