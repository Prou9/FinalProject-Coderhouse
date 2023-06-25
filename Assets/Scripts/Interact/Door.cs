using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : Interactablee
{    
    public Animator anim;
    private bool unlocked = false;
    private bool opened = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public override void Interact()
    {
        base.Interact();       
        if (!unlocked)
        {            
            messageText.text = $"Locked";
            messageText.gameObject.SetActive(true);
        } else if (!opened)
        {           
            Debug.Log("pasa por aca despues");

            messageText.text = $"Opened";
            anim.SetBool("opened", true);
            messageText.gameObject.SetActive(true);
            opened = true;
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
