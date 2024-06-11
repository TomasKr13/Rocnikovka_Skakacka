using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Animator))]
public class PlayerBehaviour : EntityBehaviour
{
    [field: SerializeField] internal int HeavyAttackDamage { get; private set; } = 50;
    [SerializeField] public AudioSource swordSound;
    private float m_CurrentAttackDelay = 0;
    private PlayerMovement m_PlayerMovement;
    private Animator m_Animator;
    private void Start()
    {
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_Animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        m_CurrentAttackDelay += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && m_CurrentAttackDelay >= this.AttackDelay)
            Attack(false);
        else if (Input.GetMouseButtonDown(1) && m_CurrentAttackDelay >= this.AttackDelay)
            Attack(true);
    }

    private void Attack(bool isHeavyAttack)
    {
        RaycastHit2D _enemy = Physics2D.Raycast(transform.position, (((m_PlayerMovement.PlayerDirection == EntityDirection.RIGHT) ? Vector3.right : Vector3.left) * this.AttackRange), this.AttackRange);
        m_Animator.SetTrigger((isHeavyAttack) ? "HeavyAttack" : "LightAttack");
        swordSound.Play();
        if (_enemy)
        {
            if (_enemy.collider.CompareTag("Enemy"))
            {
                _enemy.collider.gameObject.GetComponent<EnemyMovement>().Zranit((isHeavyAttack) ? this.HeavyAttackDamage : this.LightAttackDamage);
            }
        }
        m_CurrentAttackDelay = 0;
    }
}