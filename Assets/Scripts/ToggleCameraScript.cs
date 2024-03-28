using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //colour the buttons
    private Button button;
    private bool isToggled = false;
    [SerializeField]
    private Color originalColor;
    [SerializeField]
    private Color toggledColor;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        originalColor = button.colors.normalColor;
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

    // Button colour changes, based on toggle status.
    // Doesn't work quite right, come back to this. 
    public void ToggleColor()
    {
        isToggled = !isToggled;
        if (isToggled)
        {
            Debug.Log("Button toggled on");
            ChangeButtonColor(toggledColor);
        }
        else 
        {
            Debug.Log("Button toggled off");
            ChangeButtonColor(originalColor);
        }
    }
    // Colour applier to component
    // ColorBlock is the struct that handles the button colors.
    public void ChangeButtonColor(Color color)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = color;
        button.colors = colors;
    }
}