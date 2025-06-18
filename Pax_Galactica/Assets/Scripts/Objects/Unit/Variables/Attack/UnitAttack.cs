using UnityEngine;

public class UnitAttack : Unit
{
    [SerializeField]
    private string attackState;
    [SerializeField]
    private float distanceAttack;
    [SerializeField]
    private LayerMask layerAttack;
    [SerializeField]
    private BaseAttack attackMethod;
    [Header("Настройки поворота")]
    [SerializeField]
    private float rotationSpeed = 90f;
    [SerializeField]
    private float minAngleToRotate = 5f;

    private BaseObject target;

    private bool RotateToTarget()
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        directionToTarget.y = 0;

        if (directionToTarget == Vector3.zero)
        {
            return true;
        }

        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        float angle = Quaternion.Angle(transform.rotation, targetRotation);

        if (angle > minAngleToRotate)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
        else
        {
            transform.rotation = targetRotation;
        }

        return transform.rotation == targetRotation;
    }

    public override void Move(Vector3 point)
    {
        target = null;
        animator.SetBool(attackState, false);
        base.Move(point);
    }

    protected override void Tick()
    {
        if (target)
        {
            if (Vector3.Distance(target.transform.position, transform.position) > distanceAttack)
            {
                if (agent.isStopped)
                {
                    agent.isStopped = false;
                    animator.SetBool(attackState, false);
                }

                base.Move(target.transform.position);
            }
            else
            {
                if (!agent.isStopped)
                {
                    agent.isStopped = true;
                    agent.ResetPath();
                }

                if (RotateToTarget())
                {
                    animator.SetBool(attackState, true);
                    attackMethod.Attack(target);
                }
            }
        }
        else if (agent.isStopped)
        {
            agent.isStopped = false;
            agent.ResetPath();
            animator.SetBool(attackState, false);
        }

        base.Tick();
    }

    public override void Interaction(BaseObject objectComponent)
    {
        if (LayersActions.IsLayerMaskContained(objectComponent.Layer, layerAttack))
        {
            target = objectComponent;
        }
    }
}