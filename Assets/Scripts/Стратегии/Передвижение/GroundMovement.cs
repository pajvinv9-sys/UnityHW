using UnityEngine;

public class GroundMovement : MovementBase
{
    private Vector3 linearVelocity;

    public override void Move()
    {
        if (!CanMove) return;

        linearVelocity = Rigidbody.linearVelocity;

        linearVelocity.x = direction.x * Speed;
        linearVelocity.z = direction.y * Speed;

        Rigidbody.linearVelocity = linearVelocity;
    }
}
