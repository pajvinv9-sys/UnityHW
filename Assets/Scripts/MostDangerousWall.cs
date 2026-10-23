using UnityEngine;

public class MostDangerousWall : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        var idamagable = collision.gameObject.GetComponent<IDamagable>();

        if (idamagable == null) 
            return;

        idamagable.TakeDamage(damage);
    }
}
