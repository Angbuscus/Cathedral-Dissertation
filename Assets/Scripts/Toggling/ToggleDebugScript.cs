using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDebugScript : MonoBehaviour
{
    [SerializeField]
    private GameObject DebugView;

    private bool isVisible = false;

    public void ToggleVisibility()
    {
        isVisible = !isVisible;
        DebugView.SetActive(isVisible);
    }
}
