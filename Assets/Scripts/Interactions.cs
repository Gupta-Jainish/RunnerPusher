using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField] GameObject GameManager;

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
    }
    
    public void Left()
    {
        int j = GameManager.GetComponent<PositionManager>().PlayerCount();
        Debug.Log(j);
    }
}
