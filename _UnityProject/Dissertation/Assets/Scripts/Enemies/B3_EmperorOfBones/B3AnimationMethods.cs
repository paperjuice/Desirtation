using UnityEngine;

public class B3AnimationMethods : MonoBehaviour {

	
	[SerializeField] GameObject[] attacks = new GameObject[3];
	GameObject player;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public void InstantiateAttack1()
	{
		Instantiate(attacks[0], attacks[0].transform.position = transform.position + new Vector3(0,4.5f,0) + (transform.right *Random.Range(5f,10f)), attacks[0].transform.rotation);
		Instantiate(attacks[0], attacks[0].transform.position = transform.position + new Vector3(0,6f,0) + (transform.forward *Random.Range(7f,10f)), attacks[0].transform.rotation);

	}

	public void InstantiateAttack2()
	{
		Instantiate(attacks[1], attacks[1].transform.position= new Vector3(player.transform.position.x + (Random.Range(-3f,3f)), player.transform.position.y, player.transform.position.z + (Random.Range(-3f,3f))),  attacks[1].transform.rotation);
	}
	public void InstantiateAttack3()
	{
		Instantiate(attacks[2], attacks[2].transform.position= new Vector3(player.transform.position.x + (Random.Range(-8f,8f)), player.transform.position.y, player.transform.position.z + (Random.Range(-8f,8f))),  attacks[2].transform.rotation);
	}
}
