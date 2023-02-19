using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    private static HashSet<InputBase> _inputs = new HashSet<InputBase>();

    public static void RegisterKey(KeyCode key, Action action)
    {
        _inputs.Add(new InputKey(key, action));
    }

    public static void RegisterAxis(string key, Action<float> action)
    {
        _inputs.Add(new InputAxis(key, action));
    }
}

public abstract class InputBase
{
    public abstract void Update();
}

public class InputKey : InputBase
{
    private KeyCode _key;
    private event Action _action;

    public InputKey(KeyCode key, Action action)
    {
        _key = key;
        _action = action;
    }

    public override void Update()
    {
        _action?.Invoke();
    }
}

public class InputAxis : InputBase
{
    private string _axis;
    private Action<float> _action;

    public InputAxis(string axis, Action<float> action)
    {
        _axis = axis;
        _action = action;
    }
    public override void Update()
    {
        _action?.Invoke(Input.GetAxis(_axis));
    }

}