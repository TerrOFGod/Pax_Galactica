using UnityEngine;

[RequireComponent(typeof(BaseMoveUnits))]
public class MoveUnits : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerPlane;
    [SerializeField]
    private BaseMoveUnits moveMethod;

    private const float maxDistanceRay = 1000f;

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKeyUp(KeyCode.Mouse1) && Physics.Raycast(ray, out RaycastHit hit, maxDistanceRay))
        {
            moveMethod.Move(hit.point);
        }
    }
}
