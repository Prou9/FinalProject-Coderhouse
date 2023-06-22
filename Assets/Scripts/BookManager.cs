using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public TextMeshProUGUI escapeText;
    [SerializeField] private GameObject collectable;
    public List<Pickable> bookList = new();
    private Animator anim;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
        anim = escapeText.GetComponent<Animator>();

    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }
    private void GameManagerOnGameStateChanged(GameState state)
    {
        if (state == GameState.FindArtifacts)
        {
            collectable.SetActive(true);
        }
        if (state == GameState.Escape)
            anim.SetBool("escape", true);
            escapeText.gameObject.SetActive(true);
    }

    public void AddBook(Pickable book)
    {
        bookList.Add(book);
    }

    public int GetBookCount()
    {
        return bookList.Count;
    }   
}
