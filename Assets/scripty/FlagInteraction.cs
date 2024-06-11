using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagInteraction : MonoBehaviour
{
    private bool playerInRange = false;
    private grabKey keyScript;

    private void Start()
    {
        keyScript = FindObjectOfType<grabKey>();
    }

    private void Update()
    {
        if (playerInRange && keyScript != null && keyScript.IsZamekDestroyed())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("LevelComplete");

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
