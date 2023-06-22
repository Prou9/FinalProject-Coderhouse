using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pickable : Interactablee
{   
    public override void Interact()
    {
        base.Interact();
        
        switch (gameObject.layer)
        {
            case 10:
                messageText.text = $"Attic key found";
                messageText.gameObject.SetActive(true);
                //misionpa.CompleteMission();
                break;
            case 6:
                GameManager.instance.AddBook(this);
                messageText.text = $"Artifact {GameManager.instance.GetBookCount()}/4";
                messageText.gameObject.SetActive(true);
                break;
        }
        Invoke("HideMessage", messageDuration);

        if (GameManager.instance.GetBookCount() == 4) GameManager.instance.UpdateGameState(GameState.Escape);
    }
    private void HideMessage()
    {
        messageText.gameObject.SetActive(false);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

}
