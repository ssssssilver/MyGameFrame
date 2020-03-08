using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Done;

public class TestInput : MonoBehaviour
{
    private void Start()
    {
        //打开检测
        InputController.GetInstance().SwitchInput(true);
        EventManager.GetInstance().AddEventListener<KeyCode>("WASD按下", KeyDown);
        EventManager.GetInstance().AddEventListener<KeyCode>("WASD松开", KeyUp);
    }

    void KeyDown(KeyCode key)
    {
        Debug.Log(key.ToString()+"按下");
    }
    void KeyUp(KeyCode key)
    {
        Debug.Log(key.ToString()+"松开");
    }
}
