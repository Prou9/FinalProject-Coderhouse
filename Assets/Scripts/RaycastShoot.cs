using UnityEditor;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerToCollide;
    [SerializeField] private Transform raycastPoint;
    public string objectName;
            
    private void Raycast()
    {

        if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out RaycastHit hit, maxDistance, layerToCollide))
        {
            if (hit.collider.TryGetComponent(out Interactable interactable))
            {
                interactable.Grab();
                Debug.Log($"The item I found is a {hit.collider.name}");
                objectName = hit.collider.name;                

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            Raycast();
        }
    }
}
