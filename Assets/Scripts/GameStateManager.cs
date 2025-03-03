using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameManager gameManager;

    // Enum representing different game states
    public enum GameState
    {
        MainMenu_State,
        Gameplay_State,
        Paused_State,
        Options_State
    }

    public GameState currentState { get; private set; }

    [SerializeField] private string currentStateDebug;
    [SerializeField] private string lastStateDebug;

    public GameState LastState;

    private void Start()
    {
        ChangeState(GameState.MainMenu_State);
    }

    public void ChangeState(GameState newState)
    {
        lastStateDebug = currentState.ToString();
        LastState = currentState;

        currentState = newState;

        HandleStateChange(newState);

        currentStateDebug = currentState.ToString();
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (currentState == GameState.Gameplay_State || currentState == GameState.Paused_State))
        {
            if (currentState == GameState.Paused_State)
            {
                ChangeState(GameState.Gameplay_State);
            }
            else
            {
                ChangeState(GameState.Paused_State);
            }
        }
    }

    private void HandleStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu_State:
                Debug.Log("Switched to MainMenu State");

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                gameManager.UIManager.EnableMainMenu();

                Time.timeScale = 0;
                break;

            case GameState.Gameplay_State:
                Debug.Log("Switched to Gameplay State");

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                gameManager.UIManager.EnableGameplay();

                Time.timeScale = 1;
                break;

            case GameState.Paused_State:
                Debug.Log("Switched to Paused State");

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                gameManager.UIManager.EnablePause();

                Time.timeScale = 0;
                break;

            case GameState.Options_State:
                Debug.Log("Switched to Options State");

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                gameManager.UIManager.EnableOptions();

                Time.timeScale = 0;
                break;
        }
    }
}