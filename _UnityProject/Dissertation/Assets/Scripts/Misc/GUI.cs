using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GUI : MonoBehaviour {

	mcStats mc;

	[HeaderAttribute("Age")]
	[SerializeField]Image guiAge;
	[SerializeField]Text guiTextAge;

	[HeaderAttribute("Spirit")]
	[SerializeField]Image guiSpirit;

	IEnumerator Start()
	{
		yield return new WaitForSeconds(0.1f);
		mc = GameObject.FindGameObjectWithTag("Player").GetComponent<mcStats>();
	}

	void Update()
	{
		if(mc!=null)
			ShowInformation();
	}

	void ShowInformation()
	{
		guiAge.rectTransform.localScale = new Vector3(Mathf.Clamp(mc.Age / 100f,0f,1f), 1f, 1f);
        guiAge.color = Color.Lerp(new Color32(88, 17,17, 255), new Color32(105, 82,82, 255), (mc.Age/100f));
        guiTextAge.text = "age " + (18f +mc.Age).ToString("N0");

        guiSpirit.transform.localScale = new Vector3(mc.Spirit(0) / mc.MaxSpirit, 1f, 1f);
	}


}
