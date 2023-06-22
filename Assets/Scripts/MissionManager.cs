using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class MissionManager : MonoBehaviour
{
    // public List<Mission> missions = new(); // Lista de misiones
    [SerializeField] private Mission mission;
    [SerializeField] private GameObject enemy;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
        
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }
    private void GameManagerOnGameStateChanged(GameState state)
    {
        //if (state == GameState.OpenAttic)
        //    GameManager.instance.HandleOpenAttic(mission);
        //if (state == GameState.FindArtifacts)
        //{
        //    //enemy.SetActive(true);
        //    GameManager.instance.HandleFindArtifacts(mission);
        //}
        //if(state == GameState.Escape)
        //{
        //    GameManager.instance.HandleEscape(mission);
        //}

        switch (state)
        {            
            case GameState.OpenAttic:
                GameManager.instance.HandleOpenAttic(mission);
                break;
            case GameState.FindArtifacts:
                //enemy.SetActive(true);
                GameManager.instance.HandleFindArtifacts(mission);
                break;
            case GameState.Escape:
                GameManager.instance.HandleEscape(mission);
                break;
        }

    } 
}

