using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour {

    
    public int choosing ;
	
	void Start () {
        if(PlayerPrefs.GetInt("skin") == 0)
        {
            choosing = 1;
        }
        else
        {
            choosing = PlayerPrefs.GetInt("skin");
        }
        Camera.main.transform.position = new Vector3((PlayerPrefs.GetInt("skin") -1) * 5, 0, -10);
	}
	

    public void Left()
    {
        if(choosing != 1)
        {
            choosing--;
            Camera.main.transform.position =  new Vector3(Camera.main.transform.position.x - 5, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
    }

    public void Right()
    {
        if (choosing != 8)
        {
            choosing++;
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + 5, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
    }

    public void Selected()
    {
        PlayerPrefs.SetInt("skin", choosing);
        SceneManager.LoadScene("Menu");
    }


}
