using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public float speed;
    public GameObject PlayerBulletGO;
    public GameObject PlayerBulletPosition01;
    public GameObject PlayerBulletPosition02;
    public GameObject ExplosionGO;
    public GameObject GameManagerGO;//tham chiếu đến người quản lý trò chơi 
    // refer to the live ui text
    public Text LivesUIText;
    const int MaxLives = 3;
    int lives;
    public void Init()
    {
        lives = MaxLives;
        LivesUIText.text = lives.ToString();// update live uitext
        // đặt lại vị trí trình phát của màn hình
        transform.position = new Vector2(-5, -6);
        // đặt đối tượng trò chơi hoạt động 
        gameObject.SetActive(true);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")) {
            //GetComponent<AudioSource>().GetComponent<AudioSource>().Play();
            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
            bullet01.transform.position = PlayerBulletPosition01.transform.position;
            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
            bullet02.transform.position = PlayerBulletPosition02.transform.position;   

        }
        float x = Input.GetAxisRaw("Horizontal");//giá trị sẽ là -1,0,1 cho bên trái, không có đầu vào, phải
        float y = Input.GetAxisRaw("Vertical");//giá trị sẽ là -1,0,1 cho xuống, không có đầu vào, lên
        //tính toán một vector hướng, để có được vector đơn vị
        Vector2 direction = new Vector2(x, y).normalized;
        // chức năng gọi tính toán, đặt vị trí trình phát
        Movement(direction);
    }
    void Movement(Vector2 direction)
    {
        // Find the screen limit to the player movement(left , right , top , bottom edge of screen)
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));// bottom left point corner the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));// top right point corner the screen
        
        max.x = max.x -0.225f;// subtract the player sprite half width
        min.x = min.x+0.225f;// add the player sprite half width
        max.y = max.y-0.285f;// subtract the player sprite half height
        min.y = min.y +0.285f;// add the player sprite half height
        //Get the player current position
        Vector2 pos = transform.position;
        //Calculate the new position
        pos += direction * speed * Time.deltaTime;
        // Make sure the new positon is not outside screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y ,min.y, max.y);
        //update the player position
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "EnemyTag") || (collision.tag == "EnemyBulletTag")) {
            PlayExplosion();
            lives--;
            LivesUIText.text = lives.ToString();
            if(lives==0)
            {
                // change game manager state to game over state 
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOVer);
                // hide the player ship
                gameObject.SetActive(false);
            }
            
        }
    }

    // function to an instantie an explosion
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }
    
}
