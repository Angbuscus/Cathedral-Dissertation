using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TrailDTO : MonoBehaviour
{
    public string SessionID; //GUID
    public List<TrailPosDTO> Positions;
}
