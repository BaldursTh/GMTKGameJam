using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    GameState gameState;
    GameObject pause;
    GameObject blackHole;
    public Text timer;
    GameObject[] ready;
    float startTime;
    float endtime;
    float totalTime;
    public enum GameState
    {
        Play, Pause, Ready
    }
    private void Awake()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
        pause = GameObject.FindGameObjectWithTag("Pause");
        ready = GameObject.FindGameObjectsWithTag("Ready");
        gameState = GameState.Ready;
        pause.SetActive(false);
        blackHole = GameObject.FindGameObjectWithTag("BlackHole");
        
        

        

        Time.timeScale = 0;

    }
    private void Update()
    {
        if (gameState == GameState.Ready)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                gameState = GameState.Play;
                foreach(GameObject ready in ready)
                {
                    ready.SetActive(false);
                }
                Time.timeScale = 1f;
                startTime = Time.time;
                blackHole.GetComponent<AudioSource>().Play();
                
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                foreach (GameObject ready in ready)
                {
                    ready.SetActive(false);
                }
                gameState = GameState.Play;
                startTime = Time.time;
                Time.timeScale = 1f;
                blackHole.GetComponent<AudioSource>().Play();



            }
        }
        else 
        {
            HandleInput();
        }
       
        
    }
    public void Finish()
    {
        endtime = Time.time;
        totalTime = endtime - startTime;
        timer.text = "Time: " + (Mathf.Round(totalTime/0.01f)*0.01f).ToString() + " Seconds";
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameState == GameState.Play)
            {
                gameState = GameState.Pause;
                pause.SetActive(true);
                Time.timeScale = 0;
                

            }
            else
            {
                gameState = GameState.Play;
                pause.SetActive(false);
                Time.timeScale = 1f;
                
            }           
        } 
        
    }

}
