using UnityEngine;
using UnityEngine.SceneManagement;

public class ZmenaScenyPoDoteku : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("stena"))
        {
            SceneManager.LoadScene("1LVL_2");
        }
        if (other.CompareTag("stena2"))
        {
            SceneManager.LoadScene("2LVL_2");
        }
        if (other.CompareTag("stena3"))
        {
            SceneManager.LoadScene("3LVL_2");
        }

    }
}
