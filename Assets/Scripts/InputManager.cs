using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static HashSet<InputBase> _inputs = new HashSet<InputBase>();
    private static InputManager _instance;
    public static InputManager Instance => _instance;

    [RuntimeInitializeOnLoadMethod]
    public static void InitializeObject()
    {
        _instance = new GameObject().AddComponent<InputManager>();
        _instance.name = "InputManager";
    }

    public void Update()
    {
        foreach (var input in _inputs)
        {
            input.CheckInput();
        }
    }

    public static void RegisterKey(InputKeyState keyState , Action action, params KeyCode[] keycodes)
    {
        foreach (var key in keycodes)
        {
            _inputs.Add(new InputKey(key, keyState, action));
        }
    }

    public static void RegisterAxis(string key, Action<float> action)
    {
        _inputs.Add(new InputAxis(key, action));
    }
}

public abstract class InputBase
{
    public abstract void CheckInput();
}

public class InputKey : InputBase
{
    private KeyCode _key;
    private InputKeyState _inputKeyState;
    private event Action _action;

    public InputKey(KeyCode key, InputKeyState inputKeyState, Action action)
    {
        _key = key;
        _action = action;
        _inputKeyState = inputKeyState;
    }

    public override void CheckInput()
    {
        switch (_inputKeyState)
        {
            case InputKeyState.KeyHold when Input.GetKey(_key):
            case InputKeyState.KeyDown when Input.GetKeyDown(_key):
            case InputKeyState.KeyUp when Input.GetKeyUp(_key):
                _action?.Invoke();
                return;
            default:
                break;
        }
    }
}

public enum InputKeyState
{
    KeyHold,
    KeyDown,
    KeyUp
}

public class InputAxis : InputBase
{
    private float _lastValue;
    private string _axis;
    private Action<float> _action;

    public InputAxis(string axis, Action<float> action)
    {
        _axis = axis;
        _action = action;
    }

    public override void CheckInput()
    {
        var value = Input.GetAxis(_axis);
        if (value != _lastValue)
        {
            _action?.Invoke(_lastValue);
        }
        _lastValue = value;

    }
}