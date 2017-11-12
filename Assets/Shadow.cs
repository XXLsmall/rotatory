using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

    public Vector2 offset = new Vector2(-0.1f, -0.1f);
    public float dim;
    SpriteRenderer sprRndCaster;
    SpriteRenderer sprRndShadow;

    Transform transCaster;
    Transform transShadow;

    

	void Start () {


        

        

        transCaster = transform;
        transShadow = new GameObject().transform;
        transShadow.localScale = new Vector3(dim , dim, dim);
        transShadow.parent = transCaster;
        transShadow.gameObject.name = "shadow";

        sprRndCaster = GetComponent<SpriteRenderer>();
        sprRndShadow = transShadow.gameObject.AddComponent<SpriteRenderer>();

        sprRndShadow.sortingLayerName = sprRndCaster.sortingLayerName;
        sprRndShadow.sortingOrder = sprRndCaster.sortingOrder - 1;

        sprRndShadow.GetComponent<SpriteRenderer>().color = Color.black;


    }
	
	
	void LateUpdate () {

       

        transShadow.localScale = new Vector3(1, 1, 1);

        transShadow.position = new Vector2(transCaster.position.x + offset.x, transCaster.position.y + offset.y);

        sprRndShadow.sprite = sprRndCaster.sprite;

	}
}
