using UnityEngine;

public class Trigger_Player : MonoBehaviour
{
    //=====================================================================================================
    // Refrence To GameManager Object For Refrencing To GameManager Script
    //=====================================================================================================
    public GameObject GameManager;
    //=====================================================================================================

    //=====================================================================================================
    // Triggers When Player Collects Collectibles
    //=====================================================================================================
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            // Fetching GameManager Scrit From GameManager Object
              //GameManager.GetComponent<GameManager>().AddTomato();
        }
    }
    //=====================================================================================================
}
