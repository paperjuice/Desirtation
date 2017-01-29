using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaderboard : MonoBehaviour {


    const string url="http://dreamlo.com/lb/";
    const string privateCode = "uGRV2lWEfE6dO716PctZUArCtBLjaV9kiK1G4mxbozZQ";
    const string publicCode = "588d286b6f15251b9c15171c";
    public Highscore[] highscoreList;
  


    void Awake()
    {
        GetScore("ana", 3);
        GetScore("andrei", 5);
        GetScore("dan", 9);

        StartCoroutine(DownloadScore());
    }

    public void GetScore(string username, int score){
        StartCoroutine(UploadHighScore(username, score));
    }



    IEnumerator UploadHighScore(string username, int score){
        WWW www = new WWW(url + privateCode + "/add/"+WWW.EscapeURL(username)+"/"+score);
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
            Debug.Log(www.text);
            FormatText(www.text);
        }   
        else{
            Debug.Log("Error" + www.error);
        }
    }
	
    void FormatText(string textStream)
    {
        string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        highscoreList = new Highscore[entries.Length];

        for(int i = 0; i<entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[]{'|'});
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoreList[i] = new Highscore(username, score);
            Debug.Log( highscoreList[i].username + " : " + highscoreList[i].score );
        }

    }
}

public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}
