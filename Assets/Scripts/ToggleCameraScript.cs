using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCameraScript : MonoBehaviour
{
    // The Canvas object
    [SerializeField]
    private GameObject UIMiniMap;

    // The Real Minimap being rendered
    [SerializeField]
    private GameObject LiveFloorPlan;

    // User model that shows for some reason.
    [SerializeField]
    private GameObject UserModel;

    private bool isVisible = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Instead of Update use on enable and on disable. 
    // These run when the Toggle Camera Button is pressed. 
    //private void OnEnable()
    //{
    //    ToggleVisibility();
    //}
    //private void OnDisable()
    //{
    //    ToggleVisibility();
    //}

    // Using on enbale and on disable didn't work well, try OnClick on the button itself.

   
    public void ToggleVisibility()
    {
        isVisible = !isVisible;
        UIMiniMap.SetActive(isVisible);
        LiveFloorPlan.SetActive(isVisible);
        UserModel.SetActive(isVisible);
    }
}