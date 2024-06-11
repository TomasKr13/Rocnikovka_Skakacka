using UnityEngine;
internal enum EntityDirection
{
    RIGHT,
    LEFT,
}

public class EntityBehaviour : MonoBehaviour
{
    [field: SerializeField] internal int LightAttackDamage { get; private set; } = 25;
    [field: SerializeField] internal float AttackDelay { get; private set; } = 1;
    [field: Range(0f, 5f)] public float AttackRange;

}