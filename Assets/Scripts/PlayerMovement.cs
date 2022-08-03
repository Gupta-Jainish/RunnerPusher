using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]

    List<GameObject> PlayerList = new List<GameObject>();
    List<GameObject> BodyList = new List<GameObject>();



    [SerializeField] float Speed = 30;
    [SerializeField] float SteerVal = 700;
    [SerializeField] GameObject body;
    float countup = 0;
    public Rigidbody rb;



    //=====================================================================================================
    // Start is called before the first frame update
    //=====================================================================================================
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //=====================================================================================================
    // Update is called once per frame
    //=====================================================================================================
    void Update()
    {

    }
    private void FixedUpdate()
    {
        PlayerMovementUpdate();
        PlayerController();
        ManagePlayerList();
    }


    public void PlayerController()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            Left();
        }
        if (Input.GetKey(KeyCode.D))
        {
            Right();
        }
    }
    public void PlayerMovementUpdate()
    {
        rb.velocity = transform.forward * Speed * Time.deltaTime;
    }
    public void Right()
    {
        rb.AddForce(SteerVal, 0, 0);
    }
    public void Left()
    {
        rb.AddForce(-SteerVal, 0, 0);
    }


    void CreateBodyList()
    {
        MarkerManager markM = BodyList[PlayerList.Count - 1].GetComponent<MarkerManager>();

        if (PlayerList.Count == 0)
        {
            GameObject temp1 = Instantiate(BodyList[0], transform.position, transform.rotation, transform);

            if (!temp1.GetComponent<MarkerManager>())
            {
                temp1.AddComponent<MarkerManager>();
            }

            if (!temp1.GetComponent<Rigidbody>())
            {
                temp1.AddComponent<Rigidbody>();
            }
            PlayerList.Add(temp1);
            BodyList.RemoveAt(0);
        }

        if (countup == 0)
        {
            markM.ClearMarkerList();
        }

        countup += Time.deltaTime;

        if (countup >= 0)
        {
            GameObject temp = Instantiate(BodyList[0], markM.markerList[0].position, markM.markerList[0].rotation, transform);

            if (!temp.GetComponent<MarkerManager>())
            {
                temp.AddComponent<MarkerManager>();
            }

            if (!temp.GetComponent<Rigidbody>())
            {
                temp.AddComponent<Rigidbody>();
            }

            PlayerList.Add(temp);
            BodyList.RemoveAt(0);
            temp.GetComponent<MarkerManager>().ClearMarkerList();
            countup = 0;
        }
    }

    void ManagePlayerList()
    {
        if (BodyList.Count > 0)
        {
            CreateBodyList();
        }
        for (int i = 0; i < PlayerList.Count; i++)
        {
            if (PlayerList[i] == null)
            {
                PlayerList.RemoveAt(i);

                i = i - 1;
            }
        }
        if (PlayerList.Count == 0)
        {
            Destroy(this);

        }
    }
}
