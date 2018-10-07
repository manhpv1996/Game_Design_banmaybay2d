using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {
    public GameObject EnemyBulletGO;
	// Use this for initialization
	void Start () {
        Invoke("FireEnemyBullet",1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // function to fire an enemy bullet
    void FireEnemyBullet()
    {
        GameObject player = GameObject.Find("PlayerGO");
        if(player != null) // if player not dead
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);
            bullet.transform.position = transform.position;
            Vector2 direction = player.transform.position - bullet.transform.position;
            //set the bullet directioin
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
