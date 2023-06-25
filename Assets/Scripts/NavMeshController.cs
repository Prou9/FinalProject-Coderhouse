using System;
using UnityEngine;
using UnityEngine.AI;


public class NavMeshController : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public float rangeSphere;
    public Transform centrePoint;
    public Animator animator;
    public AudioSource chasingSource;
    [SerializeField] private Transform raycastPoint;
    [SerializeField] private float maxDistanceRaycast;
    private LayerMask layerToCollide;

    bool isChasing = false;
    public event Action SearchChaseEvent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        chasingSource = GetComponent<AudioSource>();
        layerToCollide = LayerMask.GetMask("Wall", "Player", "Objects");
        SearchChaseEvent += Search;
        SearchChaseEvent += Chase;
    }
 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(raycastPoint.position, raycastPoint.position + raycastPoint.forward * maxDistanceRaycast);
    }

    void Update()
    {
        //Search();
        //Chase();
        SearchChaseEvent?.Invoke();
    }

    private void Search()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;

            switch (RandomPoint(centrePoint.position, rangeSphere, out point))
            {
                case true: //walking
                    animator.SetBool("walk", true);
                    agent.SetDestination(point);                    
                    break;
                case false: //idle                    
                    animator.SetBool("run", false);
                    animator.SetBool("walk", false);
                    break;
            }
        }
          animator.SetBool("walk", true);        
    }
    bool RandomPoint(Vector3 center, float rangeSphere, out Vector3 result)
    {

        Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * rangeSphere;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
    private void Chase()
    { 

        if (Physics.Raycast(raycastPoint.position, raycastPoint.forward, out RaycastHit hit, maxDistanceRaycast, layerToCollide))
        {
            
            if (hit.collider.TryGetComponent(out PlayerController _))
            {
                animator.SetBool("walk", false);
                animator.SetBool("run", true);
                agent.SetDestination(hit.transform.position);
                if (!isChasing)
                {
                    chasingSource.Play();
                    isChasing = true;
                    
                }
            }
            else if (isChasing)
            {
                chasingSource.volume -= Time.deltaTime;
                if (chasingSource.volume <= 0)
                {
                    isChasing = false;
                    chasingSource.Stop();
                    chasingSource.volume = 1f;
                }
            }
        } 
    }


}
