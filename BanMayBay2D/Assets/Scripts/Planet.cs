using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float speed;// speed of planet
    public bool isMoving;// flag make the planet scroll down the screen
    Vector2 min, max;
    // Use this for initialization
    void Start()
    {
        isMoving = false;
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));// bottom left point corner the screen
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));// top right point corner the screen
        // add the planet sprite half height to max y
        max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
        // subtract the planet sprite half height to min y
        min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
            return;
        //get the current position
        Vector2 position = transform.position;
        //compute new position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        //Update planet position
        transform.position = position;
        //if the planet get minimum y position then stop moving the planet
        if(transform.position.y < min.y)
        {
            isMoving = false;
        }

    }
    public void ResetPosition()
    {
        transform.position = new Vector2(Random.Range(min.x,max.x),max.y);

    }

}
