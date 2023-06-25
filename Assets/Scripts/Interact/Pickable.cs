using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pickable : Interactable
{   
    public override void Interact()
    {
        base.Interact();
        
        switch (gameObject.layer)
        {
            case 10:
                messageText.text = $"Attic key found";
                messageText.gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
            case 6:
                GameManager.instance.AddBook(this);
                messageText.text = $"Artifact {GameManager.instance.GetBookCount()}/6";
                messageText.gameObject.SetActive(true);
                gameObject.SetActive(false);
                break;
        }
        Invoke(nameof(HideMessage), messageDuration);

        if (GameManager.instance.GetBookCount() == 6) GameManager.instance.UpdateGameState(GameState.Escape);
    }
    private void HideMessage()
    {
        messageText.gameObject.SetActive(false);
        
    }

}
