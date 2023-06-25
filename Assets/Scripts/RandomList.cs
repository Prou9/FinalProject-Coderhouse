
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
        Vector3 keyPosicion = keyPositionList[keyIndexPosition].transform.position;
        Quaternion keyRotacion = keyPositionList[keyIndexPosition].transform.rotation;

        key.transform.SetPositionAndRotation(keyPosicion, keyRotacion);
        while (collectableList.Count > 0) 
        {            
                
                int indexPosition = Random.Range(0, collectablePositionList.Count);
                Vector3 posicion = collectablePositionList[indexPosition].transform.position;
                Quaternion rotacion = collectablePositionList[indexPosition].transform.rotation;

            // Selecciona un objeto aleatorio
            int index = Random.Range(0, collectableList.Count);
                Debug.Log($"posicion {posicion}");
            GameObject objeto = collectableList[index];
                Debug.Log($"para el objeto {objeto}");
            collectableList.RemoveAt(index);
            collectablePositionList.RemoveAt(indexPosition);

            // Asigna la posición al objeto
            objeto.transform.SetPositionAndRotation(posicion, rotacion);
        }
    }
}
