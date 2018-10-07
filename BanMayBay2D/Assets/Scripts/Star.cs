using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // get the current position of star
        Vector2 position = transform.position;
        // compute the star new position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        //Update the star position
        transform.position = position;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));// bottom left point corner the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));// top right point corner the screen
                                                                          //if star go outside 
        if (transform.position.y < min.y)
        {
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }

    }
}
