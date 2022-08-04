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
        for (int i = 1; i < PositionList.Length; i++)
        {
            mod = i % 3;

            switch (mod)
            {
                //=====================================================================================================
                // For Center Pics
                //=====================================================================================================
                case 0:
                    {
                        // Cheacks If It Is First Pics Or Not
                        if (i==0)
                        {
                            PositionList[i].gameObject.transform.position = PositionList[i - 1].gameObject.transform.position - new Vector3(0, 0, GapBetween);
                            PositionList[i].gameObject.transform.rotation = new Quaternion(0, 0, 0, 1);
                            Vector3 point = PositionList[i].transform.position - PositionList[i - 1].transform.position;
                            PositionList[i].transform.LookAt(point);
                            
                        }
                        else
                        {
                            PositionList[i].gameObject.transform.position = PositionList[i - 1].gameObject.transform.position - new Vector3(-RightGap, 0, GapBetween);
                            PositionList[i].gameObject.transform.rotation = PositionList[i - 1].gameObject.transform.rotation;
                            Vector3 point = PositionList[i].transform.position - PositionList[i - 1].transform.position;
                            PositionList[i].transform.LookAt(point);
                        }
                        break;
                        
                    }
                //=====================================================================================================    

                //=====================================================================================================
                // For Left Pics
                //=====================================================================================================
                case 1:
                    {
                        PositionList[i].gameObject.transform.position = PositionList[i - 1].gameObject.transform.position - new Vector3(-RightGap, 0,0);
                        PositionList[i].gameObject.transform.rotation = PositionList[i - 1].gameObject.transform.rotation;
                        Vector3 point = PositionList[i].transform.position - PositionList[i - 1].transform.position;
                        PositionList[i].transform.LookAt(point);
                        break;
                    }
                //=====================================================================================================    

                //=====================================================================================================
                // For Right Pics
                //=====================================================================================================
                case 2:
                    {
                        PositionList[i].gameObject.transform.position = PositionList[i - 1].gameObject.transform.position - new Vector3(2*(RightGap), 0,0);
                        PositionList[i].gameObject.transform.rotation = PositionList[i - 1].gameObject.transform.rotation;
                        Vector3 point = PositionList[i].transform.position - PositionList[i - 1].transform.position;
                        PositionList[i].transform.LookAt(point);
                        break;
                    }
                //=====================================================================================================

            }

            //=====================================================================================================
            // Sets Rotations Uniform And Front Towards Z Axis Of All The Pics
            //=====================================================================================================
            PositionList[i].transform.rotation = new Quaternion(0, 0, 0, 0);
            //=====================================================================================================


        }
    }
    //=====================================================================================================
}