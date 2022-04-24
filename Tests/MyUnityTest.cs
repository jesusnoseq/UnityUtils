using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;


namespace Test{

public class MyUnityTest : MonoBehaviour
{
    [UnityTest]
    public IEnumerator DummyTestTest(){
        Assert.AreEqual(1,1);
        yield return null;
    }
}
}
