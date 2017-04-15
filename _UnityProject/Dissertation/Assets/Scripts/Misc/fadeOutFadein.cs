using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class fadeOutFadein : MonoBehaviour {

	[HeaderAttribute("Sound")][SerializeField] AudioSource exitSound;
	GameObject[] audioToMuteOnExit;
	bool isNotExiting = false;
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
		audioToMuteOnExit = GameObject.FindGameObjectsWithTag("audio");
	}

	void Update()
	{
		if(isFadeIn){
			if(img.color.a <1 )
				img.color += new Color(0f, 0f, 0f, Time.deltaTime * fadeSpeed);

			if(img.color.a>=1 && sceneName != string.Empty)
				SceneManager.LoadScene(sceneName);

			if(exitSound != null && !isNotExiting)
			{
				exitSound.Play();
				isNotExiting = true;
			}
			if(audioToMuteOnExit.Length != 0 && exitSound != null)
			{
				foreach(GameObject a in audioToMuteOnExit)
				{
					a.GetComponent<AudioSource>().volume -= 0.4f * Time.deltaTime;
				}
			}
		}
		else{
			if(img.color.a >0) 
				img.color -= new Color(0f, 0f, 0f, Time.deltaTime * fadeSpeed);
		}
	}





}
