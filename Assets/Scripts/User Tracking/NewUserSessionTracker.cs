using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using System.Text;
using TMPro;

public class NewUserSessionTracker : MonoBehaviour
{

    // Create a list of the positions
    private readonly List<TrailPos> trail = new List<TrailPos>();

    // Get the ID for the session
    protected string SessionID { get => sessionID; private set => sessionID = value; }
    private string sessionID;

    // Take vlaues from component inspector
    public GameObject user;
    private Transform position;
    // How often updates are shown in seconds
    public int logPositions;
    public int displayCollectedPositions;
    // Where the debugging will display
    public GameObject DebugContentArea;
    private TextMeshProUGUI TextArea;

    // Start is called before the first frame update
    void Start()
    {
        // Create the session ID using the date and the current Global Unique ID.
        sessionID = DateTime.Now.ToString("dd/MM/yyy") + ":" + Guid.NewGuid().ToString();

        // Default updating 
        logPositions = 3;
        displayCollectedPositions = 10;

        position = user.GetComponent<Transform>();

        TextArea = DebugContentArea.GetComponent<TextMeshProUGUI>(); // referencing the text area within the ap AI 

        StartCoroutine(LogPositions());
    }

    IEnumerator LogPositions()
    {
        while (true)
        {
            var id = Guid.NewGuid();
            var currentPos = new TrailPos
            {
                ID = id,
                DateTime = DateTime.Now,
                XCoord = position.position.x,
                YCoord = position.position.y,
                ZCoord = position.position.z,
            };

            var previousPos = trail.LastOrDefault();

            if (trail.Count == 0)
            {
                trail.Add(currentPos);
                yield return new WaitForSeconds(logPositions);
            }
            if (previousPos != null)
            {
                trail.Add(currentPos);
            }
            yield return new WaitForSeconds(logPositions);
        }
    }
    void DisplayPositionInConsole()
    {
        foreach (var position in trail)
        {
            Debug.Log($"Position updated: {position.ID}");
            Debug.Log($"Position datetime: {position.DateTime}");
            Debug.Log($"Position x coordinate: {position.XCoord}");
            Debug.Log($"Position y coordinate: {position.YCoord}");
            Debug.Log($"Position z coordinate: {position.ZCoord}");
            Debug.Log(Environment.NewLine);
        }
    }
    void DisplayPositionInMobileDebug()
    {
        StringBuilder str = new StringBuilder();

        foreach (var position in trail)
        {
            str.Append($"Position updated: {position.ID}, \n");
            str.Append($"Position datetime: {position.DateTime}, \n");
            str.Append($"Position x coordinate: {position.XCoord}, \n");
            str.Append($"Position y coordinate: {position.YCoord}, \n");
            str.Append($"Position z coordinate: {position.ZCoord}, \n");
            str.Append(Environment.NewLine);
        }

        TextArea.text = str.ToString();
    }
    // What is this used for?
    public void UpdateSecondsPerPosition(string newSeconds)
    {
        StopCoroutine(LogPositions());

        logPositions = int.Parse(newSeconds);

        Debug.Log($"Updating position every: {newSeconds} seconds");

        StartCoroutine(LogPositions());
    }
}
