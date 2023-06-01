using UnityEngine;

[CreateAssetMenu(fileName = "BookData", menuName = "Scriptable Objects/Book Data")]
public class BookInfo: ScriptableObject
{
    public string id;
    public string bookTitle;
    public string bookDescription;

}
