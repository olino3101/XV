using Tookuyam;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InputActionAdapterTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void Basic()
    {
        InputActionAdapter adapter = new InputActionAdapter(() => true);
        adapter.Update();
        Assert.AreEqual(adapter.Check(), true);
        Assert.AreEqual(adapter.CheckOnce(), true);
        Assert.AreEqual(adapter.CheckOnce(), false);
        Assert.AreEqual(adapter.Check(), true);
        adapter.Update();
        Assert.AreEqual(adapter.CheckOnce(), true);
    }
}
