using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    //=====================================================================================================
    // Initializations
    //=====================================================================================================
    [SerializeField] float Speed = 500;
    [SerializeField] float SteerVal = 800;
    [SerializeField] float TouchRightVal;
    [SerializeField] float TouchRightBoundry = 3.4f;
                     Rigidbody rb;
    public bool RightVal;
    public bool Forward = true;
    //=====================================================================================================

    //=====================================================================================================
    // Fixed Call In Every Devices
    //=====================================================================================================
    void FixedUpdate()
    {
        RigidIni();
        PlayerController();
        PlayerMovementUpdate();
    }
    //=====================================================================================================

    //=====================================================================================================
    // Initiates RigidBody
    //=====================================================================================================
    public void RigidIni()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    //=====================================================================================================

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

    //=====================================================================================================
    // Forward Movement
    //=====================================================================================================
    public void PlayerMovementUpdate()
    {
        if (Forward)
        {
            rb.velocity = transform.forward * Speed * Time.deltaTime;
        }
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TouchRightVal = touch.deltaPosition.x;

            if (TouchRightVal > 0)
            {
                if (transform.position.x <TouchRightBoundry)
                {
                    transform.position += transform.right * TouchRightVal * Time.deltaTime / 4;
                }
            }
            if(TouchRightVal < 0)
            {
                if (transform.position.x > -TouchRightBoundry)
                {
                    transform.position += transform.right * TouchRightVal * Time.deltaTime / 4;
                }
            }
        }
    }
    //=====================================================================================================

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
    //=====================================================================================================

    public void right()
    {
        if (rb.transform.position.x >2.5)
        {
            RightVal = true;
        }
        else
        {
            RightVal = false;
        }
    }

    public void ForwaredMovementStop()
    {
        Speed = 0;
    }
}