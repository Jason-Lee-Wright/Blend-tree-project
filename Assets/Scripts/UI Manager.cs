using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MainMenu, PauseMenu, Gameplay, Options;

    private void Awake()
    {
        DissableAllUIPanels();

        MainMenu.SetActive(true);
    }

    public void EnablePause()
    {
        DissableAllUIPanels();

        PauseMenu.SetActive(true);
    }

    public void EnableMainMenu()
    {
        DissableAllUIPanels();

        MainMenu.SetActive(true);
    }

    public void EnableGameplay()
    {
        DissableAllUIPanels();

        Gameplay.SetActive(true);
    }

    public void EnableOptions()
    {
        DissableAllUIPanels();

        Options.SetActive(true);
    }

    public void DissableAllUIPanels()
    {
        MainMenu.SetActive(false);
        PauseMenu.SetActive(false);
        Gameplay.SetActive(false);
        Options.SetActive(false);
    }
}