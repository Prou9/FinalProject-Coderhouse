using UnityEngine;
public class JumpScareTrigger : MonoBehaviour
{
    public Transform enemy;
    public Transform target;
    public GameObject jumpScareObj;
    public GameObject player;
    public GameObject canvas;

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(enemy.position, target.position);
        if (distanceToPlayer <= 3 || Timer.actualTime < 1)
        {
            player.SetActive(false); 
            canvas.SetActive(false);
            jumpScareObj.SetActive(true);
        }
    }
}
