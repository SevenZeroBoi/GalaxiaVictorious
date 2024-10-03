using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour
{
    public static StatesManager instance;

    public GameStatesList currentGameStates;
    public enum GameStatesList
    {
        DIALOGUE, VICTORY, PLAYING
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("tak 1 souy p syou");
        }
        instance = this;
    }

}
