using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class grabKey : MonoBehaviour
{
    private bool zamek = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("key"))
        {
            Destroy(other.gameObject); 
            zamek = false;
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Zamek");
            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }
        }
    }

    public bool IsZamekDestroyed()
    {
        return !zamek;
    }
}
