using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //=====================================================================================================
    // Initializations
    //=====================================================================================================
    [SerializeField] float Speed = 500;
    [SerializeField] float SteerVal = 700;
    [SerializeField] float TouchRightVal = 0.6f;
    Rigidbody rb;
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
        rb.velocity = transform.forward * Speed * Time.deltaTime;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TouchRightVal = touch.deltaPosition.x;
            transform.position += transform.right * TouchRightVal * Time.deltaTime / 3;
            
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
}