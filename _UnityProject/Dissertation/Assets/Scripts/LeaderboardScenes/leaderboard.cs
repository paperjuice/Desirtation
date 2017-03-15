using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaderboard : MonoBehaviour {


    const string url="http://dreamlo.com/lb/";
    const string privateCode = "uGRV2lWEfE6dO716PctZUArCtBLjaV9kiK1G4mxbozZQ";
    const string publicCode = "588d286b6f15251b9c15171c";
    public Highscore[] highscoreList;
    List<string> listOfHighscores = new List<string>();

    public void GetScore(string username, float score){
        StartCoroutine(UploadHighScore(username, score));
    }

    void Awake()
    {
        StartCoroutine(DownloadScore());
    }



    IEnumerator UploadHighScore(string username, float score){
        WWW www = new WWW(url + privateCode + "/add/"+WWW.EscapeURL(username)+"/"+ Mathf.Ceil(score));
        yield return www;

        if(string.IsNullOrEmpty(www.error))
            Debug.Log("successful");
        else
            Debug.Log("Error: " + www.error);
    }

    IEnumerator DownloadScore()
    {
        WWW www = new WWW(url + publicCode + "/pipe/");
        yield return www;
        if(string.IsNullOrEmpty(www.error)){
            FormatText(www.text);
        }   
        else{
            Debug.Log("Error" + www.error);
        }
    }
	
    public List<string> FormatText(string textStream)
    {
        string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        highscoreList = new Highscore[entries.Length];

        for(int i = 0; i<entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[]{'|'});
            string username = entryInfo[0];
            float score = Mathf.Floor(float.Parse(entryInfo[1]));
            highscoreList[i] = new Highscore(username, score);
            listOfHighscores.Add((highscoreList[i].username + " - " + highscoreList[i].score.ToString("N0")).ToString());
            if(i>18)
                break;
        }
        return listOfHighscores;
    }

    public List<string> ShowLeaderboard()
    {
        return listOfHighscores;
    }

}

public struct Highscore
{
    public string username;
    public float score;

    public Highscore(string _username, float _score)
    {
        username = _username;
        score = _score;
    }
}
