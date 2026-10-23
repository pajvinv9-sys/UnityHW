using UnityEngine;
[DisallowMultipleComponent]
public class HealLogicBase : MonoBehaviour
{
    public virtual void Do(HealthClass healthClass, float heal)
    {

    }

    public virtual float CalculateHeal(HealthClass healthClass, float heal)
    {
        return heal;
    }
}
