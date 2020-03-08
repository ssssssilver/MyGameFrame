using UnityEngine;
using System.Collections;
using Done;

public class TestPool : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            PoolManager.GetInstance().GetGameObject("prefabs/Cube");
        }
        if (Input.GetMouseButtonDown(1))
        {
            PoolManager.GetInstance().GetGameObject("prefabs/Sphere");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Time.timeScale = 1;
        }
    }
}
