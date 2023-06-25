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
            //DontDestroyOnLoad(gameObject); commented in order to avoid concurrence issues
        }
    }
    private void Start()
    {
        UpdateGameState(GameState.FindKey);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        OnGameStateChanged?.Invoke(newState);

    } 
    public void HandleOpenAttic(Mission mission)  
    {
        mission.CompleteMission();
    }

    public void HandleFindArtifacts(Mission mission)
    {
        mission.CompleteMission();       
    }

    public void HandleEscape(Mission mission)
    {
        mission.CompleteMission();
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
