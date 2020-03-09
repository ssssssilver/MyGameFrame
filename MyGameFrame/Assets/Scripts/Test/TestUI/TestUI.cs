using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Done;
using UnityEngine.UI;

public class TestUI : BasePanel
{
    // Start is called before the first frame update
    void Start()
    {
        GetControl<Button>("Button1").onClick.AddListener(Button1Click);
        GetControl<Button>("Button2").onClick.AddListener(Button2Click);
    }

   void Button1Click()
    {
        Debug.Log("Click 1");

    }
    void Button2Click()
    {
        Debug.Log("Click 2");
    }
}
