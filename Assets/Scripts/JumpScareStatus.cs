using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScareStatus : MonoBehaviour
{
    public bool isJumpscareFinished;

    private void Update()
    {
        if(isJumpscareFinished)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
