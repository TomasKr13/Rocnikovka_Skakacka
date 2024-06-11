using UnityEngine;

public class Truhla : MonoBehaviour
{
    [SerializeField]
    public GameObject tabulkaSItemy;

    private bool hracJeBlizko = false;

    void Update()
    {
        if (hracJeBlizko && Input.GetKeyDown(KeyCode.E))
        {
            OtevriTabulkuSItemy();
        }
    }
    void OtevriTabulkuSItemy()
    {
        tabulkaSItemy.SetActive(true); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hracJeBlizko = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hracJeBlizko = false;
        }
    }
}

