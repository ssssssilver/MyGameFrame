using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Done;
public class TestLoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneController.GetInstance().LoadSceneAsync("testMono", LoadSceneComplete);
        }
    }

    void LoadSceneComplete()
    {
        Debug.Log("加载完成");
    }
}
