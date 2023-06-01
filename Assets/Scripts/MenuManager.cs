using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject creditsView;
    [SerializeField] private GameObject howToPlayView;

    public void PlayGame()
    {
        string sceneName = "MainTitles";
        SceneManager.LoadScene(sceneName);

    }

    public void HowToPlay()
    {
        if (howToPlayView.activeSelf)
        {
            howToPlayView.SetActive(false);
        }
        else if (!creditsView.activeSelf)
        {
            howToPlayView.SetActive(true);
        }

    }

    public void Credits()
    {
        if (creditsView.activeSelf && !howToPlayView.activeSelf)
        {
            creditsView.SetActive(false);
        }
        else if (!howToPlayView.activeSelf)
        {
            creditsView.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Debug.Log("The game has closed");
    }
}
