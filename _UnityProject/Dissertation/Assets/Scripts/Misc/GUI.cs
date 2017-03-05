using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour {

	mcStats mc;

	[HeaderAttribute("Age")]
	[SerializeField]Image guiAge;
	[SerializeField]Text guiTextAge;

	[HeaderAttribute("Spirit")]
	[SerializeField]Image guiSpirit;

	[HeaderAttribute("Main Stats")]
	float total;
	[SerializeField]Text textKnowledge;
	[HeaderAttribute("Youthfulness")]
	[SerializeField]Image imageYouthfulness;
	[SerializeField]Text textYouthfulness;
	

	[HeaderAttribute("Fortitude")]
	[SerializeField]Image imageFortitude;
	[SerializeField]Text textFortitude;


	[HeaderAttribute("Wisdom")]
	[SerializeField]Image imageWisdom;
	[SerializeField]Text textWisdom;



	void Update()
	{
		if(mc == null)
				mc = GameObject.FindGameObjectWithTag("Player").GetComponent<mcStats>();

		if(mc!=null)
		{
			ShowInformation();
			ShowMainStats();
		}
	}

	void ShowInformation()
	{
			guiAge.rectTransform.localScale = new Vector3(Mathf.Clamp(mc.Age / 100f,0f,1f), 1f, 1f);
			guiAge.color = Color.Lerp(new Color32(88, 17,17, 255), new Color32(105, 82,82, 255), (mc.Age/100f));
			guiTextAge.text = "age " + (18f +mc.Age).ToString("N0");

			guiSpirit.transform.localScale = new Vector3(mc.Spirit(0) / mc.MaxSpirit, 1f, 1f);
	}


	void ShowMainStats()
	{
		//knowledge
		textKnowledge.text = mcStats.knowledge.ToString("N1");

		if(mc.Youthfulness() + mc.Wisdom() + mc.Fortitude()<10)
			total = 10;
		else
			total = mc.Youthfulness() + mc.Wisdom() + mc.Fortitude();

//			Debug.Log(total);

		//youthfulness
		imageYouthfulness.transform.localScale = new Vector3(mc.Youthfulness()/total,1f,1f);
		textYouthfulness.text = mc.Youthfulness().ToString("N1");

		//fortitude
		imageFortitude.transform.localScale = new Vector3(mc.Fortitude()/total,1f,1f);
		textFortitude.text = mc.Fortitude().ToString("N1");

		//wisdom
		imageWisdom.transform.localScale = new Vector3(mc.Wisdom()/total,1f,1f);
		textWisdom.text = mc.Wisdom().ToString("N1");
	}




}
