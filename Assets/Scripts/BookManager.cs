using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public static BookManager Instance;  // Referencia estática al script para acceder fácilmente a él
    public TextMeshProUGUI messageText;

    private List<GameObject> cantidadDeLibros = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddBook(GameObject book)
    {
        cantidadDeLibros.Add(book);
    }

    //public void RemoveBook(GameObject book)
    //{
    //    cantidadDeLibros.Remove(book);
    //}

    public int GetBookCount()
    {
        return cantidadDeLibros.Count;
    }

    private void Update()
    {
        if (GetBookCount() == 4)
        {
            messageText.gameObject.SetActive(true);

        }
    }
}
