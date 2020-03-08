using UnityEngine;
using System.Collections;
using Done;
public class Other : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EventManager.GetInstance().AddEventListener("MonsterDie", OhterThing);
    }

    void OhterThing()
    {
        Debug.Log("other");
    }

	// Update is called once per frame
	void Update () {
	
	}
    void OnDestroy()
    {
        EventManager.GetInstance().RevmoeEventListener("MonsterDie", OhterThing);
    }
}
