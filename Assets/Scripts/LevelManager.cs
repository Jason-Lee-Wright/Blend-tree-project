using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Spawnpoint;

    private string SpawnName;


    void OnEnable()
    {
        ActionEvents.TriggerScene += Triggered;
    }

    private void Triggered(string Spawn, string Scene)
    {

        SceneManager.sceneLoaded += OnSceneLoaded;

        SpawnName = Spawn;

        SceneManager.LoadScene(Scene);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Spawnpoint = GameObject.Find(SpawnName);

        Player.transform.position = Spawnpoint.transform.position;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
