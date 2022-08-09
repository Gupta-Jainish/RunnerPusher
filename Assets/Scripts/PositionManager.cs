using UnityEngine;
using System.Collections.Generic;
public class PositionManager : MonoBehaviour
{
    //=====================================================================================================
    // Initializations
    //=====================================================================================================
    [SerializeField] List<GameObject> Live_BodyList = new List<GameObject>();
    [SerializeField] List<GameObject> Sec_BodyList = new List<GameObject>();
    [SerializeField] GameObject BodyPrefab;
   // [SerializeField] float GapBetween = 0;
   // [SerializeField] float RightGap = 0;

    float countup = 0;
    //=====================================================================================================

    private void Start()
    {
        AddBodyParts();
        AddBodyParts();
    }

    //=====================================================================================================
    // Fixed Call In Every Devices
    //=====================================================================================================

    void FixedUpdate()
    {
        Movement();
        ManageSnakeBody();

        if (Live_BodyList.Count > 0)
        {
            if (!Live_BodyList[0].GetComponent<PlayerMovement>())
            {
                Live_BodyList[0].AddComponent<PlayerMovement>();
            }
        }
        

    }
    //=====================================================================================================

    //=====================================================================================================
    // Manages Positions
    //=====================================================================================================
    void ManageSnakeBody()
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

    public void AddBodyParts()
    {
        Sec_BodyList.Add(BodyPrefab);
    }

    public void Movement()
    {
        if (Live_BodyList.Count > 1)
        {
            for (int i = 1; i < Live_BodyList.Count; i++)
            {
                if (i>=1)
                {
                    MarkerManager markM = Live_BodyList[i - 1].GetComponent<MarkerManager>();
                    Live_BodyList[i].transform.position = markM.markerList[0].position - new Vector3(0,0,1);
                    //Live_BodyList[i].transform.rotation = markM.markerList[0].rotation;
                    Vector3 point = Live_BodyList[i].transform.position - Live_BodyList[i - 1].transform.position;
                    Live_BodyList[i].transform.LookAt(point);
                    markM.markerList.RemoveAt(0);
                }
            }
        }
    }
    //=====================================================================================================
}