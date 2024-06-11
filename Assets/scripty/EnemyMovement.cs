using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    internal EntityDirection EnemyDirection => ((movingRight) ? EntityDirection.RIGHT : EntityDirection.LEFT);

    public float moveSpeed = 3f; 
    public float moveTime = 2f; 
    public float waitTime = 2f; 

    private float moveTimer = 0f;
    private float waitTimer = 0f; 
    private bool movingRight = true;

    [SerializeField]
    public int maxHealth = 100;
    public int CurrentHealth = 100;
    private Animator animator;
    public float delayBeforeDisable = 5f;

    public Transform PlayerTransform;
    public float AgroRange;

    void Update()
    {
        float _distance = Vector2.Distance(PlayerTransform.position, transform.position);
        if (waitTimer > 0)
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0)
            {
                if (movingRight)
                {
                    movingRight = false;
                }
                else
                {
                    movingRight = true;
                }
            }
            return;
        }
        if (_distance <= AgroRange && _distance > 1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerTransform.position, Time.deltaTime * moveSpeed);
            if (transform.position.x > PlayerTransform.position.x)
                movingRight = false;
            else
                movingRight = true;
        }
        else if (moveTimer > 0)
        {
            moveTimer -= Time.deltaTime;

            if (movingRight)
            {
                transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + Vector2.right, moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + Vector2.left, moveSpeed * Time.deltaTime);
            }

            if (moveTimer <= 0)
            {
                waitTimer = waitTime;
            }
        }
        else 
        {
            moveTimer = moveTime;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Voda"))
        {
            Zranit(100);
        }
    }
    public void Zranit(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            // SpustitAnimaci();
            CurrentHealth = 0;
            moveSpeed = 0;
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
    }
}