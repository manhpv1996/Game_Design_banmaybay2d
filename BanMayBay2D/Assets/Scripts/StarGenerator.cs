using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour {

    public GameObject StarGO;
    public int maxStars;
    Color[] starColors =
    {
        new Color(0.5f,0.5f,1f),// read
        new Color(0,1f,1f),// blue
        new Color(1f,1f,0),// yellow
        new Color(1f,0,0) // tim
    };
	// Use this for initialization
	void Start () {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));// bottom left point corner the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));// top right point corner the screen
        // loop for create stars
        for(int i =0; i< maxStars; ++i)
        {
            GameObject star = (GameObject)Instantiate(StarGO);
            //set star color
            star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];
            // set the position of the star (random x & random y)
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
            // set random speed for star
            star.GetComponent<Star>().speed = -(1f + Random.value + 0.5f);
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
