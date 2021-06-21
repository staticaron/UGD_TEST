// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/PauseMenuActionMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PauseMenuActionMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PauseMenuActionMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PauseMenuActionMap"",
    ""maps"": [
        {
            ""name"": ""PauseMenu"",
            ""id"": ""13fb5dff-8d5a-434e-8c7d-efda430def05"",
            ""actions"": [
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""b84ab3cc-44cb-4374-8f4e-f0ac8491ad5c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a19c1afd-ccad-4259-9711-b56551e71d17"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PauseMenu
        m_PauseMenu = asset.FindActionMap("PauseMenu", throwIfNotFound: true);
        m_PauseMenu_Restart = m_PauseMenu.FindAction("Restart", throwIfNotFound: true);
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

    // PauseMenu
    private readonly InputActionMap m_PauseMenu;
    private IPauseMenuActions m_PauseMenuActionsCallbackInterface;
    private readonly InputAction m_PauseMenu_Restart;
    public struct PauseMenuActions
    {
        private @PauseMenuActionMap m_Wrapper;
        public PauseMenuActions(@PauseMenuActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Restart => m_Wrapper.m_PauseMenu_Restart;
        public InputActionMap Get() { return m_Wrapper.m_PauseMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseMenuActions set) { return set.Get(); }
        public void SetCallbacks(IPauseMenuActions instance)
        {
            if (m_Wrapper.m_PauseMenuActionsCallbackInterface != null)
            {
                @Restart.started -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnRestart;
            }
            m_Wrapper.m_PauseMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
            }
        }
    }
    public PauseMenuActions @PauseMenu => new PauseMenuActions(this);
    public interface IPauseMenuActions
    {
        void OnRestart(InputAction.CallbackContext context);
    }
}
