using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private int min, sec;
    public static float actualTime;
    public TextMeshProUGUI UITimer;

    private void Awake()
    {
        actualTime = (min * 60) + sec;
    }
    private void Update()
    {
        actualTime -= Time.deltaTime;
        GameManager.instance.GetTimer(actualTime, UITimer);
    }

}
