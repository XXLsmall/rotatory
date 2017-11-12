using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadScript : MonoBehaviour {

    public string myName;

	void Start () {

        myName = PlayerPrefs.GetString("PlayerName");

        if(myName == "")
        {
            print("Nessun nome trovato!");
            SceneManager.LoadScene("NameRoom");
        }
        else
        {
            print("Bel nome, " + myName);
            SceneManager.LoadScene("Menu");
        }

	}

    

}
