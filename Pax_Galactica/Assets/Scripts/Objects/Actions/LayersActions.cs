using UnityEngine;

public class LayersActions : MonoBehaviour
{
    public static bool IsInLayerMask(int layer, LayerMask layerMask)
    {
        return layerMask == (layerMask | (1 << layer));
    }

    public static bool IsLayerMaskContained(LayerMask maskA, LayerMask maskB)
    {
        return (maskA.value & maskB.value) == maskA.value;
    }
}