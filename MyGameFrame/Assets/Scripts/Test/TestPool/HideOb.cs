using UnityEngine;
using System.Collections;
using Done;

public class HideOb : MonoBehaviour {

	void OnEnable()
    {
        Invoke("HideObj",1f);
    }
    void HideObj()
    {
        PoolManager.GetInstance().SetGameObject(this.name,gameObject);
    }
}
