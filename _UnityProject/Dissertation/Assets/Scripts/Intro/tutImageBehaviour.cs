using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutImageBehaviour : MonoBehaviour {

	
	[SerializeField] Image img;
	float alpha;
	[SerializeField] bool inRange;
	[SerializeField] KeyCode key; 




	void Update()
	{
		ImageOpacity();
		ActivateOnKeyPress();

		if(inRange)
		{
			if(alpha<1)
				alpha += Time.deltaTime;
		}else
		{
			if(alpha>0)
				alpha -= Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
			inRange = true;
	}
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
			inRange = false;
	}


	void ImageOpacity()
	{

		img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
	}

	void ActivateOnKeyPress()
	{
		if(Input.GetKeyDown(key))
			inRange =false;

	}



}
