using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Play, Pause, Ready
}
public class GameManager : MonoBehaviour
{
    GameState gameState;
    GameObject pause;
    GameObject[] ready;
    
    private void Awake()
    {

        pause = GameObject.FindGameObjectWithTag("Pause");
        ready = GameObject.FindGameObjectsWithTag("Ready");
        gameState = GameState.Ready;
        pause.SetActive(false);
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
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                foreach (GameObject ready in ready)
                {
                    ready.SetActive(false);
                }
                gameState = GameState.Play;

                Time.timeScale = 1f;

            }
        }
        else 
        {
            HandleInput();
        }
        
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
