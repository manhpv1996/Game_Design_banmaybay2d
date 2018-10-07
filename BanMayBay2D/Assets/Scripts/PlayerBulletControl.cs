using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletControl : MonoBehaviour {

    float speed;
	// Use this for initialization
	void Start () {
        speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 position = transform.position;
        // compute the bullet new position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        // update the bullet position
        transform.position = position;
        //top right po of the screen
        if(transform.position.y < -18)
        {
            Destroy(gameObject);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "EnemyTag"))
        {
            Destroy(gameObject);
        }
    }
}
