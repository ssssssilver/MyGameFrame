using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Done;
public class TestMono2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestMono t= new TestMono();
        //MonoManager.GetInstance().AddUpdateListener(t.Update); ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
