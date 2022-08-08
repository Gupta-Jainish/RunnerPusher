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
            mod = i % 3;

            switch (mod)
            {
                case 0:
                    {
                        if (i <1)
                        {
                            PositionList[i].transform.position = PositionList[i - 1].transform.position; 
                        }
                        if (i>1)
                        {
                            PositionList[i].transform.position = PositionList[i - 1].transform.position + new Vector3(-2,0,-GapBetween);
                        }
                        break;
                    }

                case 1:
                    {
                        PositionList[i].transform.position = PositionList[i - 1].transform.position - new Vector3(2, 0, 0);
                        break;
                    }
                case 2:
                    {
                        PositionList[i].transform.position = PositionList[i - 1].transform.position - new Vector3(-4, 0, 0);
                        break;
                    }
            }
            //=====================================================================================================
            // Sets Rotations Uniform And Front Towards Z Axis Of All The Pics
            //=====================================================================================================

            PositionList[i].transform.rotation = new Quaternion(0, 0, 0, 0);
            //=====================================================================================================
            //  PositionList[i].transform.position = PositionList[i-1].transform.position - new Vector3(0,0,GapBetween);
        }


    }
    //=====================================================================================================


    public void Up()
    {
        up = true;
    }
}