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
        rb = GetComponent<Rigidbody>();
    }

    //=====================================================================================================
    // Update is called once per frame
    //=====================================================================================================
    void Update()
    {
        PlayerController();
    }
    void FixedUpdate()
    {
        PlayerMovementUpdate();
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
}