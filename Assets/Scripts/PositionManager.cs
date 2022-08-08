using UnityEngine;
using System.Collections;
public class PositionManager : MonoBehaviour
{
    int mod;
    //=====================================================================================================
    // Initializations
    //=====================================================================================================
    [SerializeField] GameObject[] PositionList;
    [SerializeField] float GapBetween = 0;
    [SerializeField] float RightGap = 0;

    int i = 0;

    bool up = false;

    //=====================================================================================================

    //=====================================================================================================
    // Fixed Call In Every Devices
    //=====================================================================================================
    void FixedUpdate()
    {
        PosiManager();
        Rotation();

    }
    //=====================================================================================================

    //=====================================================================================================
    // Manages Positions
    //=====================================================================================================
    public void PosiManager()
    {
        PositionList = GameObject.FindGameObjectsWithTag("Player");

        for (i = 1; i < PositionList.Length; i++)
        {
            mod = i % 3;

            switch (mod)
            {

                case 0:
                    {
                        if (up == true)
                        {
                            for (int j = 0;j<1;j++)
                            { 
                                PositionList[j *3].transform.position = PositionList[j].transform.position;
                                PositionList[j].transform.position += new Vector3(0, 1, 0);
                                up = false;
                            }
                        }

                        PositionList[i].transform.position = PositionList[i - 1].transform.position + new Vector3(-RightGap,0,-GapBetween);
                        break;
                    }

                case 1:
                    {
                        PositionList[i].transform.position = PositionList[i - 1].transform.position + new Vector3(-RightGap, 0, 0);
                        break;
                    }

                case 2:
                    {
                        PositionList[i].transform.position = PositionList[i - 2].transform.position + new Vector3(RightGap,0,0);
                        break;
                    }

                /*case 0:
                    {
                        if (i == 1)
                        {
                            PositionList[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                        }

                        if (i == 2)
                        {
                            PositionList[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                        }

                        if (i < 1)
                        {
                            PositionList[i].transform.position = PositionList[i - 1].transform.position;
                        }

                        if (i > 1)
                        {
                            if (i > 3)
                            {
                                PositionList[i].transform.position = PositionList[i - 3].transform.position + new Vector3(0, 0, -GapBetween);
                            }
                            PositionList[i].transform.position = PositionList[i - 1].transform.position + new Vector3(-RightGap, 0, -GapBetween);
                            Vector3 point = PositionList[0].transform.position - PositionList[i].transform.position;
                            PositionList[i].transform.LookAt(point);
                        }
                        break;
                    }

                case 1:
                    {
                        if (i > 3)
                        {
                            PositionList[i].transform.position = PositionList[i - 3].transform.position + new Vector3(0, 0, -GapBetween);

                        }
                        else
                        {
                            PositionList[i].transform.position = PositionList[i - 1].transform.position - new Vector3(RightGap, 0, 0);
                        }
                        Vector3 point = PositionList[0].transform.position - PositionList[i].transform.position;
                        PositionList[i].transform.LookAt(point);
                        break;
                    }

                case 2:
                    {
                        if (i > 3)
                        {
                            PositionList[i].transform.position = PositionList[i - 3].transform.position + new Vector3(0, 0, -GapBetween);
                        }
                        else
                        {
                            PositionList[i].transform.position = PositionList[i - 2].transform.position - new Vector3(-RightGap, 0, 0);
                        }
                        Vector3 point = PositionList[0].transform.position - PositionList[i].transform.position;
                        PositionList[i].transform.LookAt(point);
                        break;
                    }*/


            }
        }
    }
    //=====================================================================================================

    public void Rotation()
    {
        for (int i=0; i<PositionList.Length; i++)
        {
        PositionList[i].transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public void Up()
    {
       up = true;
    }
}