using UnityEngine;

public class CameraController : InputController
{
    [SerializeField] float mouseSensitivity;
    [SerializeField] Transform Camera;

    void Update()
    {
        MouseCamera();
    }

    void MouseCamera()
    {
        Vector2 input = MouseInput();

        transform.Rotate(Vector3.up * input.x * mouseSensitivity * Time.deltaTime);

        Vector3 angle = Camera.eulerAngles;
        angle.x += input.y * mouseSensitivity * Time.deltaTime;


        Camera.eulerAngles = angle;
    }
}
