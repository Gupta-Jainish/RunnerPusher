using UnityEngine;

public class Destroy : MonoBehaviour
{
    //=====================================================================================================
    // Triggers When Player Colides With Enemy Object
    //=====================================================================================================
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    //=====================================================================================================
}
