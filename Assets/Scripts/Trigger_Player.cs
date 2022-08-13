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
            if (other.GetComponent<PlayerMovement>())
            {
                if (gameObject.tag == "+1")
                {
                    Destroy(gameObject);
                    if (collectibleOnetime)
                    {
                        Destroy(gameObject);
                        for (int i = 0; i < 1; i++)
                        {
                            // Fetching GameManager Scrit From GameManager Object
                            GameManager.GetComponent<PositionManager>().AddParts();
                        }
                        GameManager.GetComponent<GameManager>().ScoreManager(1);
                        collectibleOnetime = false;
                        Debug.Log("+1");

                    }
                }
                if (gameObject.tag == "+2")
                {
                    Destroy(gameObject);
                    if (collectibleOnetime)
                    {
                        Destroy(gameObject);
                        for (int i = 0; i < 2; i++)
                        {
                            // Fetching GameManager Scrit From GameManager Object
                            GameManager.GetComponent<PositionManager>().AddParts();
                        }
                        GameManager.GetComponent<GameManager>().ScoreManager(2);
                        collectibleOnetime = false;
                        Debug.Log("+2");
                    }
                }
                if (gameObject.tag == "+10")
                {
                    Destroy(gameObject);
                    if (collectibleOnetime)
                    {
                        Destroy(gameObject);
                        for (int i = 0; i < 10; i++)
                        {
                            // Fetching GameManager Scrit From GameManager Object
                            GameManager.GetComponent<PositionManager>().AddParts();
                        }
                        GameManager.GetComponent<GameManager>().ScoreManager(10);
                        collectibleOnetime = false;
                        Debug.Log("+10");


                    }
                }
                if (gameObject.tag == "+20")
                {
                    Destroy(gameObject);
                    if (collectibleOnetime)
                    {
                        Destroy(gameObject);
                        for (int i = 0; i < 20; i++)
                        {
                            // Fetching GameManager Scrit From GameManager Object
                            GameManager.GetComponent<PositionManager>().AddParts();
                            
                        }
                        GameManager.GetComponent<GameManager>().ScoreManager(20);
                        collectibleOnetime = false;
                        Debug.Log("+20");


                    }
                }
                if (gameObject.tag == "Collectibles")
                {
                    if (collectibleOnetime)
                    {
                        Destroy(gameObject);
                        // Fetching GameManager Scrit From GameManager Object
                        GameManager.GetComponent<PositionManager>().AddParts();
                        collectibleOnetime = false;
                        Debug.Log("Added 1");

                    }
                }
            }

        }
    }
    //=====================================================================================================
}
