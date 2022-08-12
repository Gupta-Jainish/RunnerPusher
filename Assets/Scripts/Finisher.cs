using UnityEngine;

public class Finisher : MonoBehaviour
{
    [SerializeField] GameObject PositionManagerScript;
    bool onetime = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (onetime)
            {
                PositionManagerScript.GetComponent<PositionManager>().Finisher();
                onetime = false;
            }
        }
    }
}
