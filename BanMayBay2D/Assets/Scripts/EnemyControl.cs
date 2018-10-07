using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    float speed;
    public GameObject ExplosionGO;
    GameObject scoreUITextGO;
    // Use this for initialization
    void Start () {
        speed = 2f;
        //get the score text ui
        scoreUITextGO = GameObject.FindGameObjectWithTag("TextScoreTag");
	}
	
	// Update is called once per frame
	void Update () {
        // get the enemy currrent position
        Vector2 position = transform.position;
        //compute the enemy new position
        position = new Vector2(position.x , position.y -speed * Time.deltaTime);
        //update the enemy position
        transform.position = position;
        // bottom left point
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        // if the enemy outside bottom destroy  enemy
        if(transform.position.y > 10)
        {
            Destroy(gameObject);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "PlayerTag") || (collision.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            // add 100 point to the score
            scoreUITextGO.GetComponent<GameScore>().Score+=100;
            Destroy(gameObject);
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }
}
