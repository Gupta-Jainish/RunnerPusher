using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField] GameObject GameManager;

    [SerializeField] int RightWeight;
    [SerializeField] int LeftWeight;    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<PlayerMovement>())
            {
                Debug.Log("Triggered With Player");

                if (other.transform.position.x >= 0)
                {
                    Debug.Log("Player Is At Right");
                    Right();
                }
                else
                {
                    Debug.Log("Player Is At Left");
                    Left();
                }
            }
        }
    }

    public void Right()
    {
        int j = GameManager.GetComponent<PositionManager>().PlayerCount();
        Debug.Log(j);

        if (RightWeight <= j)
        {
            Debug.Log("Pass Through");
        }
        else
        {
            Debug.Log("Game Over");
        }
    }
    
    public void Left()
    {
        int j = GameManager.GetComponent<PositionManager>().PlayerCount();
        Debug.Log(j);

        if (LeftWeight <= j)
        {
            Debug.Log("Pass Through");
        }
        else
        {
            Debug.Log("Game Over");
        }
    }
}
