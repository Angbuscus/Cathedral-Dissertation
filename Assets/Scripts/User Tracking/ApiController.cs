using UnityEngine;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

public class APIController
{
    private string apiURL = "http://example.com/api/"; // Replace with your API URL

    public void PostSession(TrackableSessionDTO session)
    {
        // Convert the object data to a JSON string using Unity's internal JSON serialization
        string json = JsonUtility.ToJson(session);

        // Create a web request to send the JSON string to the API
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiURL);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.ContentLength = Encoding.UTF8.GetByteCount(json);

        // Write the JSON string to the request stream
        using (Stream stream = request.GetRequestStream())
        {
            stream.Write(Encoding.UTF8.GetBytes(json), 0, json.Length);
        }

        // Get the response from the API
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Debug.Log("Session sent to API successfully.");
            }
            else
            {
                Debug.LogError("Error sending session to API: " + response.StatusDescription);
            }
        }
    }

    public void PostUpdatedPositions(TrailDTO positions)
    {
        // Convert the object data to a JSON string using Unity's internal JSON serialization
        string json = JsonUtility.ToJson(positions);

        // Create a web request to send the JSON string to the API
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiURL);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.ContentLength = Encoding.UTF8.GetByteCount(json);

        // Write the JSON string to the request stream
        using (Stream stream = request.GetRequestStream())
        {
            stream.Write(Encoding.UTF8.GetBytes(json), 0, json.Length);
        }

        // Get the response from the API
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Debug.Log("Session sent to API successfully.");
            }
            else
            {
                Debug.LogError("Error sending session to API: " + response.StatusDescription);
            }
        }
    }

    public void PostEndSession(SessionEndTimeDTO sessionEndTime)
    {
        // Convert the object data to a JSON string using Unity's internal JSON serialization
        string json = JsonUtility.ToJson(sessionEndTime);

        // Create a web request to send the JSON string to the API
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiURL);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.ContentLength = Encoding.UTF8.GetByteCount(json);

        // Write the JSON string to the request stream
        using (Stream stream = request.GetRequestStream())
        {
            stream.Write(Encoding.UTF8.GetBytes(json), 0, json.Length);
        }

        // Get the response from the API
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Debug.Log("Session sent to API successfully.");
            }
            else
            {
                Debug.LogError("Error sending session to API: " + response.StatusDescription);
            }
        }
    }

    public void PostData<T>(T data, string endPoint) where T: class
    {
        //Convert the object data to a JSON string using Unity's internal JSON serialization
        string json = JsonUtility.ToJson(data);

        //Debug.Log(json);

        // Create a web request to send the JSON string to the API
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiURL + endPoint);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.ContentLength = Encoding.UTF8.GetByteCount(json);

        // Write the JSON string to the request stream
        using (Stream stream = request.GetRequestStream())
        {
            stream.Write(Encoding.UTF8.GetBytes(json), 0, json.Length);
        }

        // Get the response from the API
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Debug.Log("Session sent to API successfully.");
            }
            else
            {
                Debug.LogError("Error sending session to API: " + response.StatusDescription);
            }
        }
    }
}