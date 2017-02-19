using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storyText : MonoBehaviour {

	[SerializeField] List<string> text;
	[SerializeField] Text _canvasText;
	[SerializeField] float timeBetweenTextLines;
	int i=0;

	bool isFading;


	IEnumerator Start()
	{
		while(i!=text.Count)
		{
			_canvasText.text = text[i];

			isFading = false;
			yield return new WaitForSeconds((text[i].Length/20)*2.1f);
			isFading = true;
			i++;
			yield return new WaitForSeconds(1);
		}

	}

	void Update()
	{
		if(!isFading)
		{
			if(_canvasText.color.a <1)
				_canvasText.color += new Color(0,0,0,Time.deltaTime);
		}
		else{
			if(_canvasText.color.a >0)
				_canvasText.color -= new Color(0,0,0,Time.deltaTime);
		}


	}




}
