using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinApplier : MonoBehaviour {


    public GameObject[] skins;

	void Start () {

        foreach(GameObject skin in skins)
        {
            skin.SetActive(false);
        }

        int n = PlayerPrefs.GetInt("skin");

        for(int i = 1; i < skins.Length; i++)
        {
            skins[n - 1].SetActive(true);
        }
	}
	
	
}
