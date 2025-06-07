using UnityEngine;


public class BaseInteractionMethod : MonoBehaviour
{
    public virtual void Interact(BaseObject baseObject)
    {
        if (Units.Instance.SelectedUnits == null)
        {
            return;
        }

        switch (baseObject)
        {
            case MiningBuilding:
            {
                Mining(baseObject);
                break;
            }
        }
    }

    private void Mining(BaseObject baseObject)
    {
        var units = Units.Instance.SelectedUnits;

        for (int i = 0; i < units.Count; i++)
        {
            units[i].Interaction(baseObject);
        }
    }
}