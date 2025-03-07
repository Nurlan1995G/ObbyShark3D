//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Project/CodeBase/Input/RotateInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @RotateInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @RotateInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""RotateInput"",
    ""maps"": [
        {
            ""name"": ""Touchscreen"",
            ""id"": ""a51bdea3-783a-4937-a4eb-4e7c6d8d1143"",
            ""actions"": [
                {
                    ""name"": ""TouchDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a393f0ea-9904-4cf6-ade6-a4a4fd51d1b8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7059ecb9-141e-4166-9860-5d907f9bea18"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""id"": ""7d65a214-2f3b-4b28-a9d2-930dff6b0297"",
            ""actions"": [
                {
                    ""name"": ""RightButton"",
                    ""type"": ""Value"",
                    ""id"": ""72f80ef4-3a72-490e-a417-4075610b2729"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseSrollWheel"",
                    ""type"": ""Value"",
                    ""id"": ""67f97475-26de-4f1c-aba9-f3eb12feac6a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e672e74e-0b14-46fa-baaa-6b65ea7817bd"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""RightButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a20c058-91a4-4376-beb1-f03db3907fb5"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseSrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Touchscreen
        m_Touchscreen = asset.FindActionMap("Touchscreen", throwIfNotFound: true);
        m_Touchscreen_TouchDelta = m_Touchscreen.FindAction("TouchDelta", throwIfNotFound: true);
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_RightButton = m_Mouse.FindAction("RightButton", throwIfNotFound: true);
        m_Mouse_MouseSrollWheel = m_Mouse.FindAction("MouseSrollWheel", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Touchscreen
    private readonly InputActionMap m_Touchscreen;
    private List<ITouchscreenActions> m_TouchscreenActionsCallbackInterfaces = new List<ITouchscreenActions>();
    private readonly InputAction m_Touchscreen_TouchDelta;
    public struct TouchscreenActions
    {
        private @RotateInput m_Wrapper;
        public TouchscreenActions(@RotateInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchDelta => m_Wrapper.m_Touchscreen_TouchDelta;
        public InputActionMap Get() { return m_Wrapper.m_Touchscreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchscreenActions set) { return set.Get(); }
        public void AddCallbacks(ITouchscreenActions instance)
        {
            if (instance == null || m_Wrapper.m_TouchscreenActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TouchscreenActionsCallbackInterfaces.Add(instance);
            @TouchDelta.started += instance.OnTouchDelta;
            @TouchDelta.performed += instance.OnTouchDelta;
            @TouchDelta.canceled += instance.OnTouchDelta;
        }

        private void UnregisterCallbacks(ITouchscreenActions instance)
        {
            @TouchDelta.started -= instance.OnTouchDelta;
            @TouchDelta.performed -= instance.OnTouchDelta;
            @TouchDelta.canceled -= instance.OnTouchDelta;
        }

        public void RemoveCallbacks(ITouchscreenActions instance)
        {
            if (m_Wrapper.m_TouchscreenActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITouchscreenActions instance)
        {
            foreach (var item in m_Wrapper.m_TouchscreenActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TouchscreenActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TouchscreenActions @Touchscreen => new TouchscreenActions(this);

    // Mouse
    private readonly InputActionMap m_Mouse;
    private List<IMouseActions> m_MouseActionsCallbackInterfaces = new List<IMouseActions>();
    private readonly InputAction m_Mouse_RightButton;
    private readonly InputAction m_Mouse_MouseSrollWheel;
    public struct MouseActions
    {
        private @RotateInput m_Wrapper;
        public MouseActions(@RotateInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightButton => m_Wrapper.m_Mouse_RightButton;
        public InputAction @MouseSrollWheel => m_Wrapper.m_Mouse_MouseSrollWheel;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void AddCallbacks(IMouseActions instance)
        {
            if (instance == null || m_Wrapper.m_MouseActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MouseActionsCallbackInterfaces.Add(instance);
            @RightButton.started += instance.OnRightButton;
            @RightButton.performed += instance.OnRightButton;
            @RightButton.canceled += instance.OnRightButton;
            @MouseSrollWheel.started += instance.OnMouseSrollWheel;
            @MouseSrollWheel.performed += instance.OnMouseSrollWheel;
            @MouseSrollWheel.canceled += instance.OnMouseSrollWheel;
        }

        private void UnregisterCallbacks(IMouseActions instance)
        {
            @RightButton.started -= instance.OnRightButton;
            @RightButton.performed -= instance.OnRightButton;
            @RightButton.canceled -= instance.OnRightButton;
            @MouseSrollWheel.started -= instance.OnMouseSrollWheel;
            @MouseSrollWheel.performed -= instance.OnMouseSrollWheel;
            @MouseSrollWheel.canceled -= instance.OnMouseSrollWheel;
        }

        public void RemoveCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMouseActions instance)
        {
            foreach (var item in m_Wrapper.m_MouseActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MouseActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MouseActions @Mouse => new MouseActions(this);
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    public interface ITouchscreenActions
    {
        void OnTouchDelta(InputAction.CallbackContext context);
    }
    public interface IMouseActions
    {
        void OnRightButton(InputAction.CallbackContext context);
        void OnMouseSrollWheel(InputAction.CallbackContext context);
    }
}
