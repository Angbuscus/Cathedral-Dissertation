using System; //Guid 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq; //LastOrDefault, SingleOrDefault, Skipwhile, Skip
using System.Text; 
using TMPro;

/// <summary>
/// This script tracks the user's position as the complete the tour. 
/// The position is saved locally every 1-5 second, depending on what is set. 
/// The positions saved are displayed after 30 seconds.
/// The position is set based on the starting location that will be anchored with the QR code.
/// The location is saved as 2 coordinatess, x and y, saved as a vector. 
/// </summary>

public class UserSessionTracker : MonoBehaviour
{
    // Define the varaibles, API Controller and TrackableSessionDTO, defined in their respective scripts.
    private APIController ApiController;
    private TrackableSessionDTO TrackableSession;

    private readonly List<TrailPos> trail = new List<TrailPos>();// Readonly ensures that previous positions will not be overwritten.

    // Old Project Code. 
    private List<Guid>trackedIndicatorIDs = new List<Guid>();

    protected string SessionID { get => sessionID; private set => SessionID = value; } // Property declaration closed data to be accessed and authorise. 
    private string sessionID;
    private Guid lastTrackedID;
    //END OLD PROJ CODE.

    public GameObject user;
    private Transform userPos;

    // Start is called before the first frame update
    void Start()
    {
        // Create an API class, create the Global ID for this session and instantiate Trackable objects.
        ApiController = new APIController();

        sessionID = DateTime.Now.ToString("dd/mm/yyyy") + ":" + Guid.NewGuid().ToString();
        TrackableSession = new TrackableSessionDTO(SessionID);
        

        userPos = user.GetComponent<Transform>();
        // Run Enumerators
        StartCoroutine(SavePos());
        StartCoroutine(ShowPos()); 
    }

    void onDestroy()
    {
        // Create the end session details in the class taking the ID, Date and Time
        SessionEndTimeDTO sessionEnd = new SessionEndTimeDTO { SessionID = sessionID, SessionEndTime = DateTime.Now }; // Class and object created to hold the end of session data i.e. time. 
        // END WHAT
    }

    IEnumerator SavePos() //IEnumerator allows the position logging to occur at its own pace not each frame, using the 
    {
        while (true) // While the app is running
        {
            // Set up new global unique ID for this tour:
            var id = Guid.NewGuid();
            var currentPos = new TrailPos
            {
                ID = id, 
                DateTime = DateTime.Now,
                XCoord = userPos.position.x,
                YCoord = userPos.position.y,
                ZCoord = userPos.position.z,
            };

            var previousPos = trail.LastOrDefault(); //Returns the list of locations, if empty it returns the empty list. LINQ allows for syntactical queries for the list.

            if (trail.Count == 0) // Start the list with the current location, this will later be set to the QR code's location.
            {
                trail.Add(currentPos);
            }
        }
    }
    IEnumerator ShowPos()
    {
        while (true)
        {
            //using old code here to run the API
            int lastIndex = trail.IndexOf(trail.SingleOrDefault(p => p.ID == lastTrackedID));

            // OLD CODE, Understand it and rewrite it. 
            if (lastIndex > 0)
            {
                var output = trail.SkipWhile(tp => tp.ID != lastTrackedID).Skip(1); // Locate the last entry to the trail list, then find the next entry, the last reading. Only the most recent entry is passed. 
                ApiController.PostData(new TrailDTO{ SessionID = sessionID, Positions = output.ToList()
                        .Select(t => new TrailPosDTO
                        {
                            ID = t.ID.ToString(),
                            DateTime = t.DateTime,
                            XCoord = t.XCoord,
                            YCoord = t.YCoord,
                            ZCoord = t.ZCoord }
                        ).ToList() }, "Update Position");
            }
            // END OF OLD CODE.
        }
    } 

}

//Getter and Setter for Trackable Position
public class TrailPos1
{
    public Guid ID { get; set; }
    public DateTime DateTime { get; set; }
    public float XCoord { get; set; }
    public float YCoord { get; set; }
    public float ZCoord { get; set; }
}


