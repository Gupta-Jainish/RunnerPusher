using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    //============================================================================================================
    // Marker Takes The Position And Rotations
    //============================================================================================================
    public class Marker
    {
        public Vector3 position;
        public Quaternion rotation;

        public Marker(Vector3 pos, Quaternion rot)
        {
            position = pos;
            rotation = rot;
        }
    }

    //============================================================================================================
    // List MarkerManager(Stores Position And Rotations Of The Player Body)
    //============================================================================================================
    public List<Marker> markerList = new List<Marker>();

    //============================================================================================================
    // Triggers On Every Farames in The Game
    //============================================================================================================
    void FixedUpdate()
    {
        UpdateMarkerList();
    }

    //============================================================================================================
    // Updates The Body Positions And Rotations in The List
    //============================================================================================================
    public void UpdateMarkerList()
    {
        markerList.Add(new Marker(transform.position, transform.rotation));
    }

    //============================================================================================================
    // Clears List Of The Body Positions And Rotations
    //============================================================================================================
    public void ClearMarkerList()
    {
        markerList.Clear();
        markerList.Add(new Marker(transform.position, transform.rotation));
    }
}
