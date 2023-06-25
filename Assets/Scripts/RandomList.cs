
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomList : MonoBehaviour
{
    [SerializeField] private List<GameObject> collectableList = new();
    [SerializeField] private List<GameObject> collectablePositionList = new();
    [SerializeField] private List<GameObject> keyPositionList = new();
    [SerializeField] private GameObject key;


    private void Awake()
    {
        int keyIndexPosition = Random.Range(0, keyPositionList.Count);       
        Vector3 keyPosition = keyPositionList[keyIndexPosition].transform.position;
        Quaternion keyRotation = keyPositionList[keyIndexPosition].transform.rotation;

        key.transform.SetPositionAndRotation(keyPosition, keyRotation);
        while (collectableList.Count > 0) 
        {            
                
                int indexPosition = Random.Range(0, collectablePositionList.Count);
                Vector3 position = collectablePositionList[indexPosition].transform.position;
                Quaternion rotation = collectablePositionList[indexPosition].transform.rotation;

           
            int index = Random.Range(0, collectableList.Count);
            GameObject collectable = collectableList[index];
            collectableList.RemoveAt(index);
            collectablePositionList.RemoveAt(indexPosition);

            collectable.transform.SetPositionAndRotation(position, rotation);
        }
    }
}
