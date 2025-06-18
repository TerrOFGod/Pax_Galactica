using UnityEngine;

[RequireComponent(typeof(BaseMoveUnits))]
public class ActionUnits : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerPlane;
    [SerializeField]
    private LayerMask layerInteraction;
    [SerializeField]
    private BaseMoveUnits moveMethod;
    [SerializeField]
    private BaseInteractionMethod interactionMethod;

    private const float maxDistanceRay = 1000f;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistanceRay, layerInteraction))
            {
                interactionMethod.Interact(hit.transform.GetComponent<BaseObject>());
            }
            else if(Physics.Raycast(ray, out hit, maxDistanceRay, layerPlane))
            {
                moveMethod.Move(hit.point);
            }
        }
    }
}
