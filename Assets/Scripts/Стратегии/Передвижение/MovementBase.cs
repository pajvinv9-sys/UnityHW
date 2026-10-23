using JetBrains.Annotations;
using UnityEngine;

public abstract class MovementBase : MonoBehaviour
{
    protected Rigidbody Rigidbody;
    public bool IsMove => Rigidbody.linearVelocity.magnitude > 0.01f;
    [field: SerializeField] public bool CanMove { get; protected set; }
    [field: SerializeField] public float Speed { get; protected set; }

    protected Vector2 direction;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void Move()
    {
        if (!CanMove) return;
    }
    public void SetDirection(Vector2 value)
    {
        direction = Vector2.ClampMagnitude(value, 1f);
    }
}
