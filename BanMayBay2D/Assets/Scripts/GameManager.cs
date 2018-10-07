using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // reference to our  game object
    public GameObject scoreUITextGO;
    public GameObject GameTittleGO;
    public GameObject gameOverGO;// ref game over image
    public GameObject playButton;
    public GameObject playeShip;
    public GameObject enemySpawner;// ref to our enemy spawner
    public GameObject TimeCounterGO;
    public enum GameManagerState
    {
        Opening,
        GamePlay,
        GameOVer
    }
    GameManagerState GMState;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // function to update game manager state
    void updateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                GameTittleGO.SetActive(true);
                //hide game over 
                gameOverGO.SetActive(false);
                //set player button visible
                playButton.SetActive(true);
                break;
            case GameManagerState.GamePlay:
                //hide game tittle
                GameTittleGO.SetActive(false);
                // reset the score
                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                //hide play button
                playButton.SetActive(false);
                playeShip.GetComponent<PlayerControl>().Init();
                //start enymy spawner
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                //start time
                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();
                break;
            case GameManagerState.GameOVer:
                //stop time counter
                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();

                //stop enemy spawner
                enemySpawner.GetComponent<EnemySpawner>().UnScheduledEnemySpawn();

                // display the game over
                gameOverGO.SetActive(true);

                //change game manager state to Open state after 8 seconds
                Invoke("ChangeToOpeningState", 4f);

                break;
        }
    }
    // function to set the game manager state
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        updateGameManagerState();
    }
    // play bbutton onclick
    public void startGamePlay()
    {
        GMState = GameManagerState.GamePlay;
        updateGameManagerState();
    }
    // function to change game manager state to opening state
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
