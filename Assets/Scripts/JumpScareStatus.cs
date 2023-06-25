using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class JumpScareStatus : MonoBehaviour
{
    public bool isJumpscareFinished;
    [SerializeField] private Volume postProcess;

    private void Update()
    {
        if(isJumpscareFinished && postProcess.sharedProfile.TryGet(out DepthOfField dof))
        {
           dof.mode.value = DepthOfFieldMode.Gaussian;
           dof.gaussianStart.value = 18f;
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
