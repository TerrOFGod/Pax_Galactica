using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : BaseObject
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string IdleState;
    [SerializeField]
    private string moveState;
    [SerializeField]
    protected NavMeshAgent agent;
    [SerializeField]
    private UnityEvent selectEvent;
    [SerializeField]
    private UnityEvent deselectEvent;

    public bool PathIsEnd { protected set; get; }

    public virtual void Select()
    {
        selectEvent.Invoke();
    }

    public virtual void Deselect()
    {
        deselectEvent.Invoke();
    }

    private void Update()
    {
        Tick();
    }

    protected virtual void Tick()
    {
        UpdateAnimation();
    }

    public void UpdateAnimation()
    {
        PathIsEnd = agent.remainingDistance <= agent.stoppingDistance;
        animator.SetBool(IdleState, PathIsEnd);
        animator.SetBool(moveState, !PathIsEnd);
    }

    public virtual void Move(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public virtual void Interaction(Component objectComponent)
    {
        //Интерактирование с предметом (к примеру со зданием (починка) или с врагами (атакующее состояние))
    }

    private void OnValidate()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
}