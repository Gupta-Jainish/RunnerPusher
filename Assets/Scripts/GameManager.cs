using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //=====================================================================================================
    // Initializations
    //=====================================================================================================
    [SerializeField] List<GameObject> Storage = new List<GameObject>();
    [SerializeField] GameObject[] CubeList;
    [SerializeField] GameObject tomato;
    //=====================================================================================================

    //=====================================================================================================
    // Start is called before the first frame update
    //=====================================================================================================
    void Start()
    {
        AddTomato();
    }
    //=====================================================================================================
    // Fixed Call In Every Devices
    //=====================================================================================================
    void FixedUpdate()
    {
        Initiator();
        AddPlayerMovement();
    }
    //=====================================================================================================

    //=====================================================================================================
    // Adds Item To The Storage
    //=====================================================================================================
    public void AddIntoStorage(GameObject Item)
    {
        Storage.Add(Item);
    }
    //=====================================================================================================


    //=====================================================================================================
    // Adds The Storage object in the World location at (0,0.5,1)
    //=====================================================================================================
    public void Initiator()
    {
        if (Storage.Count > 0)
        {
            Instantiate(Storage[0], new Vector3(0, 0.5f, 1), Quaternion.identity);
            Storage.RemoveAt(0);
        }
    }

    public void AddTomato()
    {
        AddIntoStorage(tomato);
    }
    //=====================================================================================================


    //=====================================================================================================
    // Adds PlayerMovement Script to the Cubelist[0] if it exist
    //=====================================================================================================
    public void AddPlayerMovement()
    {
        
            CubeList = GameObject.FindGameObjectsWithTag("Player");
            if (CubeList.Length > 0)
            {
                if (!CubeList[0].GetComponent<PlayerMovement>())
                {
                    CubeList[0].AddComponent<PlayerMovement>();
                }
            }
        if (CubeList.Length > 0)
        {
            if (!CubeList[0].GetComponent<PlayerMovement>())
            {
                CubeList[0].AddComponent<PlayerMovement>();
            }
        }

    }
    //=====================================================================================================
}