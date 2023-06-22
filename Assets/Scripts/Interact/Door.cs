using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : Interactablee
{    
    public Animator anim;
    public bool unlocked = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public override void Interact()
    {
        base.Interact();       
        if (!unlocked)
        {            
            messageText.text = $"Door locked";
            messageText.gameObject.SetActive(true);
        } else
        {           
            Debug.Log("pasa por aca despues");

            messageText.text = $"Door opened";
            anim.SetBool("opened", true);
            messageText.gameObject.SetActive(true);
            GameManager.instance.UpdateGameState(GameState.FindArtifacts);
        }
        Invoke(nameof(HideMessage), messageDuration);
    }

    private void HideMessage()
    {
        messageText.gameObject.SetActive(false);
        if (unlocked) Destroy(this);
    }
    public void UnlockDoor()
    {
        unlocked = true;
    }

}
