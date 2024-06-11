using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MageBoss : EnemyBehaviour
{
    [field: Header("Movement")]
    [field: SerializeField] public float AgroRange { get; private set; } = 5f;
    [field: SerializeField] public float OffsetRange { get; private set; } = 3f;
    [field: SerializeField] public float MovementSpeed { get; private set; } = 3f;

    [field: Header("Shooting")]
    [field: SerializeField] public Transform ShootingPoint { get; private set; }
    [field: SerializeField] public GameObject BulletPrefab { get; private set; }
    [field: SerializeField] public float BulletForce { get; private set; } = 3f;
    [field: SerializeField] public float AttackCooldown { get; private set; } = 3f;

    [field: SerializeField] Transform m_PlayerTransform;

    private float m_DistanceFromPlayer = 0f;
    private EntityDirection m_DirectionRelativeToPlayer;
    private float m_CurrentAttackCooldown = 0;
    [SerializeField]
    public int maxHealth = 100;
    public int CurrentHealth = 100;
    private Animator animator;
    public float delayBeforeDisable = 3f;
    private void FixedUpdate()
    {
        m_CurrentAttackCooldown -= Time.deltaTime;

        m_DirectionRelativeToPlayer = (transform.position.x > m_PlayerTransform.position.x) ? EntityDirection.RIGHT : EntityDirection.LEFT;
        
        transform.localScale = (m_DirectionRelativeToPlayer == EntityDirection.RIGHT) ? new Vector3(4, 4, 0) : new Vector3(-4, 4, 0);
        m_DistanceFromPlayer = Vector2.Distance(m_PlayerTransform.position, transform.position);
        Move();

        if (m_DistanceFromPlayer < AgroRange && m_DistanceFromPlayer > OffsetRange)
            Attack();
    }

    protected override void Move()
    {
        if (m_DistanceFromPlayer < OffsetRange)
        {

            if (transform.position.x > 8)
            {
                transform.position = new Vector3(Random.Range(-9f, 3f), 0, 0);
            }
            else if (transform.position.x < -10)
            {
                transform.position = new Vector3(Random.Range(3f, 7.5f), 0, 0);
            }
            else
            {
                Vector3 _direction = (m_DirectionRelativeToPlayer == EntityDirection.RIGHT) ? Vector3.right : Vector3.left;
                transform.position = Vector2.MoveTowards(transform.position, transform.position + _direction, Time.deltaTime * MovementSpeed);
            }
        }
    }

    protected override void Attack()
    {
        if (m_CurrentAttackCooldown <= 0)
        {
            Vector3 _force = (m_PlayerTransform.position - ShootingPoint.position).normalized * BulletForce;
            Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint.rotation).GetComponent<Rigidbody2D>().AddForce(_force);
            m_CurrentAttackCooldown = AttackCooldown;
        }
    }
    public void Zranit(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            // SpustitAnimaci();
            CurrentHealth = 0;
            Destroy(GetComponent<Collider2D>());
            Invoke("DisableSelf", delayBeforeDisable);

        }
        Debug.Log(CurrentHealth);
    }
    void SpustitAnimaci()
    {
        animator.SetTrigger("Death");
    }

    public void UpdateHealth(int newHealth)
    {
        CurrentHealth = newHealth;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
    }
    void DisableSelf()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("WinnerMenu");

    }

}