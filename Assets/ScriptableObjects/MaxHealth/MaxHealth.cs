
using UnityEngine;

[CreateAssetMenu(
    fileName = "MaxHealth",
    menuName = "Scriptable Objects/Max Health"
)]
public class MaxHealth : ScriptableObject
{
    [field: Header("Identity")]
    [field: SerializeField] public string EntityName { get; private set; }

    [field: Header("Health Settings")]
    [field: SerializeField, Min(1)]
    public float Value { get; private set; } = 100f;
}
