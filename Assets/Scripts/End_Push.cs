using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Push : MonoBehaviour
{
    [SerializeField] GameObject GameManager;
    bool End = true;
    private void OnTriggerEnter(Collider other)
    {
        if (End == true)
        {
            if (other.gameObject.tag == "Player")
            {
                GameManager.GetComponent<PositionManager>().Up();
                End = false;
            }
        }
        
    }
}
