using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Player : MonoBehaviour
{
    public GameObject GameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.GetComponent<GameManager>().AddTomato();
        }
    }
}
