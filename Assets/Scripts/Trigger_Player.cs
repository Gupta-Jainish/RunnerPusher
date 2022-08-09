using UnityEngine;

public class Trigger_Player : MonoBehaviour
{
    //=====================================================================================================
    // Refrence To GameManager Object For Refrencing To GameManager Script
    //=====================================================================================================
    public GameObject GameManager;
    bool collectibleOnetime = true;
    //=====================================================================================================

    //=====================================================================================================
    // Triggers When Player Collects Collectibles
    //=====================================================================================================
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (collectibleOnetime)
            {
                Destroy(gameObject);
                // Fetching GameManager Scrit From GameManager Object
                GameManager.GetComponent<PositionManager>().AddParts();

                collectibleOnetime = false;
            }
        }
    }
    //=====================================================================================================
}
