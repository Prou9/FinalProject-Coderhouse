using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Narcolepsy : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject sleepText;
    [SerializeField] private float decreaseAmount = 2f;
    [SerializeField] private float decreaseInterval = 0.1f;
    [SerializeField] private float increaseAmount = 50f;
    [SerializeField] private float waitTime = 5f;

    private float timer;
    private bool isWaiting;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        timer = decreaseInterval;
        isWaiting = false;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f && !isWaiting)
        {
            DecreaseTransparency();
            timer = decreaseInterval;
        }

        if (Input.GetMouseButtonDown(0) && image.color.a > 0 && !sleepText.activeSelf)
        {
            IncreaseTransparency();
        }
    }

    private void DecreaseTransparency()
    {
        Color currentColor = image.color;
        currentColor.a += decreaseAmount / 255f;
        image.color = currentColor;

        if (currentColor.a >= 1)
        {
            SetGrayImage();
            playerController.enabled = false;
            isWaiting = true;
            Invoke(nameof(ResetWaiting), waitTime);
        }
    }

    private void IncreaseTransparency()
    {
        Color currentColor = image.color;
        currentColor.a -= increaseAmount / 255f;
        currentColor.a = Mathf.Max(0f, currentColor.a);
        image.color = currentColor;

        if (currentColor.a <= 0)
        {
            isWaiting = true;
            Invoke(nameof(ResetWaiting), waitTime);
        }
    }
    private void SetGrayImage()
    {
        image.color = Color.gray;
        sleepText.SetActive(true);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 180f / 255f);
    }

    private void ResetWaiting()
    {
        image.color = new Color(0, 0, 0, 0);
        playerController.enabled = true;
        sleepText.SetActive(false);
        isWaiting = false;
    }
}
