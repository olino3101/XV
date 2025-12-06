using UnityEngine;

namespace Tookuyam
{
    public class TestRunner : MonoBehaviour
    {
        void Start()
        {
            if (Run())
            {
                Debug.Log("All Tests Passed");
            }
        }

        static public bool Run()
        {
            // InputActionAdapter
            {
                InputActionAdapter adapter = new InputActionAdapter(() => true);
                adapter.Update();
                Test(adapter.Check() == true);
                Test(adapter.CheckOnce() == true);
                Test(adapter.CheckOnce() == false);
                Test(adapter.Check() == true);
                adapter.Update();
                Test(adapter.CheckOnce() == true);
            }
            return true;
        }

        static private bool Test(bool value)
        {
            if (!value)
            {
                throw new System.Exception("Test Failed");
            }
            return value;
        }
    }
}

