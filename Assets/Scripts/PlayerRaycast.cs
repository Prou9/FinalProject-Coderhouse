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
            if (hit.collider.TryGetComponent(out Interactable _)) {
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
                    hit.transform.GetComponent<Interactable>().Interact();
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
