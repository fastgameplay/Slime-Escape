//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Game/Data/Input/BasicInput.inputactions
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

public partial class @BasicInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @BasicInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BasicInput"",
    ""maps"": [
        {
            ""name"": ""Basic"",
            ""id"": ""803d310c-a8b6-4068-8f93-9e83632f2854"",
            ""actions"": [
                {
                    ""name"": ""OnPointerPositionChange"",
                    ""type"": ""Value"",
                    ""id"": ""c02a02ff-5e66-43f7-ac1c-9a083dd77b59"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""OnTap"",
                    ""type"": ""Button"",
                    ""id"": ""393fbb47-9eb4-4fd5-8404-6364baf53065"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c1f675aa-f523-48fd-bd62-49566e654e88"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnPointerPositionChange"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3d42878-b60f-47b9-84f2-9b92b19c539c"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnTap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Basic
        m_Basic = asset.FindActionMap("Basic", throwIfNotFound: true);
        m_Basic_OnPointerPositionChange = m_Basic.FindAction("OnPointerPositionChange", throwIfNotFound: true);
        m_Basic_OnTap = m_Basic.FindAction("OnTap", throwIfNotFound: true);
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

    // Basic
    private readonly InputActionMap m_Basic;
    private List<IBasicActions> m_BasicActionsCallbackInterfaces = new List<IBasicActions>();
    private readonly InputAction m_Basic_OnPointerPositionChange;
    private readonly InputAction m_Basic_OnTap;
    public struct BasicActions
    {
        private @BasicInput m_Wrapper;
        public BasicActions(@BasicInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @OnPointerPositionChange => m_Wrapper.m_Basic_OnPointerPositionChange;
        public InputAction @OnTap => m_Wrapper.m_Basic_OnTap;
        public InputActionMap Get() { return m_Wrapper.m_Basic; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasicActions set) { return set.Get(); }
        public void AddCallbacks(IBasicActions instance)
        {
            if (instance == null || m_Wrapper.m_BasicActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BasicActionsCallbackInterfaces.Add(instance);
            @OnPointerPositionChange.started += instance.OnOnPointerPositionChange;
            @OnPointerPositionChange.performed += instance.OnOnPointerPositionChange;
            @OnPointerPositionChange.canceled += instance.OnOnPointerPositionChange;
            @OnTap.started += instance.OnOnTap;
            @OnTap.performed += instance.OnOnTap;
            @OnTap.canceled += instance.OnOnTap;
        }

        private void UnregisterCallbacks(IBasicActions instance)
        {
            @OnPointerPositionChange.started -= instance.OnOnPointerPositionChange;
            @OnPointerPositionChange.performed -= instance.OnOnPointerPositionChange;
            @OnPointerPositionChange.canceled -= instance.OnOnPointerPositionChange;
            @OnTap.started -= instance.OnOnTap;
            @OnTap.performed -= instance.OnOnTap;
            @OnTap.canceled -= instance.OnOnTap;
        }

        public void RemoveCallbacks(IBasicActions instance)
        {
            if (m_Wrapper.m_BasicActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBasicActions instance)
        {
            foreach (var item in m_Wrapper.m_BasicActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BasicActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BasicActions @Basic => new BasicActions(this);
    public interface IBasicActions
    {
        void OnOnPointerPositionChange(InputAction.CallbackContext context);
        void OnOnTap(InputAction.CallbackContext context);
    }
}
