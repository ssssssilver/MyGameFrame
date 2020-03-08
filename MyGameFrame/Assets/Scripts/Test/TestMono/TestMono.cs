using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Done;

public class TestMono 
{

    // Start is called before the first frame update
    public TestMono()
    {
        MonoManager.GetInstance().AddUpdateListener(Update);
        MonoManager.GetInstance().StartCoroutine(WaitHi());
    }

    IEnumerator WaitHi()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("hi");
    }

    // Update is called once per frame
    public void Update()
    {
        Debug.Log("letmeupdate");
    }
}
