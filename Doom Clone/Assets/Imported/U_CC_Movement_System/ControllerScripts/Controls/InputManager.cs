using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField]
    PlayerController playerController;

    PlayerControls controls;
    PlayerControls.LocomotionInputActions locomotionInput;

    Vector2 horizontalInput;
    Vector2 mouseLookInput;

    float running = 0;
    float aiming = 0;

    [SerializeField] private GameEvent pauseInput;
    [SerializeField] private GameEvent actionEvent;
    [SerializeField] private GameEvent reloadEvent;
    [SerializeField] private GameEvent menu;
    [SerializeField] private GameEvent weaponSwapEvent;

    [SerializeField] private GameEvent slot1;
    [SerializeField] private GameEvent slot2;
    [SerializeField] private GameEvent slot3;
    [SerializeField] private GameEvent slot4;
    [SerializeField] private GameEvent slot5;

    [SerializeField] private GameEvent ability;

    public Vector3SO horizontalInputSO;


    private void Awake()
    {
        controls = new PlayerControls();
        locomotionInput = controls.LocomotionInput;

        // MOVEMENT INPUT //
        locomotionInput.Movement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        locomotionInput.Run.performed += ctx => running = ctx.ReadValue<float>();

        // MOUSE LOOK INPUT //
        locomotionInput.MouseX.performed += ctx => mouseLookInput.x = ctx.ReadValue<float>();
        locomotionInput.MouseY.performed += ctx => mouseLookInput.y = ctx.ReadValue<float>();

        // AIMING & ACTION INPUT //
        locomotionInput.Aim.performed += ctx => aiming = ctx.ReadValue<float>();
        locomotionInput.Action.performed += ctx => actionEvent.Raise();
        locomotionInput.Reload.performed += ctx => reloadEvent.Raise();
        locomotionInput.WeaponSwap.performed += ctx => weaponSwapEvent.Raise();

        // PAUSE INPUT //
        locomotionInput.Pause.performed += _ => pauseInput.Raise();

        // INTERACTION INPUT //
        locomotionInput.Interact.performed += _ => playerController.Interact();

        // INVENTORY //
        locomotionInput.Inventory.performed += ctx => menu.Raise();

        // SLOT SELECTION //
        locomotionInput.SelectSlot1.performed += _ => slot1.Raise();
        locomotionInput.SelectSlot2.performed += _ => slot2.Raise();
        locomotionInput.SelectSlot3.performed += _ => slot3.Raise();
        locomotionInput.SelectSlot4.performed += _ => slot4.Raise();
        locomotionInput.SelectSlot5.performed += _ => slot5.Raise();
        // locomotionInput.SelectSlot6.performed += _ => playerController.SelectSlot(6);

        // USE ABILITY //
        locomotionInput.Ability.performed += _ => ability.Raise();
    }

    private void Update()
    {
        playerController.ReceiveInput(horizontalInput, mouseLookInput, running, aiming);
        horizontalInputSO.value = new Vector3(horizontalInput.x, horizontalInput.y, 0f);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

}
