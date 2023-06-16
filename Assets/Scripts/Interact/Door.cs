using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door : Interactablee
{
    public TextMeshProUGUI messageText;
    public float messageDuration = 1f;
    public override void Interact()
    {
        base.Interact();
        Debug.Log("pasa por aca despues");

       
        messageText.text = $"Door opened";

        messageText.gameObject.SetActive(true);
        transform.Rotate(Vector3.forward * -90);
        Invoke("HideMessage", messageDuration);
    }

    private void HideMessage()
    {
        messageText.gameObject.SetActive(false);
    }

}
