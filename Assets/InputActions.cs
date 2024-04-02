//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/InputActions.inputactions
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

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Controllers"",
            ""id"": ""e3f4c802-b141-49de-aaa3-3830aac85628"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c27d2ea7-6632-4d18-8122-3f81961371e9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""140d624d-2d14-4ae7-a56d-d5fdda4cd51d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8a8110e1-7dcb-4e2f-b169-4fc6a13ea745"",
                    ""path"": ""<AndroidJoystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ControllersScheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58ba8d0d-6847-40a6-bba7-9243c5913855"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""ControllersScheme"",
            ""bindingGroup"": ""ControllersScheme"",
            ""devices"": []
        }
    ]
}");
        // Controllers
        m_Controllers = asset.FindActionMap("Controllers", throwIfNotFound: true);
        m_Controllers_Move = m_Controllers.FindAction("Move", throwIfNotFound: true);
        m_Controllers_Shoot = m_Controllers.FindAction("Shoot", throwIfNotFound: true);
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

    // Controllers
    private readonly InputActionMap m_Controllers;
    private List<IControllersActions> m_ControllersActionsCallbackInterfaces = new List<IControllersActions>();
    private readonly InputAction m_Controllers_Move;
    private readonly InputAction m_Controllers_Shoot;
    public struct ControllersActions
    {
        private @InputActions m_Wrapper;
        public ControllersActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Controllers_Move;
        public InputAction @Shoot => m_Wrapper.m_Controllers_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Controllers; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllersActions set) { return set.Get(); }
        public void AddCallbacks(IControllersActions instance)
        {
            if (instance == null || m_Wrapper.m_ControllersActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ControllersActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(IControllersActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(IControllersActions instance)
        {
            if (m_Wrapper.m_ControllersActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IControllersActions instance)
        {
            foreach (var item in m_Wrapper.m_ControllersActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ControllersActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ControllersActions @Controllers => new ControllersActions(this);
    private int m_ControllersSchemeSchemeIndex = -1;
    public InputControlScheme ControllersSchemeScheme
    {
        get
        {
            if (m_ControllersSchemeSchemeIndex == -1) m_ControllersSchemeSchemeIndex = asset.FindControlSchemeIndex("ControllersScheme");
            return asset.controlSchemes[m_ControllersSchemeSchemeIndex];
        }
    }
    public interface IControllersActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
