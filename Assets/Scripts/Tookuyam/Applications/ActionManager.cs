using Tookuyam;
using System.Collections.Generic;
using System;

public class ActionManager
{
    private Dictionary<string, InputActionAdapter> actions = new();

    public void AddInputAction(string name, InputActionAdapter action)
    {
        actions.Add(name, action);
    }

    public void Update()
    {
        foreach (InputActionAdapter action in actions.Values)
        {
            action.Update();
        }
    }

    public bool CheckOnce(string name)
    {
        if (actions.ContainsKey(name))
        {
            return actions[name].CheckOnce();
        }
        else
        {
            throw new Exception("Action not found: " + name);
        }
    }

    public bool Check(string name)
    {
        if (actions.ContainsKey(name))
        {
            return actions[name].Check();
        }
        else
        {
            throw new Exception("Action not found: " + name);
        }
    }
}
