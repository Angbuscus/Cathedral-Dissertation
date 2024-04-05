using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
/// <summary>
/// This script tracks the user's position as the complete the tour. 
/// The position is saved locally every 1-5 second, depending on what is set. 
/// The positions saved are displayed after 30 seconds.
/// The position is set based on the starting location that will be anchored with the QR code.
/// The location is saved as 2 coordinatess, x and y, saved as a vector. 
/// </summary>
public class UserSessionTracker : MonoBehaviour
{
    private readonly List<TrackablePosition> trail = new List<TrackablePosition>();// Readonly ensures that previous positions will not be overwritten.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator savePos() //IEnumerator allows the position logging to occur at its own pace not each frame, using the 
    {
        while (true) // While the app is running
        {
            var currentPos = new TrackablePosition
            {
                XCoord = position.position.x,
                YCoord = position.position.y,
                ZCoord = position.position.z,
            };
            var previousPos = trail.LastOrDefault(); //Returns the list of locations, if empty it returns the empty list. LINQ allows for syntactical queries for the list.
            
            if (trail.Count = 0)
            {
                trail.Add(currentPos);
            }
        }
    }
