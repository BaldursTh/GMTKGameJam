using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Play, Pause, Ready, Death
}
public class GameManager : MonoBehaviour
{
    GameState gameState;
    public delegate void ChangeState();
    public event ChangeState OnPlay;
    public event ChangeState OnPause;
    
    private void Awake()
    {
        gameState = GameState.Ready;
        Time.timeScale = 0;

    }
    private void Update()
    {
        if (gameState == GameState.Ready)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
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
                
                Time.timeScale = 0;

            }
            else
            {
                gameState = GameState.Play;
                
                Time.timeScale = 1f;
            }           
        } 
        
    }

}
