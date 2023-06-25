using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class MissionManager : MonoBehaviour
{  
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
        switch (state)
        {            
            case GameState.OpenAttic:
                GameManager.instance.HandleOpenAttic(mission);
                break;
            case GameState.FindArtifacts:
                enemy.SetActive(true);
                GameManager.instance.HandleFindArtifacts(mission);
                break;
            case GameState.Escape:
                GameManager.instance.HandleEscape(mission);
                break;
        }

    } 
}

