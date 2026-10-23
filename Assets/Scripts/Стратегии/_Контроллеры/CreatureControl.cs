using UnityEngine;

public class CreatureControl : MonoBehaviour
{
    protected MovementBase MovementLogic;

    protected virtual void Awake()
    {
        MovementLogic = GetComponent<MovementBase>();
    }

    public virtual void Tick()
    {
        
    }

    public virtual void PhysicsTick()
    {
        MovementLogic?.Move();
    }

    public void SetMovementLogic(MovementBase movement)
    {
        MovementLogic = movement;
    }
}