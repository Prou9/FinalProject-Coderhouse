using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerToCollide;
    [SerializeField] private Transform raycastPoint;
    //public string objectName;
    public TextMeshProUGUI itemInfo;


    private void Raycast()
    {
        itemInfo.gameObject.SetActive(false);
        if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out RaycastHit hit, maxDistance, layerToCollide))
        {
            if (hit.collider.TryGetComponent(out Interactablee _)) {
                switch (hit.collider.gameObject.layer)
                {
                    case 10:
                        itemInfo.text = "Attic key";
                        break;
                    case 11:
                        itemInfo.text = "Door";
                        break;
                    case 6:
                        itemInfo.text = "Artifact";
                        break;
                }
                itemInfo.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("entra aki");
                    hit.transform.GetComponent<Interactablee>().Interact();
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(raycastPoint.position, raycastPoint.position + raycastPoint.forward * maxDistance);
    }

    private void Update()
    {
        Raycast();
    }
}
