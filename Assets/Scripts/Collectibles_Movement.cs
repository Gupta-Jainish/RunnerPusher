using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles_Movement : MonoBehaviour
{
    bool left = false;
    public float i;

    private void FixedUpdate()
    {

        if (transform.position.x >= 4)
        {
            left = true;
        }
        if (transform.position.x <= -4)
        {
            left = false;
        }

        if (left == false)
        {
            transform.position = transform.position + new Vector3(i, 0, 0);
        }
        if (left == true)
        {
            transform.position = transform.position + new Vector3(-i, 0, 0);
        }

    }
}
