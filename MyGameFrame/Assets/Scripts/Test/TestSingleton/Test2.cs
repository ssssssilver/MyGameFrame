using UnityEngine;
using System.Collections;

public class Test2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Test1.GetInstance().Test();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
