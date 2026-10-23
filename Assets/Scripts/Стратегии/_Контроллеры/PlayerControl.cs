using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : CreatureControl
{
    [SerializeField] private InputAction MoveKeys;

    private void OnEnable()
    {
        MoveKeys.Enable();
    }

    private void OnDisable()
    {
        MoveKeys.Disable();
    }

    public override void Tick()
    {
        base.Tick();

        Vector2 input = MoveKeys.ReadValue<Vector2>();

        MovementLogic?.SetDirection(input);
    }
}