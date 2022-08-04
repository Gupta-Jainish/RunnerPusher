using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed = 30;
    [SerializeField] float SteerVal = 700;
    [SerializeField] GameObject body;
                     Rigidbody rb;



    //=====================================================================================================
    // Start is called before the first frame update
    //=====================================================================================================
    void Start()
    {
        RigidIni();
    }

    //=====================================================================================================
    // Update is called once per frame
    //=====================================================================================================
    void Update()
    {
        PlayerController();
    }

    //=====================================================================================================
    // Fixed Call In Every Devices
    //=====================================================================================================
    void FixedUpdate()
    {
        PlayerMovementUpdate();
    }

    public void RigidIni()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationY;
    }

    //=====================================================================================================
    // Input Manager
    //=====================================================================================================
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

    //=====================================================================================================
    // Forward Movement
    //=====================================================================================================
    public void PlayerMovementUpdate()
    {
        rb.velocity = transform.forward * Speed * Time.deltaTime;
    }

    //=====================================================================================================
    // Left And Right Controlls
    //=====================================================================================================
    public void Left()
    {
        rb.AddForce(-SteerVal, 0, 0);
    }
    public void Right()
    {
        rb.AddForce(SteerVal, 0, 0);
    }
}