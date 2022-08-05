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
    int counter = 0;

    private float waitTime = 2.0f;
    private float timer = 0.0f;

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
        for (int i = 1; i < PositionList.Length; i++)
        {
            if (up == false)
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
                            if (i == 0)
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
                            PositionList[i].gameObject.transform.position = PositionList[i - 1].gameObject.transform.position - new Vector3(-RightGap, 0, 0);
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
                            PositionList[i].gameObject.transform.position = PositionList[i - 1].gameObject.transform.position - new Vector3(2 * (RightGap), 0, 0);
                            PositionList[i].gameObject.transform.rotation = PositionList[i - 1].gameObject.transform.rotation;
                            Vector3 point = PositionList[i].transform.position - PositionList[i - 1].transform.position;
                            PositionList[i].transform.LookAt(point);
                            break;
                        }
                        //=====================================================================================================

                }
            }
            if (up == true)
            {
                mod = i % 3;

                switch (mod)
                {
                    //=====================================================================================================
                    // For Center Pics
                    //=====================================================================================================
                    case 0:
                        {// Cheacks If It Is First Pics Or Not

                            timer += Time.deltaTime;
                       
                            if(counter < PositionList.Length / 3)
                                {
                                if (timer > waitTime)
                                {
                                    if (i == 0)
                                    {
                                        Vector3 A = PositionList[i - 1].gameObject.transform.position - new Vector3(0, 0, GapBetween);
                                        PositionList[i].transform.position = Vector3.Slerp(PositionList[i - 1].transform.position, A, Delay);
                                        PositionList[i].gameObject.transform.rotation = new Quaternion(0, 0, 0, 1);
                                        Vector3 point = PositionList[i].transform.position - PositionList[i - 1].transform.position;
                                        PositionList[i].transform.LookAt(point);
                                        PositionList[i].GetComponent<Rigidbody>().useGravity = false;


                                    }
                                    else
                                    {
                                        Vector3 A = PositionList[i - 1].gameObject.transform.position - new Vector3(-RightGap, -2, 0);
                                        PositionList[i].transform.position = Vector3.Slerp(PositionList[i-1].transform.position, A, Delay);
                                        PositionList[i].gameObject.transform.rotation = PositionList[i - 1].gameObject.transform.rotation;
                                        Vector3 point = PositionList[i].transform.position - PositionList[i - 1].transform.position;
                                        PositionList[i].transform.LookAt(point);
                                        PositionList[i].GetComponent<Rigidbody>().useGravity = false;

                                    }
                                    timer = 0;
                                    counter++;
                                }
                                
                            }
                            if (counter >= PositionList.Length / 3)
                            {
                                if (i == 0)
                                {
                                    Vector3 A = PositionList[i - 1].gameObject.transform.position - new Vector3(0, 0, GapBetween);
                                    PositionList[i].transform.position = Vector3.Slerp(PositionList[i - 1].transform.position, A, Delay);
                                    PositionList[i].gameObject.transform.rotation = new Quaternion(0, 0, 0, 1);
                                    Vector3 point = PositionList[i].transform.position - PositionList[i - 1].transform.position;
                                    PositionList[i].transform.LookAt(point);
                                    PositionList[i].GetComponent<Rigidbody>().useGravity = false;


                                }
                                else
                                {
                                    Vector3 A = PositionList[i - 1].gameObject.transform.position - new Vector3(-RightGap, -2, 0);
                                    PositionList[i].transform.position = Vector3.Slerp(PositionList[i - 1].transform.position, A, Delay);
                                    PositionList[i].gameObject.transform.rotation = PositionList[i - 1].gameObject.transform.rotation;
                                    Vector3 point = PositionList[i].transform.position - PositionList[i - 1].transform.position;
                                    PositionList[i].transform.LookAt(point);
                                    PositionList[i].GetComponent<Rigidbody>().useGravity = false;

                                }
                                timer = 0;
                                counter++;
                            }



                            break;

                        }
                    //=====================================================================================================    

                    //=====================================================================================================
                    // For Left Pics
                    //=====================================================================================================
                    case 1:
                        {
                            Vector3 A = PositionList[i - 1].gameObject.transform.position - new Vector3(-RightGap, 0, 0);
                            PositionList[i].transform.position = Vector3.Slerp(PositionList[i - 1].transform.position, A, Delay);
                            Vector3 point = PositionList[i].transform.position - PositionList[i - 1].transform.position;
                            PositionList[i].transform.LookAt(point);
                            PositionList[i].GetComponent<Rigidbody>().useGravity = false;

                            break;
                        }
                    //=====================================================================================================    

                    //=====================================================================================================
                    // For Right Pics
                    //=====================================================================================================
                    case 2:
                        {
                            Vector3 A = PositionList[i - 1].gameObject.transform.position - new Vector3(2 * (RightGap), 0, 0);
                            PositionList[i].transform.position = Vector3.Slerp(PositionList[i - 1].transform.position, A, Delay);
                            Vector3 point = PositionList[i].transform.position - PositionList[i - 1].transform.position;
                            PositionList[i].transform.LookAt(point);
                            PositionList[i].GetComponent<Rigidbody>().useGravity = false;

                            break;
                        }
                        //=====================================================================================================

                }
            }
            

            //=====================================================================================================
            // Sets Rotations Uniform And Front Towards Z Axis Of All The Pics
            //=====================================================================================================
            PositionList[i].transform.rotation = new Quaternion(0, 0, 0, 0);
            //=====================================================================================================


        }
    }
    //=====================================================================================================


    public void Up()
    {
        up = true;
    }
}