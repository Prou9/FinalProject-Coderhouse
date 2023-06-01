using UnityEngine;
public class PlayerController : InputController
{
    [SerializeField] float movementSpeed;
    public AudioSource steps;
    public Animator anim;
    void Awake()
    {       
        steps = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
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
                //anim.enabled = true;    
                anim.SetBool("walk", true);
            }
        }
        else
        {
            steps.Stop();
            //anim.enabled = false;
            anim.SetBool("walk", false);
        }

        switch (IsRunning())
        {
            case true:
                transform.position += transform.forward * input.y * movementSpeed * 1.5f * Time.deltaTime;
                transform.position += transform.right * input.x * movementSpeed * 1.5f * Time.deltaTime;
                break;
            case false:
                transform.position += transform.forward * input.y * movementSpeed * Time.deltaTime;
                transform.position += transform.right * input.x * movementSpeed * Time.deltaTime;
                break;
        }
       

    }
}