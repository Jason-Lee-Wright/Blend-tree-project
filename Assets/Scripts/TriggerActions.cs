using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActions : MonoBehaviour
{
    public string SpawnPoint;
    public string SceneLoad;

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            ActionEvents.TriggerScene.Invoke(SpawnPoint, SceneLoad);
        }
    }
}

static class ActionEvents
{
    public static Action<string, string> TriggerScene;
}