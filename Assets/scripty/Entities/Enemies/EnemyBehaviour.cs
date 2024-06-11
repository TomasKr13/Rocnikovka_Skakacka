using UnityEngine;

//[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(Animator))]
public class EnemyBehaviour : EntityBehaviour
{
    private float m_CurrentAttackDelay = 0;
    private EnemyMovement m_PlayerMovement;
    private Animator m_Animator;
    private void Start()
    {
        m_PlayerMovement = GetComponent<EnemyMovement>();
        m_Animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
        m_CurrentAttackDelay += Time.deltaTime;

        if (m_CurrentAttackDelay >= this.AttackDelay)
            Attack();
    }

    protected virtual void Move()
    {

    }
    protected virtual void Attack()
    {
        if (m_PlayerMovement != null)
        {
            RaycastHit2D _enemy = Physics2D.Raycast(transform.position, (((m_PlayerMovement.EnemyDirection == EntityDirection.RIGHT) ? Vector3.right : Vector3.left) * this.AttackRange), this.AttackRange);
            m_Animator.SetTrigger("Attack");
            if (_enemy)
            {
                if (_enemy.collider.CompareTag("Player"))
                    _enemy.collider.gameObject.GetComponent<PlayerHealth>().Zranit(this.LightAttackDamage);
            }
            m_CurrentAttackDelay = 0;
        }
    }
}