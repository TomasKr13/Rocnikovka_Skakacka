using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject SipObject; 
    public Transform ShootingPlace; 

    private float casMeziVystrely = 3f; 
    private float casDoDalsihoVystrelu = 0f; 
    private float silaStrely = 10f; 

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

        Rigidbody2D sipRigidbody = novySip.GetComponent<Rigidbody2D>();
        if (sipRigidbody != null)
        {
            sipRigidbody.velocity = -transform.right * silaStrely;
            
        }
    }
}
