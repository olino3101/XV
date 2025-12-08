using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ActionManagerTest
{
    [Test]
    public void Basic()
    {
        ActionManager actionManager = new ();
        actionManager.AddInputAction("test", new Tookuyam.InputActionAdapter(() => true));
        actionManager.AddInputAction("test2", new Tookuyam.InputActionAdapter(() => true));
        actionManager.Update();
        Assert.AreEqual(actionManager.CheckOnce("test"), true);
        Assert.AreEqual(actionManager.CheckOnce("test"), false);
        Assert.AreEqual(actionManager.Check("test"), true);
        Assert.AreEqual(actionManager.Check("test2"), true);
    }
}
