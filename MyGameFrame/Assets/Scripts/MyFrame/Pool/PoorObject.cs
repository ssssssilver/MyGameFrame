
using System.Collections.Generic;
using UnityEngine;
namespace Done
{
    public class PoolObject
    {
        //每个分类在回收时再用一个父类包装
        public GameObject parent;
        public List<GameObject> poolList = new List<GameObject>();

        public PoolObject(GameObject ob, Transform poolObj)
        {
            parent = new GameObject(ob.name);
            parent.transform.parent = poolObj;
            poolList = new List<GameObject>() { ob };
            ob.transform.parent = parent.transform;
            SetObj(ob);
        }

        public void SetObj(GameObject ob)
        {
            ob.SetActive(false);
            poolList.Add(ob);
            ob.transform.parent = parent.transform;
        }

        public GameObject GetObj()
        {
            GameObject ob = poolList[0];
            poolList.RemoveAt(0);
            ob.SetActive(true);
            ob.transform.parent = null;
            return ob;
        }
    }
}