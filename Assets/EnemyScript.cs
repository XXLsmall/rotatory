using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float speed;
    SpriteRenderer spr;
    public int dir;

	
	void Start () {

        spr = GetComponentInChildren<SpriteRenderer>();

        speed = Random.Range(50, 200);
        float n = Random.value;
        if(n < 0.5f)
        {
            dir = -1;
            spr.gameObject.transform.localScale = new Vector3(-spr.gameObject.transform.localScale.x, spr.gameObject.transform.localScale.x, spr.gameObject.transform.localScale.x);
        }
        else
        {
            dir = 1;
            spr.gameObject.transform.localScale = new Vector3(spr.gameObject.transform.localScale.x, spr.gameObject.transform.localScale.x, spr.gameObject.transform.localScale.x);
        }
	}
	
	
	void Update () {

        transform.Rotate(Vector3.back * speed * dir *  Time.deltaTime);

    }
}
