using UnityEngine;

public class Creature : MonoBehaviour
{
    protected HealthClass Health;
    protected CreatureControl Controller;

    protected virtual void Awake()
    {
        Health = GetComponent<HealthClass>();

        if (Health == null)
            Health = gameObject.AddComponent<HealthClass>();

        Controller = GetComponent<CreatureControl>();

        if (Controller == null)
            Controller = gameObject.AddComponent<CreatureControl>();
    }

    protected virtual void Update()
    {
        Controller?.Tick();
    }

    protected virtual void FixedUpdate()
    {
        Controller?.PhysicsTick();
    }
}