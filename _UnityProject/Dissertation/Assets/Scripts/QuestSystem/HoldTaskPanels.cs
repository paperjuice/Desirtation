
using UnityEngine;

public class HoldTaskPanels : MonoBehaviour {
	[SerializeField] GameObject[] taskPanels;
	public GameObject[] TaskPanels{
		get{return taskPanels;}
		set{taskPanels = value;}
	}
}
