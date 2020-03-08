using UnityEngine;
using System.Collections;
using Done;
public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EventManager.GetInstance().AddEventListener("MonsterDie", AddExp);
	}

    void AddExp()
    {
        Debug.Log("addEXP");
    }

	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        EventManager.GetInstance().RevmoeEventListener("MonsterDie", AddExp);
    }
}
