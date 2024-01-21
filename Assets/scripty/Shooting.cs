using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject SipObject;
    public Transform ShootingPlace;

    private float casMeziVystrely = 3f;
    private float casDoDalsihoVystrelu = 0f;

    void Update()
    {
        casDoDalsihoVystrelu -= Time.deltaTime;

        if (casDoDalsihoVystrelu <= 0f)
        {
            VystrelitSip();
            casDoDalsihoVystrelu = casMeziVystrely;
        }
    }

    void VystrelitSip()
    {
        
        GameObject novySip = Instantiate(SipObject, ShootingPlace.position, ShootingPlace.rotation);

 
        Rigidbody sipRigidbody = novySip.GetComponent<Rigidbody>();
        if (sipRigidbody != null)
        {
            sipRigidbody.AddForce(ShootingPlace.forward * 5000f);
        }
        
    }
}

