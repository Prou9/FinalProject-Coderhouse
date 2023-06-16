//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class Cross : MonoBehaviour
//{
//    public TextMeshProUGUI messageText;
//    public float messageDuration = 1f;

//    private bool isInteracted = false;

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player") && !isInteracted)
//        {
//            //Interact(gameObject);
//        }
//    }

//    public void Interact(GameObject gameObject)
//    {
//        isInteracted = true;

//        // Agregar el libro a la lista del BookManager
//        BookManager.Instance.AddBook(gameObject);

//        //messageText.text = "Libros: " + (BookManager.Instance.GetBookCount() / 10).ToString();
//        messageText.text = $"Crucifix: {BookManager.Instance.GetBookCount()}/4";

//        messageText.gameObject.SetActive(true);
//        Invoke("HideMessage", messageDuration);
//    }

//    private void HideMessage()
//    {
//        messageText.gameObject.SetActive(false);

//        // Eliminar el libro de la lista del BookManager
//        //BookManager.Instance.RemoveBook(gameObject);

//        Destroy(gameObject);
//    }
//}
