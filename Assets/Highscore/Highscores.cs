using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highscores : MonoBehaviour {

	public string privateCode = ""; //normale BaekhKeVDUCQG4WPqji6QwUwlttAtaf0aiptECNADQBQ //evil KIhvX5x_Lk-Oq-a5EckboALItBdO57g0a5Y6PYt9Scig
    public string publicCode = ""; // normale 5a032fe86b2b657b785cff0f //evil 5a072d816b2b651180fc5c2e
    const string webURL = "http://dreamlo.com/lb/";
    public string highscore = "highscore";
	DisplayHighscores highscoreDisplay;
    public Highscore[] highscoresList;
	static Highscores instance;

    
    public GameObject scoreText;

    string _username;

    void Awake() {

        
		highscoreDisplay = GetComponent<DisplayHighscores> ();
		instance = this;
        
    }

    public void AddMyScore()
    {
        
        _username = PlayerPrefs.GetString("PlayerName");
        
        int _score = int.Parse(scoreText.GetComponent<TextMesh>().text);
        AddNewHighscore(_username, _score);
    }

	public static void AddNewHighscore(string username, int score) {
		instance.StartCoroutine(instance.UploadNewHighscore(username,score));
	}

	IEnumerator UploadNewHighscore(string username, int score) {
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error)) {
			//print ("Upload Successful");
			DownloadHighscores();
		}
		else {
			print ("Error uploading: " + www.error);
		}
	}

	public void DownloadHighscores() {
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase() {
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error)) {
			FormatHighscores (www.text);
			highscoreDisplay.OnHighscoresDownloaded(highscoresList);
		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username,score);
            //print (highscoresList[i].username + ": " + highscoresList[i].score);
            

            if (highscoresList[i].username == PlayerPrefs.GetString("PlayerName"))
            {
                
                PlayerPrefs.SetInt(highscore, highscoresList[i].score);
            }
        }
	}

}

public struct Highscore {
	public string username;
	public int score;

	public Highscore(string _username, int _score) {
		username = _username;
		score = _score;
	}

}
