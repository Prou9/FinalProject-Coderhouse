using System.Collections;
using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    private float actualRunningTime;
    private bool canRun;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        canRun = true;
    }
    protected Vector2 MoveInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        return new Vector2(moveX, moveY);
    }

    protected bool IsRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift) && canRun && actualRunningTime < 3) {
            actualRunningTime += Time.deltaTime;
            return true;
            
        } else
        {
            
            actualRunningTime = 0f;
            canRun = false;
            StartCoroutine(WaitSeconds());
            return false;
        }       
    }

    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(5f);
        canRun = true;
    }

    protected Vector2 MouseInput()
    {
        float moveX = Input.GetAxis("Mouse X");
        float moveY = Input.GetAxis("Mouse Y");

        return new Vector2(moveX, -moveY);
    }
}
