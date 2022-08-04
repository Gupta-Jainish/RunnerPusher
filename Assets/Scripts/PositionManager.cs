using UnityEngine;

public class PositionManager : MonoBehaviour
{
    //=====================================================================================================
    // Initializations
    //=====================================================================================================
    [SerializeField] GameObject[] PositionList;
    [SerializeField] float GapBetween = 2;
    //=====================================================================================================

    private void Start()
    {
        
    }

    //=====================================================================================================
    // Fixed Call In Every Devices
    //=====================================================================================================
    void FixedUpdate()
    {
        PosiManager();
    }
    //=====================================================================================================

    //=====================================================================================================
    // Manages Positions
    //=====================================================================================================
    public void PosiManager()
    {
        PositionList = GameObject.FindGameObjectsWithTag("Player");
        

        for (int i = 1; i < PositionList.Length; i++)
        {
            PositionList[i].gameObject.transform.position = PositionList[i - 1].gameObject.transform.position - new Vector3(0, 0, GapBetween);
            PositionList[i].gameObject.transform.rotation = PositionList[i - 1].gameObject.transform.rotation;
            Vector3 point = PositionList[i].transform.position - PositionList[i - 1].transform.position;
            PositionList[i].transform.LookAt(point);
        }
    }
    //=====================================================================================================
}
