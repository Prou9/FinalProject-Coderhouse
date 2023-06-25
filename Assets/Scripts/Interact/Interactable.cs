using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public float messageDuration = 1f;
    
    public virtual void Interact() {
        
        if (gameObject.layer == 10)
        {
            GameManager.instance.UpdateGameState(GameState.OpenAttic);
        }

        if ((gameObject.name == "AtticDoor" && GameManager.instance.state == GameState.OpenAttic)
        || (gameObject.name == "EntranceDoor" && GameManager.instance.state == GameState.Escape))
        {
            gameObject.GetComponent<Door>().UnlockDoor();
        }

    }
}
