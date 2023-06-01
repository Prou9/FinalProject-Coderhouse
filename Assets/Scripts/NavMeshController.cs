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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        chasingSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chasingSource.Play();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && (Vector3.Distance(transform.position, target.position)) <= 3)
        {
            chasingSource.Stop();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chasingSource.Stop();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(raycastPoint.position, raycastPoint.position + raycastPoint.forward * maxDistanceRaycast);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer < 8) // chasing
        {
            animator.SetBool("walk", false);
            animator.SetBool("run", true);
            agent.SetDestination(target.position);
        }

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
    }
    bool RandomPoint(Vector3 center, float rangeSphere, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * rangeSphere;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }


}
