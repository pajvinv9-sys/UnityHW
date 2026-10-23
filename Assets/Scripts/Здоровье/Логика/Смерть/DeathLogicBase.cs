using UnityEngine;
[DisallowMultipleComponent]
public class DeathLogicBase : MonoBehaviour
{
    public virtual void Do()
    {
        Destroy(gameObject);
    }
}
