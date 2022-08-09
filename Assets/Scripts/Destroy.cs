using UnityEngine;

public class Destroy : MonoBehaviour
{
    bool onetime = true;
    //=====================================================================================================
    // Triggers When Player Colides With Enemy Object
    //=====================================================================================================
    private void OnCollisionEnter(Collision collision)
    {
        if (onetime)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                onetime = false;
            }
            
        }
    }
    //=====================================================================================================
}