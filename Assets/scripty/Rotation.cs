using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    
    public float rychlostOtaceni = 50f;

    void Update()
    {
        transform.Rotate(Vector3.up, rychlostOtaceni * Time.deltaTime);
    }
}
