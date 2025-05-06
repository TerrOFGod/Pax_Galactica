using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string IdleState;
    [SerializeField]
    private string moveState;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private UnityEvent selectEvent;
    [SerializeField]
    private UnityEvent deselectEvent;

    public void Select()
    {
        selectEvent.Invoke();
    }

    public void Deselect()
    {
        deselectEvent.Invoke();
    }

    private void Update()
    {
        UpdateAnimation();
    }

    public void UpdateAnimation()
    {
        var pathIsEnd = agent.remainingDistance <= agent.stoppingDistance;
        animator.SetBool(IdleState, pathIsEnd);
        animator.SetBool(moveState, !pathIsEnd);
    }

    public void Move(Vector3 point)
    {
        agent.SetDestination(point);
    }

    private void OnValidate()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
}