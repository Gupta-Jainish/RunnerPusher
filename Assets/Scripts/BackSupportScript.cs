using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSupportScript : MonoBehaviour
{
    Rigidbody rb;
    public bool PushBool;

    public void BackSupportTrigger()
    {
        GetComponent<Collider>().enabled = false;

    }

    void Update()
    {
        if (PushBool)
        {
            Push();

            Invoke("GameOver", 3f);
        }
            
    }



    public void pushBool()
    {
        PushBool = true;    
    }

    public void Push()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(0,0,-10);

    }
    
    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
