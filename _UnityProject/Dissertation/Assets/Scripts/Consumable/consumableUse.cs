using UnityEngine;

public class consumableUse : MonoBehaviour {

    Transform parent;
	[SerializeField] int id;

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
            Destroy(parent.gameObject);
        }
    }
}
