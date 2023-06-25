using System.Collections;
using UnityEngine;

public abstract class InputController : MonoBehaviour
{    
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    protected Vector2 MoveInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        return new Vector2(moveX, moveY);
    }

    protected Vector2 MouseInput()
    {
        float moveX = Input.GetAxis("Mouse X");
        float moveY = Input.GetAxis("Mouse Y");

        return new Vector2(moveX, -moveY);
    }
}
