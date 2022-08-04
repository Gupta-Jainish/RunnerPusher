using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject[] CubeList;

    //=====================================================================================================
    // Fixed Call In Every Devices
    //=====================================================================================================
    void FixedUpdate()
    {
        // Finding Player With Tag
        CubeList = GameObject.FindGameObjectsWithTag("Player");
        if (CubeList.Length > 0)
        {
            //=====================================================================================================
            // Main Camera Movement Referencing to the CubeList[0] If It Exists
            //=====================================================================================================
            transform.position = new Vector3(transform.position.x, transform.position.y, CubeList[0].transform.position.z - 15);
            //=====================================================================================================
        }
    }
    //=====================================================================================================
}
