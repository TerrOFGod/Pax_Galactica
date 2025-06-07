using System.Collections;
using UnityEngine;

public class UnitMine : Unit
{
    [SerializeField]
    private float countMining;
    [SerializeField]
    private float timeMining;
    [SerializeField]
    private float timeTransfer;
    [SerializeField]
    private Visualizer visualizerMining;

    private Coroutine currentMiningCoroutine;
    private Component objectInteraction;

    public override void Move(Vector3 point)
    {
        if (currentMiningCoroutine != null)
        {
            StopCoroutine(currentMiningCoroutine);
            objectInteraction = null;
        }

        base.Move(point);
    }

    public override void Interaction(Component objectComponent)
    {
        var mineBuilding = objectComponent as MiningBuilding;

        if (mineBuilding && objectInteraction != objectComponent)
        {
            if (currentMiningCoroutine != null)
            {
                StopCoroutine(currentMiningCoroutine);
            }

            StartCoroutine(Mining(mineBuilding));
            objectInteraction = objectComponent;
        }
    }

    private IEnumerator Mining(MiningBuilding mineBuilding)
    {
        var miningPoint = MiningPoints.Instance.GetNearestPoint(transform.position);
        var mineBuildingPoint = mineBuilding.Point.position;

        while (true)
        {
            base.Move(miningPoint);

            while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
            {
                yield return null;
            }

            var timerStart = Time.time;

            while (Time.time - timerStart <= timeMining)
            {
                visualizerMining.Set((Time.time - timerStart) / timeMining * countMining, countMining);
                yield return null;
            }

            visualizerMining.Set(countMining, countMining);

            base.Move(mineBuildingPoint);

            while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
            {
                yield return null;
            }

            timerStart = Time.time;

            while (Time.time - timerStart <= timeTransfer)
            {
                visualizerMining.Set((1f - ((Time.time - timerStart) / timeTransfer)) * countMining, countMining);
                yield return null;
            }

            visualizerMining.Set(0f, countMining);
            Money.Instance.Add(countMining);
        }
    }
}