using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField] GameObject GameManager;

    [SerializeField] int RightWeight;
    [SerializeField] int LeftWeight;    
    public bool OtherMovementStop = false;
    public bool SingleRun = true;

    [SerializeField] GameObject BackSupport;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<PlayerMovement>())
            {
                Debug.Log("Triggered With Player");
                if (SingleRun)
                {
                    if (other.transform.position.x >= 0)
                    {
                        Debug.Log("Player Is At Right");
                        PlayerIsAtRight();
                        if (OtherMovementStop)
                        {
                            other.gameObject.GetComponent<PlayerMovement>().ForwaredMovementStop();
                        }
                    }
                    else
                    {
                        Debug.Log("Player Is At Left");
                        PlayerIsAtLeft();
                        if (OtherMovementStop)
                        {
                            other.gameObject.GetComponent<PlayerMovement>().ForwaredMovementStop();
                        }

                    }SingleRun = false;
                }
            }
        }
    }

    public void PlayerIsAtRight()
    {
        int j = GameManager.GetComponent<PositionManager>().PlayerCount();
        Debug.Log(j);

        if (RightWeight <= j)
        {
            Debug.Log("Pass Through");
            BackSupport.GetComponent<BackSupportScript>().BackSupportTrigger();
        }
        else
        {
            Debug.Log("Game Over");
            OtherMovementStop = true;
            BackSupport.GetComponent<BackSupportScript>().pushBool();
        }
    }
    
    public void PlayerIsAtLeft()
    {
        int j = GameManager.GetComponent<PositionManager>().PlayerCount();
        Debug.Log(j);

        if (LeftWeight <= j)
        {
            Debug.Log("Pass Through");
            BackSupport.GetComponent<BackSupportScript>().BackSupportTrigger();
        }
        else
        {
            Debug.Log("Game Over");
            OtherMovementStop = true;
            BackSupport.GetComponent<BackSupportScript>().pushBool();
        }
    }
}
