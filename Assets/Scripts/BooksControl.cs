using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BooksControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI books;
    private int actualBooks = 0;

    private void Update()
    {
        BooksGrabbed();
    }

    void BooksGrabbed()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            actualBooks ++;
            books.text = $"Books {actualBooks}/3";
        }
    }

}
