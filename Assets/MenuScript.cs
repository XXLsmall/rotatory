using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    private void Start()
    {
        switch (Random.Range(1, 6))
        {
            case 1:
                Camera.main.backgroundColor = new Color32(113, 140, 202, 225);
                break;
            case 2:
                Camera.main.backgroundColor = new Color32(156, 110, 172, 225);
                break;
            case 3:
                Camera.main.backgroundColor = new Color32(208, 193, 73, 225);
                break;
            case 4:
                Camera.main.backgroundColor = new Color32(225, 126, 126, 225);
                break;
            case 5:
                Camera.main.backgroundColor = new Color32(86, 186, 124, 225);
                break;
        }
    }

    public void NormalGame()
    {
        SceneManager.LoadScene("RaceTrack");
    }

    public void SkinGame()
    {
        SceneManager.LoadScene("SkinSelectionRoom");
    }

    public void EvilGame()
    {
        SceneManager.LoadScene("EvilTrack");
    }
}
