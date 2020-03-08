using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Done;

public class TestLoadResource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ResourcesManager.GetInstance().LoadResAsync<GameObject>("prefabs/Sphere1", loadComplete);
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameObject ob = ResourcesManager.GetInstance().LoadRes<GameObject>("prefabs/Cube1");
            ob.transform.localScale= Vector3.one * 3;
        }
    }

    void loadComplete(GameObject ob)
    {
        ob.transform.localScale = Vector3.one * 3;
        Debug.Log("我好了");
    }
}
