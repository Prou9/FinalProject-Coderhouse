using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class JumpScareTrigger : MonoBehaviour
{
    public Transform enemy;
    public Transform target;
    public GameObject jumpScareObj;
    public GameObject player;
    public GameObject canvas;
    [SerializeField] private Volume postProcess;
    private bool active;
   
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(enemy.position, target.position);
        if ((distanceToPlayer <= 3 || Timer.actualTime < 1) && !active)
        {
            player.SetActive(false); 
            canvas.SetActive(false);
          
            if(postProcess.sharedProfile.TryGet(out DepthOfField dof))
            {                
                dof.mode.value = DepthOfFieldMode.Bokeh;
                dof.focusDistance.value = 0.32f;
            }
            jumpScareObj.SetActive(true);
            active = true;
        }
    }

}
