using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject HUDTimer;

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
        if (state == GameState.FindArtifacts)
        {
            timer.SetActive(true);
            HUDTimer.SetActive(true);
        }            

    }

    public void GetTimer(float actualTime, TextMeshProUGUI UITimer)
    {
        if (actualTime < 1)
        {
            UITimer.enabled = false;
        }
        int tempMin = Mathf.FloorToInt(actualTime / 60);
        int tempSec = Mathf.FloorToInt(actualTime % 60);
        UITimer.text = string.Format("{00:00}:{01:00}", tempMin, tempSec);
    }
}
