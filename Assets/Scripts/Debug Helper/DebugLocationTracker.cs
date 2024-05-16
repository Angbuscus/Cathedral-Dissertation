using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugLocationTracker : MonoBehaviour
{

    public TMP_Text scrollRectText;

    [SerializeField]
    private TMP_Text locationOutput;

    // Start is called before the first frame update
    void Start()
    {
        // Run the coroutine to chceck the position every second
        StartCoroutine(UpdatePositionCoroutine());
    }

    // Run on start in place of Update
    private IEnumerator UpdatePositionCoroutine()
    {
        while (true)
        {
            // Get User Position
            Vector3 userPos = transform.position;

            // Move this to the user pin and call it there to save removing the y value every time. 
            float xCoordinate = userPos.x;
            float yCoordinate = userPos.z;

            string xCoord = xCoordinate.ToString("F1");
            string yCoord = yCoordinate.ToString("F1");

            // Send Location data to the Debug area.
            locationOutput.text += "\nPos X: " + xCoord + " Pos Y: " + yCoord; 

            // Wait 1 second 
            yield return new WaitForSeconds(1f);
        }
    }
}
