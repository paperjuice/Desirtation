using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class useConsumable : MonoBehaviour {

    [SerializeField]int id;
    public int Id{
        get{return id;}
        set{id = value;}
    }
    [SerializeField]GameObject slotPosition;
    public GameObject SlotPosition{
        get{return slotPosition;}
        set{slotPosition = value;}
    }


    public void UseConsumable()
    {
        foreach(Transform child in SlotPosition.transform.parent)
            Destroy(child.gameObject);
    }

    public void ChangeColor()
    {
        print("dasdafsdavds");
        GetComponent<Image>().color = Color.red;
    }

}
