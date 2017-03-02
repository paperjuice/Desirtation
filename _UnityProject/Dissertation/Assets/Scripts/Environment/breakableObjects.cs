using System.Collections;
using UnityEngine;

public class breakableObjects : MonoBehaviour {

	
    [SerializeField] private GameObject[] parts;
    [SerializeField] float force;

    [HeaderAttribute("Consumables")]
    [SerializeField] float destructibleDropChance = 3f;
    [HeaderAttribute("Level1")]
    [SerializeField]GameObject[] levelOneConsumable;
    [HeaderAttribute("Level2")]
    [SerializeField]GameObject[] levelTwoConsumable;
    [HeaderAttribute("Level3")]
    [SerializeField]GameObject[] levelThreeConsumable;

    float chanceToGetItem;
    private Animator _camera;
    private GameObject player;
    bool isExploding;

    void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        StartCoroutine(FindPlayer());
    }

    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mcWeapon")
            isExploding = true;
    }

    void Update()
    {
        if (isExploding)
        {
            foreach (GameObject p in parts)
            {
                _camera.SetTrigger("shake");
                p.GetComponent<Rigidbody>().isKinematic = false;
                p.GetComponent<BoxCollider>().enabled = true;
                p.GetComponent<Rigidbody>().AddExplosionForce(force * Random.Range(0.6f, 1.1f), player.transform.position, 25f, 2f, ForceMode.Force);
                GetComponent<Collider>().enabled = false;
                p.transform.parent = null;
            }
            DropItem();
            isExploding = false;
            gameObject.SetActive(false);
        }
    }

    void DropItem()
    {
        chanceToGetItem = Random.Range(1f,100f);
        if(chanceToGetItem <= destructibleDropChance)
        {
            var dropQuality = Random.Range(1f, 100f);

                if (dropQuality <= 70f)
                    Instantiate(levelOneConsumable[Random.Range(0, levelOneConsumable.Length)], transform.position, transform.rotation);
                else if (dropQuality > 70 && dropQuality <= 95)
                    Instantiate(levelTwoConsumable[Random.Range(0, levelTwoConsumable.Length)], transform.position, transform.rotation);
                else if (dropQuality > 95 && dropQuality <= 100)
                    Instantiate(levelThreeConsumable[Random.Range(0, levelThreeConsumable.Length)], transform.position, transform.rotation);
        }
    }

}
