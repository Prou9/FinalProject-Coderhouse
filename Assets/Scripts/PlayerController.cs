using UnityEngine;
public class PlayerController : InputController
{
    [SerializeField] float movementSpeed;
    public AudioSource steps;
    void Awake()
    {       
        steps = GetComponent<AudioSource>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {   
        Vector2 input = MoveInput();
        if ((input.x != 0 || input.y != 0))
        {
            if (!steps.isPlaying)
            {                
                steps.Play();
                
            }
        }
        else
        {
            steps.Stop();
        }

        transform.position += transform.forward * input.y * movementSpeed * Time.deltaTime;
        transform.position += transform.right * input.x * movementSpeed * Time.deltaTime;             

    }
}