using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pickable : Interactablee
{
    public TextMeshProUGUI messageText;
    public float messageDuration = 1f;
    //private bool isInteracted = false;reyca;
    public override void Interact()
    {
        base.Interact();
        Debug.Log("pasa por aca despues");

        //isInteracted = true;

        // Agregar el libro a la lista del BookManager
        BookManager.Instance.AddBook(gameObject);

        //messageText.text = "Libros: " + (BookManager.Instance.GetBookCount() / 10).ToString();
        messageText.text = $"Artifact: {BookManager.Instance.GetBookCount()}/4";

        messageText.gameObject.SetActive(true);
        Invoke("HideMessage", messageDuration);
    }


    private void HideMessage()
    {
        messageText.gameObject.SetActive(false);

        // Eliminar el libro de la lista del BookManager
        //BookManager.Instance.RemoveBook(gameObject);

        Destroy(gameObject);
    }

}
