using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollisionCheck : MonoBehaviour
{
    [SerializeField] AudioSource keyPickupSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            keyPickupSound.Play();
        }
    }
}