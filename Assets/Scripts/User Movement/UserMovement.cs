using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
///  This script controls the User icon prefab. 
///  Using AR Foundation, as the user moves the device each frame, 
///  both the position (x & z), and the orientation y 
///  will be transferred to the icon to update it's position. 
/// </summary>

public class UserMovement : MonoBehaviour
{
    // Access the AR Camera
    public ARCameraManager arCameraManager;

    // Start is called before the first frame update
    void Start()
    {
        // Initialise the AR Camera Manager Connection
        if (arCameraManager == null)
            arCameraManager = FindObjectOfType<ARCameraManager>();

        // Subsription, update the camera with the new position
        arCameraManager.frameReceived += NewPosition;
    }

    // Update is called once per frame
    void NewPosition(ARCameraFrameEventArgs args)
    {
        // Get the position as a vector and the new angle with a quaternion (rotation measurement)
        Vector3 cameraPos = arCameraManager.transform.position;

        // Relay changes from camera to the user's icon
        // Change made to not update the Y axis reading, have it positioned at the same level throughout the tour. 
        transform.position = new Vector3(cameraPos.x, transform.position.y, cameraPos.z);
    }
    void OnDestroy()
    {
        // Sever connection to the AR Camera
        if (arCameraManager != null)
            arCameraManager.frameReceived -= NewPosition;
    }
}
