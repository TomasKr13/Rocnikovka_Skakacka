using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera_Pohyb : MonoBehaviour
{
    public Transform postava;  
    public float vyska = 3f;
    public float citlivost = 1f;

    private void Update()
    {
        float vstup = Input.GetAxis("Vertical");
        float Vyska = postava.position.y + vyska + vstup * citlivost;
        if (Vyska>= 15)
        {

        }
        else
        {
            transform.position = new Vector3(transform.position.x, Vyska, transform.position.z);
        }
        
    }
}
