using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUserRotationLink : MonoBehaviour
{
    [SerializeField]
    private Transform ARCameraTransform;

    private Vector3 rotationVector;
    // Start is called before the first frame update
    void Start()
    {
        rotationVector = new Vector3();   
    }

    // Update is called once per frame.
    // Euler Angles https://docs.unity3d.com/ScriptReference/Transform-eulerAngles.html
    void Update()
    {
        float yAxis = ARCameraTransform.transform.eulerAngles.y;
        rotationVector = new Vector3(0f, yAxis, 0f);

        transform.eulerAngles = rotationVector;
    }
}
