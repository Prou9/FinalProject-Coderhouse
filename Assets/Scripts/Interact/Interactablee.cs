using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Interactablee : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public float messageDuration = 1f;

    //private void Awake()
    //{
    //    GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    //}

    //private void OnDestroy()
    //{
    //    GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    //}
    //private void GameManagerOnGameStateChanged(GameState state)
    //{
    //    if(state == GameState.OpenAttic)
    //    Debug.Log("ahora vamos por la puertita");
    //}

    public virtual void Interact() {
        Debug.Log($"pasa por aca {gameObject.name}");

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
