using UnityEngine;
[DisallowMultipleComponent]
public class TakeDamageLogicBase : MonoBehaviour
{
    public virtual void Do(HealthClass healthClass, float damage)
    {

    }

    public virtual float CalculateDamage(HealthClass healthClass, float damage)
    {
        return damage;
    }
}
