using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TrackableSessionDTO
{
    public string ID;
    public DateTime SessionStartTime;
    public DateTime SessionEndTime;
    public List<TrailPos> Positions;

    public TrackableSessionDTO(string id)
    {
        ID = id;
        SessionStartTime = DateTime.Now;
        Positions = new List<TrailPos>();
    }

    public TrackableSessionDTO() 
    {
        SessionStartTime = DateTime.Now;
        Positions = new List<TrailPos>();
    }
}
