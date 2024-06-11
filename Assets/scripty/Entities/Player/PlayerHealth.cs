using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI TimeText;
    private float currentTime = 0f; 
    [SerializeField]
    public int maxHealth = 100;
    public int CurrentHealth = 100;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (HealthText == null)
        {
            HealthText = GetComponent<TextMeshProUGUI>();
        }
        UpdateHealthText();
        if (TimeText == null)
        {
            TimeText = GetComponent<TextMeshProUGUI>();
        }
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        UpdateTimeText();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Voda"))
        {
            Zranit(100); 

        }
        if (collision.gameObject.CompareTag("Sip"))
        {
            Zranit(25);
        }
    }

    public void Zranit(int damage)
    {
        CurrentHealth -= damage;
        UpdateHealthText();
        if (CurrentHealth <= 0)
        {
            SpustitAnimaci();
            CurrentHealth = 0;
            Invoke("Timer", 0.01f);
            SceneManager.LoadScene("DeadMenu");

        }
        Debug.Log(CurrentHealth);
        UpdateHealthText();
    }
    public void Timer()
    {
        Time.timeScale = 0;
    }
    void SpustitAnimaci()
    {
        animator.SetTrigger("Death"); 

    }
    
 
    void UpdateHealthText()
    {
        HealthText.text = "Životy: " + CurrentHealth.ToString() + " / " + maxHealth.ToString();
    }

    public void UpdateHealth(int newHealth)
    {
        CurrentHealth = newHealth;

        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
        UpdateHealthText();
    }
    void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        TimeText.text = string.Format("Èas: {0:00}:{1:00}", minutes, seconds);
    }
}

