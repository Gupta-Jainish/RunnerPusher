using System.Collections.Generic;
using UnityEngine;
public class PositionManager : MonoBehaviour
{
    //=====================================================================================================
    // Initializations
    //=====================================================================================================
    [SerializeField] List<GameObject> Live_BodyList = new List<GameObject>();
    [SerializeField] List<GameObject> Sec_BodyList = new List<GameObject>();
    [SerializeField] GameObject BodyPrefab;
    int mod;
    int Bodycount;

    int ModFinal;

    float countup = 0;
    //=====================================================================================================

    private void Start()
    {
        AddParts();
        AddParts();
    }

    //=====================================================================================================
    // Fixed Call In Every Devices
    //=====================================================================================================

    void FixedUpdate()
    {
        ManageBody();
        Movement();
    }
    //=====================================================================================================

    //=====================================================================================================
    // Manages Positions
    //=====================================================================================================
    void ManageBody()
    {
        if (Sec_BodyList.Count > 0)
        {
            CreateBodyParts();
        }
        for (int i = 0; i < Live_BodyList.Count; i++)
        {
            if (Live_BodyList[i] == null)
            {
                Live_BodyList.RemoveAt(i);

                i--;
            }
        }
        if (Live_BodyList.Count == 0)
        {
            Destroy(this);
        }
    }
    //=======================================================================================================

    public void CreateBodyParts()
    {
        if (Live_BodyList.Count == 0)
        {
            GameObject temp1 = Instantiate(Sec_BodyList[0], transform.position, transform.rotation, transform);

            if (!temp1.GetComponent<MarkerManager>())
            {
                temp1.AddComponent<MarkerManager>();
            }
            if (!temp1.GetComponent<Rigidbody>())
            {
                temp1.AddComponent<Rigidbody>();
            }
            Live_BodyList.Add(temp1);
            Sec_BodyList.RemoveAt(0);
        }

        MarkerManager markM = Live_BodyList[Live_BodyList.Count - 1].GetComponent<MarkerManager>();

        if (countup == 0)
        {
            markM.ClearMarkerList();
        }
        countup += Time.deltaTime;

        GameObject temp = Instantiate(Sec_BodyList[0], markM.markerList[0].position, markM.markerList[0].rotation, transform);

        if (!temp.GetComponent<MarkerManager>())
        {
            temp.AddComponent<MarkerManager>();
        }
        if (!temp.GetComponent<Rigidbody>())
        {
            temp.AddComponent<Rigidbody>();
        }
        Live_BodyList.Add(temp);
        Sec_BodyList.RemoveAt(0);
        temp.GetComponent<MarkerManager>().ClearMarkerList();
        countup = 0;

    }

    public void AddParts()
    {
        Sec_BodyList.Add(BodyPrefab);
    }

    public void Movement()
    {

        if (Live_BodyList.Count > 0)
        {
            if (!Live_BodyList[0].GetComponent<PlayerMovement>())
            {
                Live_BodyList[0].AddComponent<PlayerMovement>();
            }
        }


        if (Live_BodyList.Count > 1)
        {
            for (int i = 1; i < Live_BodyList.Count; i++)
            {

                if (i > 1|| i == 1)
                {
                    RotationLock();
                    mod = i % 3;
                    switch (mod)
                    {
                        case 0:
                            {
                                MarkerManager markM = Live_BodyList[i - 1].GetComponent<MarkerManager>();
                                Live_BodyList[i].transform.position = markM.markerList[0].position - new Vector3(1, 0, 1);
                                Live_BodyList[i].transform.rotation = markM.markerList[0].rotation;
                                Vector3 point = Live_BodyList[i].transform.position - Live_BodyList[i - 1].transform.position;
                                Live_BodyList[i].transform.LookAt(point);
                                markM.markerList.RemoveAt(0);
                                break;
                            }
                        case 1:
                            {
                                MarkerManager markM = Live_BodyList[i - 1].GetComponent<MarkerManager>();
                                Live_BodyList[i].transform.position = markM.markerList[0].position - new Vector3(1, 0, 0);
                                Live_BodyList[i].transform.rotation = markM.markerList[0].rotation;
                                Vector3 point = Live_BodyList[i].transform.position - Live_BodyList[i - 1].transform.position;
                                Live_BodyList[i].transform.LookAt(point);
                                markM.markerList.RemoveAt(0);
                                break;
                            }
                        case 2:
                            {
                                MarkerManager markM = Live_BodyList[i - 1].GetComponent<MarkerManager>();
                                Live_BodyList[i].transform.position = markM.markerList[0].position - new Vector3(-2, 0, 0);
                                Live_BodyList[i].transform.rotation = markM.markerList[0].rotation;
                                Vector3 point = Live_BodyList[i].transform.position - Live_BodyList[i - 1].transform.position;
                                Live_BodyList[i].transform.LookAt(point);
                                markM.markerList.RemoveAt(0);
                                break;
                            }
                    }
                }
            }
        }
    }

    public void RotationLock()
    {
        if (Live_BodyList.Count >= 1)
        {
            for (int i = 0; i < Live_BodyList.Count; i++)
            {
                Live_BodyList[i].transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }


    public void Finisher()
    {
        Bodycount = Live_BodyList.Count;
        if (Bodycount > 3)
        {
            

            ModFinal = (Bodycount - 1) % 3;

            Debug.Log(ModFinal);
            switch (ModFinal)
            {
                case 0:
                    {
                        for (int i = Bodycount - 1; i > Bodycount - 4; i--)
                        {
                            Live_BodyList.RemoveAt(i);
                        }
                        break;
                    }
                case 1:
                    {
                        for (int i = Bodycount - 1; i > Bodycount - 2; i--)
                        {
                            Live_BodyList.RemoveAt(i);
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = Bodycount - 1; i > Bodycount - 3; i--)
                        {
                            Live_BodyList.RemoveAt(i);
                        }
                        break;
                    }
            }
        }

        if (Bodycount <= 3)
        {
            
            Debug.Log("Body <= 3");
        }
        
    }

}