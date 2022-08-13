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
                if (gameObject.tag == "Finish")
                {
                    Time.timeScale = 0;
                    PositionManagerScript.GetComponent<GameManager>().NextLevelIni();
                }

                PositionManagerScript.GetComponent<PositionManager>().Finisher();
                PositionManagerScript.GetComponent<PositionManager>().WinBoolTrue();
                onetime = false;
            }
        }
    }
}
