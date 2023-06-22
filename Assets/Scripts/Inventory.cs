//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//public struct BookData
//{
//    public string id;
//    public string bookTitle;
//    public string bookDescription;

//    public override string ToString()
//    {
//        string bookString = string.Empty;
//        bookString += "Title: " + bookTitle +
//                      " Description: " + bookDescription;
//        return bookString;
//    }

//}
//public class Inventory : MonoBehaviour
//{
//    [SerializeField] private Interactable[] objectsToWin;
//    protected List<Interactable> objectsList = new List<Interactable>();
//    private Dictionary<string, BookData> booksDictionary = new Dictionary<string, BookData>();
//    public PlayerRaycast playerRaycast;

//    private void Awake()
//    {
//        BookData book1Data = new BookData()
//        {
//            id = "Book1",
//            bookTitle = "Whispers in the Dark",
//            bookDescription = " This chilling novel follows a young woman who moves into a secluded cabin in the woods, only to discover that she is not alone. Strange whispers and unexplained phenomena haunt her every move, leading her on a terrifying journey to uncover the dark secrets of her new home."
//        };

//        BookData book2Data = new BookData()
//        {
//            id = "Book2",
//            bookTitle = "The Devil's Playground",
//            bookDescription = "When a group of friends stumble upon an abandoned amusement park, they think they've hit the jackpot. But as they explore the decrepit rides and attractions, they soon realize that something evil lurks within the park's rusted gates. As they try to escape the clutches of the demonic forces that haunt the park, they must confront their deepest fears and darkest secrets."
//        };

//        BookData book3Data = new BookData()
//        {
//            id = "Book3",
//            bookTitle = "The Shadow Man",
//            bookDescription = "In this spine-tingling tale, a young boy is haunted by a malevolent entity that lurks in the shadows of his home. As the creature's attacks grow more frequent and violent, the boy must race against time to uncover the truth about the Shadow Man and put an end to his reign of terror before it's too late."
//        };

//        booksDictionary.Add("Book", book1Data);
//        booksDictionary.Add("Book (1)", book2Data);
//        booksDictionary.Add("Book (2)", book3Data);

//    }

//    private void Update()
//    {
//        CheckIfWin();

//        // CheckIfWinBackwards(); if you want to do backwards
//        if (!string.IsNullOrEmpty(playerRaycast.objectName))
//        {
//            string hitObjectName = playerRaycast.objectName;
//            CheckInfoFromBook(hitObjectName);
//        }
//    }

//    void CheckIfWin() // necesita evento 
//    {
//        bool allExist = true;
//        foreach (Interactable item in objectsToWin)
//        {
//            if (!objectsList.Contains(item))
//            {
//                allExist = false;
//                break;
//            }
//        }
//        if (allExist)
//        {
//            Debug.Log("You escaped from the mansion!!!!");
//        }
//    }

//    void CheckIfWinBackwards()
//    {
//        bool allExist = true;
//        for (int i = objectsToWin.Length - 1; i >= 0; i--)
//        {
//            if (!objectsList.Contains(objectsToWin[i]))
//            {
//                allExist = false;
//                break;
//            }
//        }
//        if (allExist)
//        {
//            Debug.Log("You escaped from the mansion!!!!");
//        }
//    }

//    private void CheckInfoFromBook(string bookId)
//    {
//        booksDictionary.TryGetValue(bookId, out BookData bookData);
//        {
//            Debug.Log(bookData);
//            playerRaycast.objectName = "";
//        }
//    }
//    public void GrabItem(Interactable obj)
//    {
//        objectsList.Add(obj);
//        Destroy(obj);
//    }    
//}
