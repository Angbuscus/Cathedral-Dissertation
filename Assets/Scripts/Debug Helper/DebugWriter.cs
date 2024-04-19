using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class DebugWriter : MonoBehaviour
{
    public GameObject DebugContentArea;
    private TextMeshProUGUI TextArea;


    void Start()
    {
        TextArea = DebugContentArea.GetComponent<TextMeshProUGUI>();
    }

    public void DisplayInDebug(IEnumerable sentences)
    {
        if (TextArea == null)
            return;

        string temp = "";

        if (!string.IsNullOrEmpty(TextArea.text))
        {
            temp = TextArea.text;
        }

        StringBuilder str = new StringBuilder();

        foreach (var sentence in sentences)
        {
            str.Append(sentence.ToString() + Environment.NewLine);
        }

        str.Append(Environment.NewLine);

        if (string.IsNullOrEmpty(temp))
        {
            TextArea.text = str.ToString();
        }
        else
        {
            TextArea.text = temp + str.ToString();
        }
    }

    public void DisplayInDebug(string sentence)
    {
        if (TextArea == null)
            return;

        string temp = "";

        if (!string.IsNullOrEmpty(TextArea.text))
        {
            temp = TextArea.text;
        }

        StringBuilder str = new StringBuilder();

        str.Append(sentence.ToString() + Environment.NewLine);

        str.Append(Environment.NewLine);

        if (string.IsNullOrEmpty(temp))
        {
            TextArea.text = str.ToString();
        }
        else
        {
            TextArea.text = temp + str.ToString();
        }
    }
}
