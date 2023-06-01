using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public Transform target;
    public NavMeshAgent agent;
    public float rangeSphere;
    public Transform centrePoint;
    public Animator animator;
    public AudioSource chasingSource;
    public Transform raycastPoint;
    public float maxDistanceRaycast;
}
