using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class fadeOutFadein : MonoBehaviour {

	[SerializeField] string sceneName;
	[SerializeField] float fadeSpeed = 0.4f;
  	public string SceneName{
		get{return sceneName;}
		set{sceneName = value;}
	}
	[SerializeField]bool isFadeIn;
	Image img;

	void Awake(){
		img = GetComponent<Image>();
	}

	void Update()
	{
		if(isFadeIn){
			if(img.color.a <1 )
				img.color += new Color(0f, 0f, 0f, Time.deltaTime * fadeSpeed);

			if(img.color.a>=1 && sceneName != string.Empty)
				SceneManager.LoadScene(sceneName);
		}
		else{
			if(img.color.a >0) 
				img.color -= new Color(0f, 0f, 0f, Time.deltaTime * fadeSpeed);
		}
	}





}
