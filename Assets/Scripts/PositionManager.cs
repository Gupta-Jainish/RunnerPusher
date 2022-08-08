using UnityEngine;

public class PositionManager : MonoBehaviour
{
    int mod;
    //=====================================================================================================
    // Initializations
    //=====================================================================================================
    [SerializeField] GameObject[] PositionList;
    [SerializeField] float GapBetween = 2;
    [SerializeField] float RightGap = 2;
    [SerializeField] float Delay = 50;

    private float waitTime = 2.0f;
    private float timer = 0.0f;
    int i = 0;

    bool up = false;

    //=====================================================================================================

    //=====================================================================================================
    // Fixed Call In Every Devices
    //=====================================================================================================
    void FixedUpdate()
    {
        PosiManager();
    }
    //=====================================================================================================

    //=====================================================================================================
    // Manages Positions
    //=====================================================================================================
    public void PosiManager()
    {
        PositionList = GameObject.FindGameObjectsWithTag("Player");

        for (i = 1;i<PositionList.Length;i++)
        {
            PositionList[i].transform.position = PositionList[i-1].transform.position - new Vector3(0,0,GapBetween);
        }

            //=====================================================================================================
            // Sets Rotations Uniform And Front Towards Z Axis Of All The Pics
            //=====================================================================================================
            // PositionList[i].transform.rotation = new Quaternion(0, 0, 0, 0);
            //=====================================================================================================
    }
    //=====================================================================================================


    public void Up()
    {
        up = true;
    }
}