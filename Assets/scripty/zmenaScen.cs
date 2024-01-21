using UnityEngine;
using UnityEngine.SceneManagement;

public class ZmenaScenyPoDoteku : MonoBehaviour
{
    public string nazevNoveSceny;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("stena"))
            {
                SceneManager.LoadScene(nazevNoveSceny);
            }
        }
    }
}
