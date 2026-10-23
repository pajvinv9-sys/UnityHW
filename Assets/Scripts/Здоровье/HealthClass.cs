using UnityEngine;

public class HealthClass: MonoBehaviour, IDamagable
{
    [field: SerializeField, Min(0)] public float Health { get; private set; }

    [field: SerializeField]
    public MaxHealth MaxHealthConfig { get; private set; }

    public float MaxHealth => MaxHealthConfig != null
        ? MaxHealthConfig.Value
        : 0f;


    [field: SerializeField] TakeDamageLogicBase TakeDamageLogic { get; set; }
    [field: SerializeField] DeathLogicBase DeathLogic { get; set; }
    [field: SerializeField] HealLogicBase HealLogic { get; set; }

    private bool isDead;

    private void Awake()
    {
        TakeDamageLogic ??= GetComponent<TakeDamageLogicBase>();
        DeathLogic ??= GetComponent<DeathLogicBase>();
        HealLogic ??= GetComponent<HealLogicBase>();

        if (MaxHealthConfig == null || MaxHealth <= 0)
        {
            Debug.LogError(
                $"MaxHealth не назначен для {gameObject.name}",
                this
            );
            enabled = false;
            return;
        }

        Health = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (isDead || damage <= 0)
            return;

        float finalDamage =
            Mathf.Max(0, TakeDamageLogic.CalculateDamage(this, damage));

        if (finalDamage <= 0)
            return;

        Health -= finalDamage;
        TakeDamageLogic.Do(this, finalDamage);

        if (Health <= 0)
        {
            isDead = true;
            DeathLogic.Do();
        }
    }

    public void Heal(float heal)
    {
        if (heal <= 0 || Health <= 0)
            return;

        float finalHeal = HealLogic.CalculateHeal(this, heal);
        finalHeal = Mathf.Clamp(finalHeal, 0, MaxHealth - Health);

        if (finalHeal <= 0)
            return;

        Health += finalHeal;
        HealLogic.Do(this, finalHeal);
    }
}
