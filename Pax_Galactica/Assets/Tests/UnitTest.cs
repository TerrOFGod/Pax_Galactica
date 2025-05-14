using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UnitTest
{
    [UnityTest]
    public IEnumerator CheckUnitInstanceNull()
    {
        var g = new GameObject().AddComponent<Units>();
        var units = Units.Instance;
        Assert.IsNotNull(units);
        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckUnitsStackNull()
    {
        var g = new GameObject().AddComponent<Units>();
        var units = Units.Instance.AllUnits;
        Assert.IsNull(units);
        yield return null;
    }

    [UnityTest]
    public IEnumerator CheckZeroPositionUnit()
    {
        var g = new GameObject().AddComponent<Units>();
        var units = Units.Instance.AllUnits;

        if (units == null)
        {
            Assert.IsNull(units);
            yield break;
        }

        for (int i = 0; units.Count > 0; i++)
        {
            Assert.AreEqual(units[i].transform.position.y, 0f);
        }

        yield return null;
    }
}
