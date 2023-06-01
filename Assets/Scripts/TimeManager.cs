using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
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
