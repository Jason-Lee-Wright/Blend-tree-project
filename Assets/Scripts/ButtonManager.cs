using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStateManager;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject Player;

    public void PlayB()
    {
        SceneManager.LoadScene("Left Scene");

        Player.transform.position = new Vector3(-7, 2, -4);
        
        gameManager.StateManager.ChangeState(GameState.Gameplay_State);
    }

    public void QuitB()
    {
        Application.Quit();
    }

    public void MainMenuB()
    {
        SceneManager.LoadScene("Main Menu");

        gameManager.StateManager.ChangeState(GameState.MainMenu_State);
    }

    public void ResumeB()
    {
        gameManager.StateManager.ChangeState(GameState.Gameplay_State);
    }

    public void OptionsB()
    {
        gameManager.StateManager.ChangeState(GameState.Options_State);
    }

    public void ReturnB()
    {
        gameManager.StateManager.ChangeState(gameManager.StateManager.LastState);
    }
}
