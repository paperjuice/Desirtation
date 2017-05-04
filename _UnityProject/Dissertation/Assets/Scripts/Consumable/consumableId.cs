using UnityEngine;

public class consumableId : MonoBehaviour {

	[SerializeField]int id;
	public int Id
	{
		get{return id;}
		set{id=value;}
	}


	void Update()
	{
		Rotate();
	}

	void Rotate()
	{
		transform.Rotate(Vector3.up * Time.deltaTime * 50f);
	}


}
