using System;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum GameState
{
    FindKey,
    OpenAttic,
    FindArtifacts,
    Escape
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static event Action<GameState> OnGameStateChanged;
    public GameState state;
    [SerializeField] private MissionManager missionManager;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private BookManager bookManager;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        UpdateGameState(GameState.FindKey);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        //switch (newState)
        //{
        //    case GameState.FindKey:
        //        HandleFindKey();
        //        break;
        //    case GameState.OpenAttic:
        //        //HandleOpenAttic();
        //        break;
        //    case GameState.FindArtifacts:
        //        //HandleFindArtifacts();
        //        break;
        //    case GameState.Escape:
        //        HandleEscape();
        //        break;
        //}

        OnGameStateChanged?.Invoke(newState);

    }
    public void HandleFindKey()

    {
       //nada
    }

    public void HandleOpenAttic(Mission mission)  
    {
        mission.CompleteMission();
        //enable attic door - se habilita en la clase abstracta interactable
    }

    public void HandleFindArtifacts(Mission mission)
    {
        mission.CompleteMission();
        //disable mission text 2
        //enable mission text 3
        //enable enemy
        //enable timer
        //enable HUD
        //enable collectable books

    }

    public void HandleEscape(Mission mission)
    {
        mission.CompleteMission();

        //RESTA HACER ESCENA DE ESCAPE Y YA ESTARIA TODO PERRO
        //missionManager.CompleteMission(3);
        //disable mission text 3
        //enable escape text
        //enable entrance door  
    }


    public void GetTimer(float actualTime, TextMeshProUGUI UITimer)
    {
        timeManager.GetTimer(actualTime, UITimer);
    }

    public void AddBook(Pickable book)
    {        
        bookManager.AddBook(book);
    }

    public int GetBookCount()
    {
       return bookManager.GetBookCount();
    }

}
