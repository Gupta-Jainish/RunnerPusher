using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject[] CubeList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CubeList = GameObject.FindGameObjectsWithTag("Player");
        if (CubeList.Length > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, CubeList[0].transform.position.z - 15);
        }
    }
}
